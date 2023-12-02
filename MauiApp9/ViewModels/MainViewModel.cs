using System;
using System.ComponentModel;
using System.Windows.Input;
using MauiApp9.Models;
using MauiApp9.Views;
using Microsoft.Maui.Controls;

namespace MauiApp9.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CalculadoraPropina calculadoraPropina;
        private ContributionViewModel contributionViewModel;


        public MainViewModel()
        {
            calculadoraPropina = new CalculadoraPropina();
            contributionViewModel = new ContributionViewModel();
            contributionViewModel.UpdateNumberOfDiners(NumeroPersonas);


        }

        private int numeroPersonas;
        public int NumeroPersonas
        {
            get => numeroPersonas;
            set
            {
                if (numeroPersonas != value)
                {
                    numeroPersonas = value;
                    OnPropertyChanged(nameof(NumeroPersonas));
                    calculadoraPropina.NumeroPersonas = value;
                    contributionViewModel.UpdateNumberOfDiners(value);
                }
            }
        }

        private string textoPropina;
        public string TextoPropina
        {
            get => textoPropina;
            set
            {
                textoPropina = value;
                OnPropertyChanged(nameof(TextoPropina));
            }
        }

        private string textoTotalCuenta;
        public string TextoTotalCuenta
        {
            get => textoTotalCuenta;
            set
            {
                textoTotalCuenta = value;
                OnPropertyChanged(nameof(TextoTotalCuenta));
            }
        }

        public decimal ImporteCuenta
        {
            get => calculadoraPropina.ImporteCuenta;
            set
            {
                calculadoraPropina.ImporteCuenta = value;
                OnPropertyChanged(nameof(ImporteCuenta));
            }
        }

        public decimal PorcentajePropina
        {
            get => calculadoraPropina.PorcentajePropina;
            set
            {
                calculadoraPropina.PorcentajePropina = value;
                OnPropertyChanged(nameof(PorcentajePropina));
            }
        }

        public ICommand IncrementarPersonasCommand => new Command(IncrementarPersonas);
        public ICommand DecrementarPersonasCommand => new Command(DecrementarPersonas);
        public ICommand Aplicar8PorcientoCommand => new Command(Aplicar8Porciento);
        public ICommand Aplicar10PorcientoCommand => new Command(Aplicar10Porciento);
        public ICommand Aplicar12_5PorcientoCommand => new Command(Aplicar12_5Porciento);
        public ICommand Aplicar15PorcientoCommand => new Command(Aplicar15Porciento);
        public ICommand CalcularCommand => new Command(Calcular);
        public ICommand LimpiarCommand => new Command(Limpiar);

        private void IncrementarPersonas()
        {
            NumeroPersonas++;
        }

        private void DecrementarPersonas()
        {
            if (NumeroPersonas > 1)
                NumeroPersonas--;
        }

        private void Aplicar8Porciento()
        {
            PorcentajePropina = 0.08M;
            Calcular();
        }

        private void Aplicar10Porciento()
        {
            PorcentajePropina = 0.10M;
            Calcular();
        }

        private void Aplicar12_5Porciento()
        {
            PorcentajePropina = 0.125M;
            Calcular();
        }

        private void Aplicar15Porciento()
        {
            PorcentajePropina = 0.15M;
            Calcular();
        }

        private void Calcular()
        {
            decimal propina = calculadoraPropina.CalcularPropina();
            decimal total = calculadoraPropina.ImporteCuenta + propina;
            decimal propinaPorPersona = propina / calculadoraPropina.NumeroPersonas;
            decimal totalPorPersona = total / calculadoraPropina.NumeroPersonas;

            string resultados = $"Importe de la propina: {propina}\n" +
                                $"Propina por persona: {propinaPorPersona}\n" +
                                $"Importe total: {total}\n" +
                                $"Importe por persona: {totalPorPersona}";

            Resultados = resultados;

            TextoPropina = $"Propina: {propina}";
            TextoTotalCuenta = $"Total de la cuenta: {total}";
        }

        private void Limpiar()
        {
            ImporteCuenta = 0;
            NumeroPersonas = 1;
            Resultados = "";
        }

        private string resultados;
        public string Resultados
        {
            get => resultados;
            set
            {
                resultados = value;
                OnPropertyChanged(nameof(Resultados));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
