using System.Globalization;

namespace LearningMauiBankingApp.Converters
{
    public class AccountBalanceToBankCardFormattedString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not decimal balance)
                return null;

            var usCulture = CultureInfo.CreateSpecificCulture("en-US");
            var decimals = (balance - decimal.Truncate(balance)) * 100;

            var formattedString = new FormattedString();
            formattedString.Spans.Add(new Span() { Text = balance.ToString("C0", usCulture), FontFamily = "Poppins-Bold" });
            formattedString.Spans.Add(new Span() { Text = "." });
            formattedString.Spans.Add(new Span() { Text = decimals.ToString("N0") });

            return formattedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("One way converter");
        }
    }
}

