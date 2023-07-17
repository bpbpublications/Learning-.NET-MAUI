using System.Globalization;

namespace LearningMauiBankingApp.Converters
{
    public class DateOnlyToBankCardExpirationDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DateTime date)
                return string.Empty;

            return $"{date:MM} / {date:yy}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("One way converter");
        }
    }
}

