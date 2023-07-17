using System.Collections.ObjectModel;
using LearningMauiBankingApp.Enums;
using LearningMauiBankingApp.Interfaces;
using LearningMauiBankingApp.Themes;
using Microsoft.Extensions.DependencyInjection;

namespace LearningMauiBankingApp.Services
{
    public class ThemeManager : IThemeManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<ColorScheme, Type> _colorSchemeResources = new Dictionary<ColorScheme, Type>();

        public ColorScheme CurrentTheme => GetCurrentTheme();

        public ThemeManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _colorSchemeResources.Add(ColorScheme.Default, typeof(DefaultColorScheme));
            _colorSchemeResources.Add(ColorScheme.Alternative, typeof(AlternativeColorScheme));
        }

        public void SwitchThemeTo(ColorScheme colorScheme)
        {
            if (CurrentTheme == colorScheme)
                return;

            var globalMergedDictionaries = GetGlobalMergedDictionaries();
            var currentThemeResources = GetCurrentThemeResources();

            var currentResourcesIndex = globalMergedDictionaries.IndexOf(currentThemeResources);
            var newThemeResources = (ResourceDictionary) _serviceProvider.GetService(_colorSchemeResources[colorScheme]);
            globalMergedDictionaries.Insert(currentResourcesIndex, newThemeResources);
            globalMergedDictionaries.Remove(currentThemeResources);
        }

        private ColorScheme GetCurrentTheme()
        {
            var globalMergedDictionaries = GetGlobalMergedDictionaries();
            return _colorSchemeResources.First(x => globalMergedDictionaries.Any(y => x.Value == y.GetType())).Key;
        }

        private ResourceDictionary GetCurrentThemeResources()
        {
            var globalMergedDictionaries = GetGlobalMergedDictionaries();
            return globalMergedDictionaries.Single(x => _colorSchemeResources.Values.Contains(x.GetType()));
        }

        private ObservableCollection<ResourceDictionary> GetGlobalMergedDictionaries()
            => (ObservableCollection<ResourceDictionary>)App.Current.Resources.MergedDictionaries;
    }
}

