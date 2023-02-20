using System;
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
            var dbf = new Dbf();
            dbf.Read(@"D:\temp\C101T1.DBF");

            // TODO Сделать выбор файла с последующей передачей его в dbf.Read
            //string[] dbfFile = Directory.GetFiles(@"D:\temp\", "*.dbf");

            DbfJsonStructure person = new DbfJsonStructure();

            StreamWriter file = File.CreateText(@"D:\temp\person.json");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            // Створюємо массив данніх з підтримкою різних форматів даних
            JsonArray test = new JsonArray();

            // Додаємо виключно ті дані, які нам потрібні
            foreach (DbfRecord record in dbf.Records)
            {
                person.WIC_NUM = record[11].ToString();
                person.WIC_NUMBER_ALL = Int32.Parse(record[16].ToString());
                person.WIC_NUMBER_PFU = Int32.Parse(record[17].ToString());
                person.WIC_SUMM_ALL = Decimal.Parse(record[18].ToString());
                person.WIC_SUMM_PFU = Decimal.Parse(record[19].ToString());

                test.Add(JsonSerializer.SerializeToNode(person, options)); // Додаємо серіалізований об'єкт до массиву
            }

            file.WriteLine(test);
            file.Close();
        }
    }
}