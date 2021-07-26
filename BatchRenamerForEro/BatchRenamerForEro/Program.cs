using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRenamerForEro
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d;
            FileInfo[] infos;

            while (true)
            {
                Console.WriteLine("Please enter a valid directory>");
                string dir = Console.ReadLine();
                if(dir == "" || dir == "\n")
                {
                    return;
                }

                try
                {
                    d = new DirectoryInfo(dir);
                    infos = d.GetFiles();
                    Console.WriteLine("Get Directory success and complete");
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid directory or nothing to exit");
                }
            }
            
            Console.WriteLine("Available Actions>");
            Console.WriteLine("    1: replace x with y");
            Console.WriteLine("    2: append date at end");
            Console.WriteLine("    3: append text at front");
            Console.Write("    What do you want to do?>");

            string todo = Console.ReadLine();
            Console.WriteLine();
            while (true)
            {
                if (todo == "0")
                {
                    break;
                }
                else if (todo == "1")
                {
                    Console.WriteLine("1: replacing x with y");
                    Console.Write("x = ");
                    string x = Console.ReadLine();
                    Console.Write("y = ");
                    string y = Console.ReadLine();

                    foreach (FileInfo f in infos)
                    {
                        File.Move(f.FullName, f.FullName.Replace(x, y));
                    }
                }
                else if (todo == "2")
                {
                    Console.WriteLine("2: Adding Date To End");
                    foreach (FileInfo f in infos)
                    {
                        File.Move(f.FullName, f.Directory + "\\" + f.Name.Replace(f.Extension, "") + "-" + DateTime.Now.ToString("yyyy'-'MM'-'dd") + f.Extension);
                    }
                }
                else if (todo == "3")
                {
                    Console.Write("3: To append = ");
                    string toAppend = Console.ReadLine();
                    foreach (FileInfo f in infos)
                    {
                        File.Move(f.FullName, f.Directory + "\\" + toAppend + "-" + f.Name);
                    }
                }
                else
                {
                    Console.WriteLine("\n Nothing Valid, 0 to stop");
                    return;
                }
                Console.WriteLine("\n Finished, 0 to stop");
                todo = Console.ReadLine();
            }
            
            Console.WriteLine("All done, enter dir to see the new names, otherwise to exit>");
            todo = Console.ReadLine();
            if(todo == "dir")
            {
                int i = 0;
                foreach (FileInfo f in infos)
                {
                    Console.Write(f.Name + " ");
                    i++;
                    if (i > 4)
                    {
                        Console.WriteLine();
                        i = 0;
                    }
                }
                todo = Console.ReadLine();
            }
        }
    }
}
