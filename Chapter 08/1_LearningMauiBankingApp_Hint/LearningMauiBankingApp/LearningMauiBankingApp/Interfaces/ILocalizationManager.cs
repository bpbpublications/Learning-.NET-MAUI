using System.Globalization;

namespace LearningMauiBankingApp.Interfaces
{
    public interface ILocalizationManager
    {
        CultureInfo CurrentLocalization { get; }
        void SetCulture(CultureInfo culture);
    }
}

