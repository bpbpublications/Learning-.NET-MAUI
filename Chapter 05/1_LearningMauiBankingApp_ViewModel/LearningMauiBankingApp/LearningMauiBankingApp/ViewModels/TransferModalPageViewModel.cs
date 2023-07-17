using System;
using LearningMauiBankingApp.Models;
using LearningMauiBankingApp.Tools;

namespace LearningMauiBankingApp.ViewModels
{
	public class TransferModalPageViewModel : NotifyPropertyChangedBase
    {
        private IEnumerable<BankCard> _cards;
        public IEnumerable<BankCard> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }
    }
}

