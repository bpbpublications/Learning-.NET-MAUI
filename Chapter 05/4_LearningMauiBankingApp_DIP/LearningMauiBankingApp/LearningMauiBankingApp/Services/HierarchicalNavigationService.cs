using System;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Tools;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Services
{
	public class HierarchicalNavigationService : INavigationService
    {
        public void Initialize<TPage, TViewModel>()
            where TPage : ContentPage
            where TViewModel : ViewModelBase
        {
            var page = CreatePage<TPage, TViewModel>();
            App.Current.MainPage = new NavigationPage(page);
            var viewModel = (ViewModelBase)page.BindingContext;
            viewModel.OnNavigatedTo();
        }

		public async Task NavigateToAsync<TPage, TViewModel, TParameter>(TParameter navigationParameter, bool isModal = false)
			where TPage : ContentPage
			where TParameter : class
			where TViewModel : ViewModelBase
        {
            if (App.Current.MainPage is not NavigationPage navigationPage)
                return;

            var page = CreatePage<TPage, TViewModel>();
            await NavigateByPageInternalAsync<TParameter>(navigationPage.Navigation, page, isModal, navigationParameter);
        }

		public async Task NavigateToAsync<TPage, TViewModel>(bool isModal = false)
            where TPage : ContentPage
            where TViewModel : ViewModelBase
        {
            if (App.Current.MainPage is not NavigationPage navigationPage)
                return;

            var page = CreatePage<TPage, TViewModel>();
            await NavigateByPageInternalAsync<object>(navigationPage.Navigation, page, isModal);
        }

        public async Task NavigateBackAsync()
        {
            if (App.Current.MainPage is not NavigationPage navigationPage)
                return;

            await navigationPage.PopAsync();
        }

        public void ClearBackStack()
        {
            if (App.Current.MainPage is not NavigationPage navigationPage)
                return;

            var currentPage = navigationPage.Navigation.NavigationStack.Last();
            var pagesToRemove = navigationPage.Navigation.NavigationStack.TakeWhile(x => !ReferenceEquals(x, currentPage)).ToList();
            foreach (var pageToRemove in pagesToRemove)
            {
                navigationPage.Navigation.RemovePage(pageToRemove);
            }
        }

        public async Task CloseCurrentModalPageAsync()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

		private async Task NavigateByPageInternalAsync<TParameter>(
            INavigation navigation,
            ContentPage page,
            bool isModal,
            TParameter parameter = null) where TParameter : class
        {
            var viewModel = (ViewModelBase) page.BindingContext;

            if (viewModel is IInitialize<TParameter> initializableViewModel)
                initializableViewModel.Initialize(parameter);

            if (isModal)
                await navigation.PushModalAsync(page);
            else
                await navigation.PushAsync(page);

            viewModel.OnNavigatedTo();
        }

        private ContentPage CreatePage<TPage, TViewModel>()
            where TPage : ContentPage
            where TViewModel : ViewModelBase
        {
            var page = (TPage)Activator.CreateInstance(typeof(TPage));
            var viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel));
            page.BindingContext = viewModel;
            return page;
        }
    }
}