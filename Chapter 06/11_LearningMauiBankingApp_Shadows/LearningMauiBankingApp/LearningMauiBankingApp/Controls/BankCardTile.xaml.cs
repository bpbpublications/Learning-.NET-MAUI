namespace LearningMauiBankingApp.Controls;

public partial class BankCardTile : ContentView
{
	public static BindableProperty IsSelectedProperty = BindableProperty.Create(
		nameof(IsSelected),
		typeof(bool),
		typeof(BankCardTile),
		propertyChanged: OnIsSelectedPropertyChanged);

    private const double UnselectedOpacity = 0.5;
	private const double UnselectedScale = 0.9;

	public bool IsSelected
	{
		get => (bool) GetValue(IsSelectedProperty);
		set => SetValue(IsSelectedProperty, value);
	}

	public BankCardTile()
	{
		InitializeComponent();
		UpdateAppearance(false);
    }

	private static void OnIsSelectedPropertyChanged(BindableObject view, object oldValue, object newValue)
	{
		((BankCardTile)view).UpdateAppearance(true);
    }

    private void UpdateAppearance(bool animate)
	{
        if (!animate)
        {
			if (IsSelected)
			{
				RootContainer.Opacity = 1;
				RootContainer.Scale = 1;
            }
			else
			{
                RootContainer.Opacity = UnselectedOpacity;
                RootContainer.Scale = UnselectedScale;
            }
			return;
        }
		
		Animation animation;
		if (IsSelected)
		{
			animation = new Animation()
			{
				{0, 1, new Animation(x => RootContainer.Opacity = x, RootContainer.Opacity, 1) },
				{0, 1, new Animation(x => RootContainer.Scale = x, RootContainer.Scale, 1) }
			};
        }
		else
		{
            animation = new Animation()
            {
                {0, 1, new Animation(x => RootContainer.Opacity = x, RootContainer.Opacity, UnselectedOpacity) },
                {0, 1, new Animation(x => RootContainer.Scale = x, RootContainer.Scale, UnselectedScale) }
            };
        }

		animation.Commit(this, nameof(UpdateAppearance));
    }
}
