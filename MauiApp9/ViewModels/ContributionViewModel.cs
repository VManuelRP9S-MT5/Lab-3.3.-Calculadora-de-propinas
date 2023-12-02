using System.ComponentModel;

namespace MauiApp9.ViewModels
{
    public class ContributionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int numberOfDiners;
        public int NumberOfDiners
        {
            get => numberOfDiners;
            set
            {
                if (value != numberOfDiners)
                {
                    numberOfDiners = value;
                    OnPropertyChanged(nameof(NumberOfDiners));
                    UpdateContributionAmount();
                }
            }
        }

        private decimal contributionAmount;
        public decimal ContributionAmount
        {
            get => contributionAmount;
            set
            {
                if (value != contributionAmount)
                {
                    contributionAmount = value;
                    OnPropertyChanged(nameof(ContributionAmount));
                }
            }
        }

        private void UpdateContributionAmount()
        {
            // Lógica para obtener la cantidad de contribución basada en el número de comensales
            // Utiliza el número de comensales de la Calculadora de Propinas
            ContributionAmount = 100 / NumberOfDiners;
        }

        public void UpdateNumberOfDiners(int numberOfDinersFromMainViewModel)
        {
            NumberOfDiners = numberOfDinersFromMainViewModel;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Resto del código de ContributionViewModel si existe
        // Asegúrate de incluir cualquier otra lógica o propiedades aquí
    }
}
