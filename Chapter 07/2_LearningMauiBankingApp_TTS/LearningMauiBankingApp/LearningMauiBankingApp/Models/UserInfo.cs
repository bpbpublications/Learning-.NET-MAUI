using System;
using LearningMauiBankingApp.Interfaces;
using LiteDB;

namespace LearningMauiBankingApp.Models
{
	public class UserInfo : ILocalStorageItem
    {
        [BsonId]
        public ObjectId LocalStorageId { get; set; }

        public string UserName { get; }

        public UserInfo(string userName)
        {
            UserName = userName;
        }

        [BsonCtor]
        public UserInfo(ObjectId localStorageId, string userName)
            : this(userName)
        {
            LocalStorageId = localStorageId;
        }
    }
}