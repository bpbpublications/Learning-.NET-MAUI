using System;
using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Interfaces
{
    public interface IStrongShellNavigation
    {
        Task NavigateToAsync(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null);
        Task<TResult> NavigateToAsync<TResult>(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null);
        Task NavigateToAsync(ShellRootPageRouteId rootPageId, IEnumerable<ShellPageRouteId> pageRouteIds = null, object navigationData = null);

        Task NavigateBackAsync(int numberOfGoBacks = 1, object navigationData = null);
        Task NavigateBackAndPushAsync(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null, int numberOfGoBacks = 1);

        Task NavigateBackToAsync(ShellPageRouteId searchableRouteId, object navigationData = null);
    }
}