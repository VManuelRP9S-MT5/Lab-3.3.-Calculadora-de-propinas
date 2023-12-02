using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace MauiApp9.Models
{
    public class CalculadoraPropina : INotifyPropertyChanged
    {
        private decimal importeCuenta = 0;
        private int numeroPersonas = 1;
        private decimal porcentajePropina; // Sin valor inicial

        public decimal ImporteCuenta
        {
            get => importeCuenta;
            set
            {
                importeCuenta = value;
                OnPropertyChanged(nameof(ImporteCuenta));
            }
        }

        public int NumeroPersonas
        {
            get => numeroPersonas;
            set
            {
                numeroPersonas = value;
                OnPropertyChanged(nameof(NumeroPersonas));
            }
        }

        public decimal PorcentajePropina
        {
            get => porcentajePropina;
            set
            {
                if (porcentajePropina != value)
                {
                    porcentajePropina = value;
                    OnPropertyChanged(nameof(PorcentajePropina));
                }
            }
        }

        public decimal CalcularPropina()
        {
            decimal propina = ImporteCuenta * PorcentajePropina; // Solo el porcentaje, no se divide por 100
            return propina;
        }

        public decimal CalcularTotal()
        {
            decimal propina = CalcularPropina();
            decimal total = ImporteCuenta + propina;
            return total;
        }

        public decimal PropinaPorPersona()
        {
            decimal propina = CalcularPropina();
            decimal propinaPersona = propina / NumeroPersonas;
            return propinaPersona;
        }

        public decimal TotalPorPersona()
        {
            decimal total = CalcularTotal();
            decimal totalPersona = total / NumeroPersonas;
            return totalPersona;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
