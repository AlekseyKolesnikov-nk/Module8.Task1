using System;
using System.IO;
using System.Runtime.InteropServices;

class Programm
{
    public static void Main(string[] args)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/Kolesnikov_aa/desktop/8Module");
        if (dirInfo.Exists)                                                 // Проверка пути
            DeleteFiles(dirInfo);
    }

    public static void DeleteFiles(DirectoryInfo dirInfo)
    {
        try
        {
            FileInfo[] fff = dirInfo.GetFiles();
            foreach (FileInfo ff in fff)                                    // Перебираем файлы в директории
            {
                DateTime lastWriteTime = File.GetLastWriteTime("" + ff);    // Время последнего сохранения // На "ff" - ругался, получилось через такую конструкцию
                TimeSpan timeSpan = TimeSpan.FromMinutes(30);               // "Контрольный интервал"
                DateTime minTime = DateTime.Now.Subtract(timeSpan);         // Допустимое время (текущее время - 30 минут)

                Console.WriteLine("\nФайл: " + ff);
                Console.WriteLine("Время последнего сохранения: " + lastWriteTime);

                if (lastWriteTime < minTime)                                // Если время последнего сохранения < допустимого
                {
                    File.Delete("" + ff);
                    Console.WriteLine("Файл удален");
                }
            }

            DirectoryInfo[] ddd = dirInfo.GetDirectories();
            foreach (DirectoryInfo dd in ddd)                               // Перебираем директории
            {
                Console.WriteLine("Директорий: " + dd);
                dirInfo = dd;
                DeleteFiles(dirInfo);
            }
        }
        catch (Exception e)                                                 // Проверка исключений
        {
            Console.WriteLine(e.Message);
        }
    }
}