using CsvHelper;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MortgageHouse.Backend.CsvDriver.Services
{
    public class DatabaseService
    {
        public string _databasePath => DbConstants.ConnectionString;

        public DatabaseService()
        {
            //Initialize the headers for each entity
            using (var reader = CreateReaderForDb())
            {
                using (var writer = CreateWriterForDb())
                {
                    try
                    {
                        reader.ValidateHeader<Address>();
                    }
                    catch
                    {
                        //Headers do not exist (make sure to create them for the first time)
                        writer.WriteHeader<Address>();
                        writer.WriteHeader<Contact>();
                    }
                }
            }
        }

        private CsvReader CreateReaderForDb() => new CsvReader(new StreamReader(_databasePath), CultureInfo.InvariantCulture);
        private CsvWriter CreateWriterForDb() => new CsvWriter(new StreamWriter(_databasePath), CultureInfo.InvariantCulture);

        //INSERTS
        public void Insert<T>(T objectToInsert) where T : class, new()
        {
            using (var writer = CreateWriterForDb())
                writer.WriteRecord(objectToInsert);
        }
        public void InsertItems<T>(IEnumerable<T> items) where T : class, new()
        {
            using (var writer = CreateWriterForDb())
                writer.WriteRecords(items); //Every write that is called will automtically flush the data to the csv file
        }

        //Get
        public IEnumerable<PersistentType> GetAllItems<PersistentType>() where PersistentType : class, new()
        {
            using (var reader = CreateReaderForDb())
                return reader.GetRecords<PersistentType>();
        }
    }
}
