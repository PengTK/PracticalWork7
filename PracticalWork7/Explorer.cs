using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7
{
    internal static class Explorer
    {
        public static List<DriveInfo> GetDrives()
        {
            Arrow arrow = new Arrow(0,0);
            List<DriveInfo> drives = new List<DriveInfo>(DriveInfo.GetDrives());
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Этот компьютер");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (DriveInfo drive in drives)
                Console.WriteLine("  " + drive + "  Свободно " + drive.TotalFreeSpace / 1073741824 + " ГБ из " + drive.TotalSize / 1073741824);
            return drives;
        }

        public static void GetFiles(string path)
        {
            int position;
            Arrow arrow = new Arrow(0, 0);
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Проводник");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.Write("  Название");
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Дата создания");
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            //files = Explorer.GetFiles(path);
            int i = 2;
            foreach (string directory in directories)
            {
                i++;
                Console.Write("  " + directory);
                Console.SetCursorPosition(70, i);
                Console.WriteLine(File.GetCreationTime(directory));
            }
            foreach (string file in files)
                Console.WriteLine("  " + file);
            arrow = new Arrow(3, directories.Length + files.Length + 1);
            position = arrow.CheckPos() - 3;
            if (position != -3)
            {
                if (directories.Length >= position)
                {
                    path = directories[position];
                    Explorer.GetFiles(path);
                }
                else
                {
                    path = files[position - directories.Length];
                    Process.Start(path);
                }
            }
            else
            {
                string[] array = path.Split('\\');
                array[array.Length - 1] = "";
                path = "";
                foreach (var item in array)
                {
                    if (path == "")
                    {
                        path += item + "\\\\";
                    }
                    else
                    path += item;
                }
                Explorer.GetFiles(path);
            }
            //return Files;
        }
    }
}
