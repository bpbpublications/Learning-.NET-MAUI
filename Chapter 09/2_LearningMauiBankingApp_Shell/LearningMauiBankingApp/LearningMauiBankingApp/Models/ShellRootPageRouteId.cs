using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;

namespace LearningMauiBankingApp.Models
{
    public class ShellRootPageRouteId : ShellRouteId
    {
        public ShellRootPageRouteId(Type shellRootPageType)
            : base(shellRootPageType)
        {
        }
    }
}

