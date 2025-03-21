using System;

namespace UseModels.ReadWrite
{
    public class FileRW
    {
        public string ReadAndWriteFile(string content)
        {
            File.WriteAllText("./log.txt", content);
            using StreamWriter openWriter = new("./log.txt", append: true);
            openWriter.WriteLine(content);
            openWriter.Close();

            string result = File.ReadAllText("./log.txt");

            return result;
        }
    }
}
