using System;
using System.IO;
using System.Runtime.InteropServices;

    class Programm
    {
    static void Main(string[] args)
    {
        DeleteNoUsing();
    }

    static void DeleteNoUsing()
        {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/Kolesnikov_aa/desktop/8Module");

            if (dirInfo.Exists)
            {
                FileInfo[] fis = dirInfo.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    Console.WriteLine("Файл в директории: " + fi);
                }
                //string filePath = @"/Users/Kolesnikov_aa/desktop/8Module/Text.txt";
                //DateTime lastWriteTime = File.GetLastWriteTime(fi);
                //TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                //DateTime thresholdTime = DateTime.Now.Subtract(timeSpan);


                //if (lastWriteTime < thresholdTime)
                //    Console.WriteLine("Файл подлежит удалению");
                //Console.ReadKey();
                DirectoryInfo[] dis = dirInfo.GetDirectories();
                foreach (DirectoryInfo disd in dis)
                {
                    Console.WriteLine("Директорий: " + disd);
                }
                    
// 8.2.3 Удаление директория со всем содержимым *******
//dirInfo.Delete(true);                              
//Console.WriteLine("Каталог удален");

                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}







