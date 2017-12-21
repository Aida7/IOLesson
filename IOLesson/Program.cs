using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IOLesson
{
    public class Program
    {
        static void Main(string[] args)
        {
          var drives=  DriveInfo.GetDrives();
            DirectoryInfo info = new DirectoryInfo(@"C:\name_of_folder");
            //info.Delete();
            //Console.WriteLine("drive", drives[0].TotalSize);
            //Directory.CreateDirectory(@"C:\name_of_folder");
            //File.Create(@"C:\name_of_folder\name_of_file.txt");
            //File.ReadAllText();
            FileInfo finfo =new FileInfo (@"C:\name_of_folder\name_of_file.txt");
            //finfo.OpenRead();
           if( Directory.Exists(@"C:\name_of_folder"))
            {
                var directories = Directory.EnumerateDirectories(@"C:\");
                foreach(var dir in directories)
                {
                    Console.WriteLine(dir);
                }
            }Console.ReadLine();
            
        }
        static void FileIO()
        {
            //    File.Create(@"C:\name_of_folder\source");//создадим источник
            //    File.WriteAllText(@"C:\name_of_folder\source", "privet!", Encoding.UTF32);

            File.Create(@"C:\name_of_folder\receiver"); //создадим премник
            //    FileStream - byte,StreamReader / StreamWriter - text BinaryReader / BinaryWriter -.bin
            using (FileStream stream = new FileStream(@"C:\name_of_folder\source", FileMode.OpenOrCreate))
            { string text = "mom ";
                byte[] array = Encoding.UTF32.GetBytes(text);
                stream.Write(array, 0, array.Length);
            }

            using (FileStream stream = new FileStream(@"C:\name_of_folder\source", FileMode.OpenOrCreate))
            {
                
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
             String text = Encoding.UTF32.GetString(array);
            }

            using (StreamReader reader = new StreamReader(@"C:\name_of_folder\name_of_file.txt"))
            {
                string text = reader.ReadToEnd();
            }
            using (StreamWriter writer = new StreamWriter(@"C:\name_of_folder\name_of_file.txt",true))
            {
                string text = "swome text";
                writer.WriteLine(text);
            }
            using (BinaryWriter writer = new BinaryWriter(File.Create(@"C:\name_of_folder\name_of_file.bin")))
            {
                var anonim = new { Name = "sr", Age = 12, Sex = "Male" };
            
                writer.Write(anonim.Name);
                writer.Write(anonim.Age);
                writer.Write(anonim.Sex);
            }
            using (BinaryReader reader = new BinaryReader(File.Create(@"C:\name_of_folder\name_of_file.bin")))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                string sex = reader.ReadString();

                reader.ReadInt32();var anonim = new { Name = "sr", Age = 12, Sex = "Male" };
            }


        }
    }
}
