using LearningMauiBankingApp.Models;

namespace LearningMauiBankingApp.Pages;

public partial class HomePage : ContentPage
{
    public IEnumerable<BankCard> BankCards { get; }

	public HomePage()
	{
		InitializeComponent();

        BankCards = new List<BankCard>
        {
            new BankCard("Main card", 1882824500100505, new DateTime(2029, 5, 1), 3253.45m),
            new BankCard("Emergency card", 4004799964524057, new DateTime(2028, 2, 1), 8500m),
            new BankCard("Savings card", 4576241367871031, new DateTime(2025, 10, 1), 4300m),
        };

        BankCardsStackLayout.BindingContext = this;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Navigation.RemovePage(Navigation.NavigationStack[0]);
        base.OnNavigatedTo(args);
    }
}
