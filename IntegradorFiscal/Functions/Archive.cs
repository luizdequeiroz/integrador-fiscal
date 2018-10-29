using System.IO;
using System.Text;

namespace IntegradorFiscal.Functions
{
    public static class Archive
    {
        public static string Write(this string str, string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            if (System.IO.File.Exists(path))
                File.Delete(path);

            using (var file = new StreamWriter(path, false, Encoding.UTF8))
            {
                str = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\" ?>" + str;

                file.Write(str);
                file.Close();
                return str;
            }
        }

        public static void MoveFile(this FileInfo file, string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Directory.Exists)
                Directory.CreateDirectory(fi.DirectoryName);

            if (File.Exists(path))
                File.Delete(path);

            file.MoveTo(path);
        }
    }
}
