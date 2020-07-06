using CsvHelper;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.CsvDriver.Maps;
using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CsvHelper;

namespace MortgageHouse.Backend.CsvDriver.Services
{
    public class DatabaseCsvAccess
    {
        private CsvReader DbReader() => new CsvReader(new StreamReader(DbCsvConstants.ConnectionString), CultureInfo.InvariantCulture);
        private CsvWriter DbWriter() => new CsvWriter(new StreamWriter(File.Open(DbCsvConstants.ConnectionString, FileMode.Append)), CultureInfo.InvariantCulture);

        public IEnumerable<ContactAddress> GetItems()
        {
            using (var reader = DbReader())
            {
                reader.Configuration.HasHeaderRecord = false;
                return reader.GetRecords<ContactAddress>().ToList();
            }
        }

        //INSERTS
        public void Insert<T>(T objectToInsert) where T : class, new()
        {
            using (var writer = DbWriter())
            {
                writer.NextRecord();
                writer.WriteRecord(objectToInsert);
            }
        }
        public void InsertItems<T>(IEnumerable<T> items) where T : class, new()
        {
            using (var writer = DbWriter())
            {
                writer.NextRecord();
                writer.WriteRecords(items);
            }
        }
    }
}
