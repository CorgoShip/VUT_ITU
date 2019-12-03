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
    public class MainPageViewModel : ReservationService
    {
        public ICommand AddRezervaceCMD => new Command(AddCarRes);

        public ObservableCollection<Reservation> seznamRezervaci { get; set; }
        public ObservableCollection<string> seznamAut { get; set; }

        public string novaRezervance { get; set; }

        public void AddRezervace()
        {
            //seznamRezervaci.Add(novaRezervance);
        }

        public void AddCarRes()
        {
            seznamAut.Add(novaRezervance);
        }
        
        

        public MainPageViewModel()
        {
            seznamRezervaci = new ObservableCollection<Reservation>();
            seznamAut = new ObservableCollection<string>();            
            //seznamRezervaci = GetReservationsAsync();

            seznamAut.Add("Oktavka");
            seznamAut.Add("Lambo");
            seznamAut.Add("Nafta");

            Reservation temp = new Reservation();
            temp.Date = "15.41.1447";
            temp.Name = "Rychla cesta";
            temp.Time = "14:54";
            temp.Type = "Oprava";
            temp.Vehicle = "Lexus";

            seznamRezervaci.Add(temp);
        }
    }
}
