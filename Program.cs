using System;
using System.IO;
using System.Runtime.InteropServices;

class Programm
{
    static void Main(string[] args)
    {
        DeleteNoUsing();
    }

    public static void DeleteNoUsing()
        {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/Kolesnikov_aa/desktop/88Module");

            if (dirInfo.Exists)
            {
                FileInfo[] fff = dirInfo.GetFiles();
                foreach (FileInfo f in fff)
                {
                    DateTime lastWriteTime = File.GetLastWriteTime("" + f);
                    TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                    DateTime thresholdTime = DateTime.Now.Subtract(timeSpan);
                    
                    Console.WriteLine("Имя файла: " + f);
                    Console.WriteLine("Время последнего исользования файла: " + lastWriteTime);

                if (lastWriteTime < thresholdTime)
                    {
                        Console.WriteLine("Файл подлежит удалению");
                        File.Delete("" + f);                              
                        Console.WriteLine("Файл удален");
                    }
                }
                
                DirectoryInfo[] ddd = dirInfo.GetDirectories();
                foreach (DirectoryInfo dirinfo in ddd)
                {
                    Console.WriteLine("Директорий: " + dirinfo);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}







