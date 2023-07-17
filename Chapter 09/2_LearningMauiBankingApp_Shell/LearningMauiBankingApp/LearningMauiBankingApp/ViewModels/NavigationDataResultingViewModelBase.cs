using System;
using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.ViewModels
{
	public abstract class NavigationDataResultingViewModelBase<TNavigationData, TResult> : ViewModelBase, IQueryAttributable
    {
        private TaskCompletionSource<TResult> _resultTsc;

        protected NavigationDataResultingViewModelBase(IStrongShellNavigation strongShellNavigation)
            : base(strongShellNavigation)
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue(typeof(TNavigationData).Name, out object navigationDataObject)
                && navigationDataObject is TNavigationData navigationData)
                OnNavigationDataRecieved(navigationData);

            if (query.TryGetValue(typeof(TaskCompletionSource<TResult>).Name, out object resultTscObject)
                && resultTscObject is TaskCompletionSource<TResult> resultTsc)
                _resultTsc = resultTsc;
        }

        protected abstract void OnNavigationDataRecieved(TNavigationData navigationData);

        protected async Task GoBackWithResultAsync(TResult resultValue)
        {
            await _strongShellNavigation.NavigateBackAsync();
            SetResult(resultValue);
        }

        private void SetResult(TResult resultValue)
        {
            _resultTsc?.SetResult(resultValue);
        }
    }
}
