using System.Globalization;

namespace LearningMauiBankingApp.Converters
{
    public class AccountBalanceToCardBackgroundImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not decimal balance)
                return string.Empty;

            return balance < 5000
                ? "bank_card_background1.png"
                : "bank_card_background2.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("One way converter");
        }
    }
}

