using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using App1.ResFormat;
using App1.Services;
using App1.View;
using App1;

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
        private readonly INavigation _navigation;

        public ICommand CreateModal1CMD => new Command(CreateModal1);

        async void CreateModal1()
        {
            ModalPage1 modal1 = new ModalPage1();

            await this._navigation.PushModalAsync(modal1);
        }

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            seznamRezervaci = new ObservableCollection<Reservation>();
            seznamAut = new ObservableCollection<string>();            
            //seznamRezervaci = GetReservationsAsync();


            seznamAut.Add("Oktavka");
            seznamAut.Add("Lambo");
            seznamAut.Add("Nafta");

            Reservation temp = new Reservation();
            temp.Date = "15.41.1447"; // simulovana prnvni rezervace
            temp.Name = "Rychla cesta";
            temp.Time = "14:54";
            temp.Type = "Oprava";
            temp.Vehicle = "Lexus";

            seznamRezervaci.Add(temp); // simulovana druha drzervace 

            temp.Date = "4.12.1998";
            temp.Name = "Nova cesta2";
            temp.Time = "18:21";
            temp.Type = "Kontrola Serveru";
            temp.Vehicle = "Lambo";

            seznamRezervaci.Add(temp);
        }
    }
}
