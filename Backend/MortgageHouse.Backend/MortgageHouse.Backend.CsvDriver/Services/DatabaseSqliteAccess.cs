//using CsvHelper;
//using MortgageHouse.Backend.Constants;
//using MortgageHouse.Backend.CsvDriver.Maps;
//using MortgageHouse.Backend.Domain.Entities;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using SQLite;
//using System.Threading.Tasks;

//namespace MortgageHouse.Backend.CsvDriver.Services
//{
//    public class DatabaseSqliteAccess
//    {
//        public SQLiteConnection _connection { get; set; }

//        public DatabaseSqliteAccess(SQLiteConnection connection)
//        {
//            _connection = connection;
//            _connection.BusyTimeout = new TimeSpan(1, 0, 0);

//            InitialiseTables();
//        }

//        public void InitialiseTables()
//        {
//            //this._connection.CreateTable<Logs>();
//            //this._connection.CreateTable<Manifest>();
//            //this._connection.CreateTable<ManifestShipperUnit>();
//            //this._connection.CreateTable<ServiceActivity>();
//            //this._connection.CreateTable<ShipperUnit>();
//            //this._connection.CreateTable<ShippingUnitQuantity>();
//        }

//        public void BeginTransaction() => _connection.BeginTransaction();
//        public void CloseDatabase() => _connection.Close();

//        public void Commit() => _connection.Commit();
//        public void CreateTable<T>() => _connection.CreateTable<T>();

//        //Remove Items
//        public void Delete(object objectToDelete) => _connection.Delete(objectToDelete);
//        public void Delete<T>(Guid id) => _connection.Delete<T>(id);
//        public void Delete<T>(IEnumerable<Guid> ids) => _connection.DeleteAll<T>(); //Check this logic ??
//        public void DeleteAll<T>() => _connection.DeleteAll<T>();

//        public void DropTable<T>() => _connection.DropTable<T>();
//        public void Execute(string query, params object[] args) => _connection.CreateCommand(query, args).ExecuteNonQuery();

//        IEnumerable<PersistentType> Get<PersistentType>(string queryStatement, params object[] queryParameter) => _connection.CreateCommand(queryStatement, queryParameter).ExecuteQuery<PersistentType>().ToList();
//        Task<IEnumerable<PersistentType>>GetAsync<PersistentType>(string query) => _connection.CreateCommand(query).ExecuteScalar<Task<IEnumerable<PersistentType>>>();
//        public IEnumerable<PersistentType> GetAll<PersistentType>(string queryStatement) where PersistentType : class, new() => _connection.CreateCommand(queryStatement).ExecuteQuery<PersistentType>().AsEnumerable();
//        public IEnumerable<T> GetItems<T>(Func<T, bool> condition) where T : class, new()
//        {

//            return null;
//        }

//        public ScalarType GetScalar<ScalarType>(string query) where ScalarType : new() => _connection.ExecuteScalar<ScalarType>(query);
//        public Task<ScalarType> GetScalarAsync<ScalarType>(string query) where ScalarType : new() => _connection.ExecuteScalar<Task<ScalarType>>(query);
//        public T GetSingleItem<T>(Func<T, bool> condition) where T : class, new() => _connection.Get<T>(condition);

//        //INSERTS
//        public void Insert<T>(T objectToInsert) => _connection.Insert(objectToInsert);
//        public int InsertItems<T>(IEnumerable<T> items) => _connection.InsertAll(items);
//        public void InsertOrUpdate<T>(T obj) => _connection.InsertOrReplace(obj);

//        //TRANSACTION MANAGEMENT
//        public void Rollback() => _connection.Rollback();
//        public void RunInTransaction(Action action) => _connection.RunInTransaction(() => { action.Invoke(); });
//        public void SaveChanges() => _connection.Commit();
//        public Task SaveChangesAsync() => Task.Run(() => { _connection.Commit(); });

//        //UPDATE
//        public void Update<T>(T objectToUpdate) where T : class, new() => _connection.Update(objectToUpdate);
//        public void Update<T>(IEnumerable<T> objectsToUpdate) where T : class, new() => _connection.UpdateAll(objectsToUpdate);
//        public int UpdateItems<T>(IEnumerable<T> models) => _connection.UpdateAll(models);

//        public void InsertOrReplace<T>(T objectToInsert) => _connection.InsertOrReplace(objectToInsert);
//        public int InsertOrReplaceItems<T>(IEnumerable<T> items) => _connection.InsertAll(items);
//    }
//}
