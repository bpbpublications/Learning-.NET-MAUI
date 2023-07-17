using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Tools
{
	public static class ShellRouteIdHelper
	{
        public static ShellPageRouteId GetId<T>()
			where T : IShellPage
		{
			return new ShellPageRouteId(typeof(T));
		}

        public static ShellRootPageRouteId GetRootId<T>()
            where T : IShellRootPage
        {
            return new ShellRootPageRouteId(typeof(T));
        }
    }
}