using System;
namespace LearningMauiBankingApp.Triggers
{
	public class FadeTriggerAction : TriggerAction<VisualElement>
    {
		public double TargetOpacity { get; set; }

        protected override void Invoke(VisualElement sender)
        {
            sender.FadeTo(TargetOpacity, 500);
        }
    }
}

