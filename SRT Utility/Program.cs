using SubtitlesParser.Classes;
using System.Text;

namespace SRT_Utility
{
    internal class Program
    {
        private const string DefaultFilePath = "../../../Data/napisy do filmu.srt";
        private const int DefaultOffset = 5880;

        static void Main(string[] args)
        {
            SolveTask(DefaultFilePath, DefaultOffset);
        }

        static void SolveTask(string originalPath, int offset)
        {
            if (!File.Exists(originalPath))
            { 
                return; 
            }

            string finalPath1 = AppendToPath(originalPath, " - 1");
            string finalPath2 = AppendToPath(originalPath, " - 2");

            var items = LoadFile(originalPath);

            List<SubtitleItem> items1 = new();
            List<SubtitleItem> items2 = new();
            foreach (var item in items)
            {
                item.StartTime += offset;
                item.EndTime += offset;

                if (item.StartTime % 1000 != 0)
                {
                    items1.Add(item);
                }
                else
                {
                    items2.Add(item);
                }
            }

            SaveFile(finalPath1, items1);
            SaveFile(finalPath2, items2);
        }

        static string AppendToPath(string originalPath, string suffix)
        {
            var directory = Path.GetDirectoryName(originalPath);
            var fileName = Path.GetFileNameWithoutExtension(originalPath);
            var extension = Path.GetExtension(originalPath);

            fileName += suffix;
            var fullName = fileName + extension;

            var result = Path.Combine(directory, fullName);
            return result;
        }

        static List<SubtitleItem> LoadFile(string filePath)
        {
            List<SubtitleItem> items;
            var parser = new SubtitlesParser.Classes.Parsers.SrtParser();
            using (var fileStream = File.OpenRead(filePath))
            {
                items = parser.ParseStream(fileStream, Encoding.UTF8);
            }

            return items;
        }

        static void SaveFile(string filePath, List<SubtitleItem> items)
        {
            var writer = new SubtitlesParser.Classes.Writers.SrtWriter();
            using (var str1 = File.OpenWrite(filePath))
            {
                writer.WriteStream(str1, items);
            }
        }
    }
}