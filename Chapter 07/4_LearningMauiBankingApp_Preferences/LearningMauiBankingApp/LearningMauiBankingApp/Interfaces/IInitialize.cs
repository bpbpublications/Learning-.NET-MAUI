using System;
namespace LearningMauiBankingApp.Interfaces
{
	public interface IInitialize<T>
	{
		void Initialize(T navigationParameter);
	}
}

