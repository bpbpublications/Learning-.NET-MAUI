using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        protected readonly INavigationService _navigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedTo() { }
    }
}

