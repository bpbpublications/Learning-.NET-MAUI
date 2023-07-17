using System;
using System.Threading.Tasks;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Interfaces
{
    public interface INavigationService
    {
        void Initialize<TPage, TViewModel>()
            where TPage : ContentPage
            where TViewModel : ViewModelBase;

        Task NavigateToAsync<TPage, TViewModel, TParameter>(TParameter navigationParameter, bool isModal = false)
            where TPage : ContentPage
            where TParameter : class
            where TViewModel : ViewModelBase;

        Task NavigateToAsync<TPage, TViewModel>(bool isModal = false)
            where TPage : ContentPage
            where TViewModel : ViewModelBase;

        Task NavigateBackAsync();

        void ClearBackStack();

        Task CloseCurrentModalPageAsync();
    }
}

