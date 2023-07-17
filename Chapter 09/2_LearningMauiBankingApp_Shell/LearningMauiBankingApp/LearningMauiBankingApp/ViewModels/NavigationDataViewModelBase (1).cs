using System;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
    public abstract class NavigationDataViewModelBase<TNavigationData> : ViewModelBase, IQueryAttributable
    {
        protected NavigationDataViewModelBase(IStrongShellNavigation strongShellNavigation)
            : base(strongShellNavigation)
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue(typeof(TNavigationData).Name, out object navigationDataObject)
                && navigationDataObject is TNavigationData navigationData)
                OnNavigationDataRecieved(navigationData);
        }

        protected abstract void OnNavigationDataRecieved(TNavigationData navigationData);
    }
}