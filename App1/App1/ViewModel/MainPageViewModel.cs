using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using App1.ResFormat;
using App1.Services;

namespace App1.ViewModel
{
    public class MainPageViewModel
    {
        //public ICommand AddRezervaceCMD => new Command(AddRezervace);

        public ObservableCollection<Reservation> seznamRezervaci { get; set; }
        public ObservableCollection<string> seznamAut { get; set; }

        //public string novaRezervance { get; set; }

        public void AddRezervace()
        {
            //seznamRezervaci.Add(novaRezervance);
        }
        
        

        public MainPageViewModel()
        {
            seznamRezervaci = new ObservableCollection<Reservation>();
            
        }
    }
}
