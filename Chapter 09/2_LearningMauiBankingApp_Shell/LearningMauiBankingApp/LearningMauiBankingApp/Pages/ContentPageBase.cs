using System;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages
{
	public abstract class ContentPageBase : ContentPage
	{
		protected ViewModelBase ViewModel
		{
			get => (ViewModelBase) BindingContext;
			set => BindingContext = value;
		}

		protected ContentPageBase(ViewModelBase viewModel)
		{
			ViewModel = viewModel;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            ViewModel.OnNavigatedTo();
        }
    }
}

