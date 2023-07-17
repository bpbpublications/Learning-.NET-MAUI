using System;
using LearningMauiBankingApp.Enums;

namespace LearningMauiBankingApp.Interfaces
{
	public interface IThemeManager
	{
        ColorScheme CurrentTheme { get; }
        void SwitchThemeTo(ColorScheme colorScheme);
    }
}