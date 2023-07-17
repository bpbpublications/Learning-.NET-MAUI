using System;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        protected readonly HierarchicalNavigationService _navigationService;

        public ViewModelBase()
        {
            _navigationService = new HierarchicalNavigationService();
        }

        public virtual void OnNavigatedTo() { }
    }
}

