using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        new Animation()
        {
            { 0, 0.6, new Animation(x => BottomBarBrush.Radius = x, 0.01, 0.4, Easing.CubicOut) },
            { 0.5, 1, new Animation(x => BottomBarBrush.Center = new Point(x, 1 - x), 0.5, 0, Easing.CubicInOut) },
        }.Commit(this, nameof(OnNavigatedTo), length: 3000);

        base.OnNavigatedTo(args);
    }
}
