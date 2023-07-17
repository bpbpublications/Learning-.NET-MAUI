using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Services;

namespace LearningMauiBankingApp.Models
{
	public abstract class ShellRouteId
	{
        public string RouteId { get; }
        public Type PageType { get; }

        protected ShellRouteId(Type pageType)
		{
            PageType = pageType;
            RouteId = pageType.Name;
        }
    }
}