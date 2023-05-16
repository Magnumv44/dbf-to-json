using System;
using System.Collections.Generic;
using System.IO;
using dBASE.NET;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace DBFtoJson
{
    internal class Program
    {
        static void Main()
        {
            // определим пути к папкам в отдельные переменные
            string incomingDataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "incoming");
            string outDataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out");

            // проверим, есть ли папка incoming, и если нет - создадим ее
            if (!Directory.Exists(incomingDataFolder))
            {
                Directory.CreateDirectory(incomingDataFolder);
                Console.WriteLine("The 'incoming' directory was created");
                Console.ReadKey();
            }

            // определим путь к файлу базы данных
            string dbfPath = Path.Combine(incomingDataFolder, "C101T1.DBF");

            // проверим, существует ли файл базы данных, и если нет - выведем сообщение об ошибке и завершим работу программы
            if (!File.Exists(dbfPath))
            {
                Console.WriteLine($"The '{dbfPath}' file does not exist.");
                Console.WriteLine("Please enter the path to the DBF file:");
                dbfPath = Console.ReadLine();
            }

            // загрузим базу данных
            var dbf = new Dbf();
            dbf.Read(dbfPath);

            // создадим список объектов DbfJsonStructure
            var persons = new List<DbfJsonStructure>();

            // преобразуем каждую запись из базы данных в объект DbfJsonStructure и добавим его в список
            foreach (DbfRecord record in dbf.Records)
            {
                var person = new DbfJsonStructure();
                person.WIC_NUM = record[11].ToString();
                person.WIC_NUMBER_ALL = Int32.Parse(record[16].ToString());
                person.WIC_NUMBER_PFU = Int32.Parse(record[17].ToString());
                person.WIC_SUMM_ALL = Decimal.Parse(record[18].ToString());
                person.WIC_SUMM_PFU = Decimal.Parse(record[19].ToString());
                persons.Add(person);
            }

            // создадим объект JsonArray, содержащий сериализованные объекты DbfJsonStructure
            JsonArray jsonArray = new JsonArray();
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            foreach (DbfJsonStructure person in persons)
            {
                JsonNode jsonNode = JsonSerializer.SerializeToNode(person, jsonOptions);
                jsonArray.Add(jsonNode);
            }

            // создадим выходную папку, если она не существует
            if (!Directory.Exists(outDataFolder))
            {
                Directory.CreateDirectory(outDataFolder);
                Console.WriteLine("The 'out' directory was created");
            }

            // создадим имя выходного файла, основанное на текущей дате и времени
            string outputFileName = $"person_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.json";
            string outputPath = Path.Combine(outDataFolder, outputFileName);

            // создадим выходной файл и запишем в него массив JsonArray
            using (StreamWriter outputFile = new StreamWriter(outputPath))
            {
                outputFile.WriteLine(jsonArray.ToString());
            }
        }
    }
}
