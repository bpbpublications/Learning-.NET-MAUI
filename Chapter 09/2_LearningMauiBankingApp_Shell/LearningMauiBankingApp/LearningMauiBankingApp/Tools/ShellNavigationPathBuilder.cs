using System;
using System.Text;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Services;

namespace LearningMauiBankingApp.Tools
{
    public class ShellNavigationPathBuilder
    {
        public const char RouteSeparator = '/';
        public const string GoBackWaypointId = "..";
        public const string AbsoluteRoutePrefix = "//";

        private readonly bool _isAbsoluteRoute;

        private IList<string> _waypoints = new List<string>();

        public ShellNavigationPathBuilder()
        {
        }

        public ShellNavigationPathBuilder(ShellRootPageRouteId rootRouteId)
        {
            _waypoints.Add(rootRouteId.RouteId);
            _isAbsoluteRoute = true;
        }

        public string BuildRoute()
        {
            var route = string.Join(RouteSeparator, _waypoints);
            if (_isAbsoluteRoute)
                route = route.Insert(0, AbsoluteRoutePrefix);

            return route;
        }

        public ShellNavigationPathBuilder GoBack()
        {
            if (_waypoints.Any(x => x != GoBackWaypointId))
                return this;

            _waypoints.Add(GoBackWaypointId);
            return this;
        }

        public ShellNavigationPathBuilder Append(ShellPageRouteId pageRouteId)
        {
            _waypoints.Add(pageRouteId.RouteId);
            return this;
        }
    }
}