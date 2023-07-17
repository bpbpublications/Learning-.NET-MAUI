using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Pages;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.Controls
{
	public class StrongShellContent<TContentPage> : ShellContent
		where TContentPage : IShellRootPage
	{
		public StrongShellContent()
		{
			ContentTemplate = new DataTemplate(typeof(TContentPage));
			Route = ShellRouteIdHelper.GetRootId<TContentPage>().RouteId;
		}
	}
}

