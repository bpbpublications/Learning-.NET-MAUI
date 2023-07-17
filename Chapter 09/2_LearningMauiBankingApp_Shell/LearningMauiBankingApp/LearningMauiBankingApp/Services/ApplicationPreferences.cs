using LearningMauiBankingApp.Interfaces;

namespace LearningMauiBankingApp.Services
{
	public class ApplicationPreferences : IApplicationPreferences
	{
        private readonly IPreferences _preferences;

        public ApplicationPreferences(IPreferences preferences)
		{
            _preferences = preferences;
        }

        public string Username
        {
            get => _preferences.Get(nameof(Username), string.Empty);
            set => _preferences.Set(nameof(Username), value);
        }
    }
}