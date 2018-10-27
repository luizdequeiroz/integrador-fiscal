using IntegradorFiscal.MFE.tags;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace IntegradorFiscal.Functions
{
    public static class Serializer
    {
        public static string Serialize<T>(this T t)
        {
            var xml = new XmlSerializer(typeof(T));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.Indent = false;
                var writer = XmlWriter.Create(textWriter, settings);
                if (writer.WriteState != WriteState.Start)
                    writer.WriteFullEndElement();
                xml.Serialize(writer, t, namespaces);
                var result = XElement.Parse(textWriter.ToString()).ToString(SaveOptions.DisableFormatting);

                if (typeof(T) == typeof(CFe))
                    return result.AdjustmentCFe();
                else return result;
            }
        }

        private static string AdjustmentCFe(this string str, string parentTag = "CFe")
        {
            str = str.Replace("xmlns:p3=\"http://www.w3.org/2001/XMLSchema-instance\" p3:nil=\"true\"", "");
            str = str.Replace("p3:nil=\"true\" xmlns:p3=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            var doc = XDocument.Parse(str);

            #region [Ajuste em det]
            var itensDet = doc.Element(parentTag).Element($"inf{parentTag}").Element("dets");

            foreach (var i in itensDet.Elements().OrderByDescending(d => d.Attribute("nItem").Value).ToList())
                if (doc.Element(parentTag).Element($"inf{parentTag}").Element("entrega") != null)
                    doc.Element(parentTag).Element($"inf{parentTag}").Element("entrega").AddAfterSelf(i);
                else doc.Element(parentTag).Element($"inf{parentTag}").Element("dest").AddAfterSelf(i);

            doc.Element(parentTag).Element($"inf{parentTag}").Element("dets").Remove();
            #endregion
            #region [Ajuste em pgto.MP]
            var itensMP = doc.Element(parentTag).Element($"inf{parentTag}").Element("pgto").Element("MPs");

            foreach (var i in itensMP.Elements().ToList())
                if (doc.Element(parentTag).Element($"inf{parentTag}").Element("pgto").Element("vTroco") != null)
                    doc.Element(parentTag).Element($"inf{parentTag}").Element("pgto").Element("vTroco").AddBeforeSelf(i);
                else doc.Element(parentTag).Element($"inf{parentTag}").Element("pgto").Add(i);

            doc.Element(parentTag).Element($"inf{parentTag}").Element("pgto").Element("MPs").Remove();
            #endregion

            return doc.ToString(SaveOptions.DisableFormatting);
        }
    }
}
