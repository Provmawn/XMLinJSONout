using System;
using System.IO;

namespace XMLinJSONout
{

    public class FileManager
    {
        public string Contents { get; }
        private StreamReader reader;
        public FileManager(string path)
        {
            reader = new StreamReader(path);
        
            try
            {
                do
                {
                    Contents += reader.ReadLine();
                }
                while (reader.Peek() != -1);    // TODO: use more descriptive name for '-1'
            }
            catch
            {
                Console.WriteLine("File Stream is Empty!");
            }
            finally
            {
                reader.Close();
            }
        }

        public void PrintFile()
        {
            Console.WriteLine(Contents);
        }
    }
}
