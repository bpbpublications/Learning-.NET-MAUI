using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Services;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        protected readonly IStrongShellNavigation _strongShellNavigation;

        public ViewModelBase(IStrongShellNavigation strongShellNavigation)
        {
            _strongShellNavigation = strongShellNavigation;
        }

        public virtual void OnNavigatedTo() { }
    }
}

