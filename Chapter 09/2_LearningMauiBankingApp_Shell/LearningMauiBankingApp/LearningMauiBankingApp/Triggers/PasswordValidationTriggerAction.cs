using System;
namespace LearningMauiBankingApp.Triggers
{
    public class PasswordValidationTriggerAction : TriggerAction<Entry>
    {
        public VisualElement ElementToDisable { get; set; }

        protected override void Invoke(Entry sender)
        {
            ElementToDisable.IsEnabled = sender.Text.Length >= 8;
        }
    }
}

