using System;
using System.Linq.Expressions;
using LearningMauiBankingApp.Models;
using LiteDB;

namespace LearningMauiBankingApp.Interfaces
{
	public interface ILocalStorage
	{
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate = null)
            where T : ILocalStorageItem;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null)
            where T : ILocalStorageItem;
        void Insert<T>(T item) where T : ILocalStorageItem;
        void Insert<T>(IEnumerable<T> item) where T : ILocalStorageItem;
        bool Update<T>(T item) where T : ILocalStorageItem;
        bool Delete<T>(ObjectId id) where T : ILocalStorageItem;
        bool DeleteAll<T>() where T : ILocalStorageItem;
    }
}

