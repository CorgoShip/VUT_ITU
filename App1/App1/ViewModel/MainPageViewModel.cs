using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace App1.ViewModel
{
    public class MainPageViewModel
    {
        public ICommand AddRezervaceCMD => new Command(AddRezervace);
        public ObservableCollection<string> Rezervace { get; set; }

        public string novaRezervance { get; set; }

        public MainPageViewModel()
        {
            Rezervace = new ObservableCollection<string>();

            Rezervace.Add("Oktavka do Ruska");
            Rezervace.Add("Audi do Nemecka");
            Rezervace.Add("Lambo do Brna");

        }

        public void AddRezervace()
        {
            Rezervace.Add(novaRezervance);
        }
    }
}
