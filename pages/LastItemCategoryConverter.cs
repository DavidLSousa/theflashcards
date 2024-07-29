using System.Globalization;

namespace theflashcards.Converters
{
    class LastItemCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = value as List<string>;

            //var categories = value.toList();

            return array[^1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
