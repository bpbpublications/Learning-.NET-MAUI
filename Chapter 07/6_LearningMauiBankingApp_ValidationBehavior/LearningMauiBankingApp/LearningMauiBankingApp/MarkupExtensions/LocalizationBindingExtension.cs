using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.MarkupExtensions
{
    [ContentProperty(nameof(Key))]
    public class LocalizationBindingExtension : IMarkupExtension<BindingBase>
    {
        public string Key { get; set; }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var localizationManager = StrongContainer.ServiceProvider.GetService<ILocalizationManager>();
            return new Binding
            {
                Path = $"[{Key}]",
                Source = localizationManager,
                Mode = BindingMode.OneWay
            };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}

