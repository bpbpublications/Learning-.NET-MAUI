using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.Services
{
	public class StrongShellNavigation : IStrongShellNavigation
    {
        public async Task NavigateBackAndPushAsync(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null, int numberOfGoBacks = 1)
        {
            await NavigateBackInternalAsync(pageRouteIds, navigationData, numberOfGoBacks);
        }

        public async Task NavigateBackAsync(int numberOfGoBacks = 1, object navigationData = null)
        {
            await NavigateBackInternalAsync(null, navigationData, numberOfGoBacks);
        }

        public async Task NavigateBackToAsync(ShellPageRouteId searchableRouteId, object navigationData = null)
        {
            var navigationStackWaypoints = Shell.Current.CurrentState.Location.OriginalString
                .Replace("//",String.Empty)
                .Split('/')
                .ToList();
            var waypointIndex = navigationStackWaypoints.IndexOf(searchableRouteId.RouteId);

            if (waypointIndex < 0 || navigationStackWaypoints.Count == waypointIndex + 1)
                return;

            var numberOfGobacks = navigationStackWaypoints.Count - 1 - waypointIndex;
            await NavigateBackAsync(numberOfGobacks, navigationData);
        }

        public async Task<TResult> NavigateToAsync<TResult>(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null)
        {
            var route = GetNavigationToRoute(null, pageRouteIds);
            return await NavigateToInternalAsync<TResult>(route, navigationData);
        }

        public async Task NavigateToAsync(IEnumerable<ShellPageRouteId> pageRouteIds, object navigationData = null)
        {
            var route = GetNavigationToRoute(null, pageRouteIds);
            await NavigateToInternalAsync(route, navigationData);
        }

        public async Task NavigateToAsync(ShellRootPageRouteId rootPageId, IEnumerable<ShellPageRouteId> pageRouteIds = null, object navigationData = null)
        {
            var route = GetNavigationToRoute(rootPageId, pageRouteIds);
            await NavigateToInternalAsync(route, navigationData);
        }

        private string GetNavigationToRoute(ShellRootPageRouteId rootPageId, IEnumerable<ShellPageRouteId> pages)
        {
            var routeBuilder = rootPageId is null ? new ShellNavigationPathBuilder() : new ShellNavigationPathBuilder(rootPageId);

            if (pages is not null)
                foreach (var pageRouteId in pages)
                    routeBuilder.Append(pageRouteId);

            return routeBuilder.BuildRoute();
        }

        private async Task NavigateBackInternalAsync(IEnumerable<ShellPageRouteId> pages, object navigationData, int numberOfGoBacks = 1)
        {
            if (numberOfGoBacks < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfGoBacks), "Value must be greater than 0");

            var routeBuilder = new ShellNavigationPathBuilder();
            for (int i = 0; i < numberOfGoBacks; i++)
                routeBuilder.GoBack();

            if (pages is not null)
                foreach (var pageRouteId in pages)
                    routeBuilder.Append(pageRouteId);

            var route = routeBuilder.BuildRoute();
            await NavigateToInternalAsync(route, navigationData);
        }

        private async Task<TResult> NavigateToInternalAsync<TResult>(string route, object navigationData)
        {
            var pageResultTsc = new TaskCompletionSource<TResult>();
            var navigationParameters = new Dictionary<string, object>()
            {
                { typeof(TaskCompletionSource<TResult>).Name, pageResultTsc }
            };

            if (navigationData is not null)
                navigationParameters.Add(navigationData.GetType().Name, navigationData);

            await Shell.Current.GoToAsync(new ShellNavigationState(route), true, navigationParameters);
            return await pageResultTsc.Task; 
        }

        private async Task NavigateToInternalAsync(string route, object navigationData)
        {
            var navigationParameters = new Dictionary<string, object>();

            if (navigationData is not null)
                navigationParameters.Add(navigationData.GetType().Name, navigationData);

            await Shell.Current.GoToAsync(new ShellNavigationState(route), true, navigationParameters);
        }
	}
}