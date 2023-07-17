using System.Windows.Input;

namespace LearningMauiBankingApp.Controls;

public partial class BankingServiceButton : ContentView
{
    public static BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(BankingServiceButton),
        propertyChanged: OnTextPropertyChanged);

    public static BindableProperty ImageProperty = BindableProperty.Create(
        nameof(Image),
        typeof(string),
        typeof(BankingServiceButton),
        propertyChanged: OnImagePropertyChanged);

    public static BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(BankingServiceButton));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public BankingServiceButton()
	{
		InitializeComponent();
	}

    private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((BankingServiceButton)bindable).DescriptionLabel.Text = (string)newValue;
    }

    private static void OnImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((BankingServiceButton)bindable).InnerButton.Source = (string)newValue;
    }
}
