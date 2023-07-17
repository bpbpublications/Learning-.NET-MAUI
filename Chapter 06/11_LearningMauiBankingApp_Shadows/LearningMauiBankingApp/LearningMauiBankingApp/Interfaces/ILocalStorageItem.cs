using System;
using LiteDB;

namespace LearningMauiBankingApp.Interfaces
{
	public interface ILocalStorageItem
	{
        ObjectId LocalStorageId { get; set; }
    }
}

