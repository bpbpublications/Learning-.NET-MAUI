using System.ComponentModel;
using System.Globalization;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Localization;

namespace LearningMauiBankingApp.Services
{
	public class LocalizationManager : ILocalizationManager, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CultureInfo CurrentLocalization => Strings.Culture;

        public string this[string resourceKey] =>
            Strings.ResourceManager.GetString(resourceKey, Strings.Culture);

        public void SetCulture(CultureInfo culture)
        {
            Strings.Culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}

