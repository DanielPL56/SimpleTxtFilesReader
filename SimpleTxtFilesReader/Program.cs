using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTxtFilesReader
{
    class Program
    {
        private static bool enterMenu = true;

        static void Main(string[] args)
        {
            using (StreamWriter writer = File.CreateText("TestTextFile.txt"))
            {
                writer.WriteLine("Hello World");
            }

            using (StreamWriter writer = File.CreateText("TextFile2.txt"))
            {
                writer.WriteLine("Hello world 2");
            }

            while (enterMenu)
            {
                //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\pedob\source\repos\BackUpPC");
                DirectoryInfo dir = new DirectoryInfo(".");

                FileInfo[] files = dir.GetFiles("*.txt");

                Console.WriteLine("Number of found txt files: {0}", files.Length);

                int fileNumber = 1;
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name + $" ({fileNumber})");
                    fileNumber++;
                }

                Console.Write("What file to read? ");

                string userString = Console.ReadLine();

                if (int.TryParse(userString, out int userNumber))
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (i == userNumber - 1)
                        {
                            MyReader(files[i]);
                        }
                    }
                }
                else
                {
                    userString = userString + ".txt";

                    foreach (FileInfo file in files)
                    {
                        if (file.Name.ToUpper() == userString.ToUpper())
                        {
                            MyReader(file);
                        }
                    }
                }

                Console.WriteLine("Open new File (1)");
                Console.WriteLine("Exit App (2)");

                userString = Console.ReadLine();
                if (int.TryParse(userString, out userNumber))
                {
                    if (userNumber == 2)
                        enterMenu = false;
                }

                Console.Clear();
            }
        }

        private static void MyReader(FileInfo file)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                {
                    Console.WriteLine(text);
                }
            }
        }
    }
}
