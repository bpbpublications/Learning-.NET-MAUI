using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;

namespace LearningMauiBankingApp.Models
{
	public class ShellPageRouteId : ShellRouteId
	{
		public ShellPageRouteId(Type pageType)
			: base(pageType)
		{
		}
	}
}

