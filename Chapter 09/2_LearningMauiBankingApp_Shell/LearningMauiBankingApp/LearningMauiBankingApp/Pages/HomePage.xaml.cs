using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Pages.ModalPages;
using LearningMauiBankingApp.ViewModels;

namespace LearningMauiBankingApp.Pages;

public partial class HomePage : ContentPageBase, IShellRootPage
{
    private readonly IGyroscope _gyroscope;
    private DateTime _lastVisibleBottomBarRotationChange;

    public HomePage(HomePageViewModel viewModel, IGyroscope gyroscope)
        : base(viewModel)
    {
        _gyroscope = gyroscope;
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

    protected override void OnAppearing()
    {
        if (_gyroscope.IsSupported)
        {
            _gyroscope.ReadingChanged += OnGyroscopeReadingChanged;
            _gyroscope.Start(SensorSpeed.Fastest);
        }
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        if (_gyroscope.IsSupported)
        {
            _gyroscope.ReadingChanged -= OnGyroscopeReadingChanged;
            _gyroscope.Stop();
        }
        base.OnDisappearing();
    }

    private void OnGyroscopeReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        if (this.AnimationIsRunning(nameof(ResetBotomBarRotation)))
            return;

        const double maxRotationXY = 8;
        const double maxRotationZ = 4;
        
        const double velocityCoeficient = 0.5;
        TimeSpan resetRotationFreePlayWait = TimeSpan.FromMilliseconds(250);

        var velocityX = e.Reading.AngularVelocity.X;
        var velocityY = e.Reading.AngularVelocity.Y;
        var velocityZ = e.Reading.AngularVelocity.Z;

        var newRotationX = BottomBar.RotationX + velocityX * velocityCoeficient;
        var newRotationY = BottomBar.RotationY - velocityY * velocityCoeficient;
        var newRotationZ = BottomBar.Rotation - velocityZ * velocityCoeficient;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (Math.Abs(newRotationX) <= maxRotationXY)
                BottomBar.RotationX = newRotationX;

            if (Math.Abs(newRotationY) <= maxRotationXY)
                BottomBar.RotationY = newRotationY;

            if (Math.Abs(newRotationZ) <= maxRotationZ)
                BottomBar.Rotation = newRotationZ;
        });

        if (IsDeviceRotatingSignificantly(velocityX, velocityY, velocityZ))
        {
            _lastVisibleBottomBarRotationChange = DateTime.Now;
        }
        else if (DateTime.Now - _lastVisibleBottomBarRotationChange >= resetRotationFreePlayWait)
        {
            ResetBotomBarRotation();
            _lastVisibleBottomBarRotationChange = DateTime.Now;
        }
            
    }

    private bool IsDeviceRotatingSignificantly(double velocityX, double velocityY, double velocityZ)
    {
        const double rotationFreePlayVelocityLimit = 0.08;

        return Math.Abs(velocityX) > rotationFreePlayVelocityLimit
            || Math.Abs(velocityY) > rotationFreePlayVelocityLimit
            || Math.Abs(velocityZ) > rotationFreePlayVelocityLimit;
    }

    private void ResetBotomBarRotation()
    {
        new Animation()
        {
            { 0, 1, new Animation(x => BottomBar.RotationX = x, BottomBar.RotationX, 0) },
            { 0, 1, new Animation(x => BottomBar.RotationY = x, BottomBar.RotationY, 0) },
            { 0, 1, new Animation(x => BottomBar.Rotation = x, BottomBar.Rotation, 0) }
        }.Commit(this, nameof(ResetBotomBarRotation), length: 400, easing: Easing.CubicInOut);
    }
}
