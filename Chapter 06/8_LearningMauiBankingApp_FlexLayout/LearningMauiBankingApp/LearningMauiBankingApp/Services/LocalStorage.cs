using System;
using System.Linq.Expressions;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LiteDB;

namespace LearningMauiBankingApp.Services
{
    public sealed class LocalStorage : ILocalStorage, IDisposable
    {
        private const string DatabaseFileName = "localDb.db";

        private readonly LiteRepository _localDatabase;
        private bool _disposed;

        public LocalStorage()
        {
            var filePath = FileSystem.Current.AppDataDirectory;
            filePath = Path.Combine(filePath, DatabaseFileName);
            var connectionString = $"Filename={filePath};Mode=Exclusive;";

            _localDatabase = new LiteRepository(connectionString);
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate = null) where T : ILocalStorageItem
        {
            return predicate is null
                ? _localDatabase.Query<T>().ToList()
                : _localDatabase.Query<T>().Where(predicate).ToList();
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : ILocalStorageItem
            => _localDatabase.FirstOrDefault(predicate);

        public void Insert<T>(T item) where T : ILocalStorageItem
            => _localDatabase.Insert(item);

        public void Insert<T>(IEnumerable<T> item) where T : ILocalStorageItem
            => _localDatabase.Insert(item);

        public bool Update<T>(T item) where T : ILocalStorageItem
            => _localDatabase.Update(item);

        public bool Delete<T>(ObjectId id) where T : ILocalStorageItem
            => _localDatabase.Delete<T>(id);

        public bool DeleteAll<T>() where T : ILocalStorageItem
            => _localDatabase.Database.DropCollection(typeof(T).Name);

        public void Dispose()
        {
            if (!_disposed)
                _localDatabase.Dispose();

            _disposed = true;
        }
    }
}