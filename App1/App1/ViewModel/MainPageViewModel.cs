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
using System.Diagnostics;

namespace App1.ViewModel
{
    public class MainPageViewModel : ReservationService
    { 
        public ObservableCollection<Reservation> seznamRezervaci { get; set; }

        private readonly INavigation _navigation;

        public ICommand CreateModal1CMD => new Command(CreateModal1);

        public ICommand Delete => new Command(DeleteH);

        async void DeleteH (object p){
            seznamRezervaci.Remove((Reservation)p);
        }

        async void CreateModal1()
        {
            ModalPage1 modal1 = new ModalPage1(seznamRezervaci);

            await this._navigation.PushModalAsync(modal1);
        }                

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            seznamRezervaci = new ObservableCollection<Reservation>();            

            // Tato data jsou pouze pro visualizaci
            Reservation temp = new Reservation();
            temp.Date = "8.12.2019"; 
            temp.Name = "Oprava serveru v Ostrave";
            temp.Time = "14:54";
            temp.Type = "1) Oprava Serveru";
            temp.Vehicle = "Skoda Octavia";
            temp.CreatedBy = "User1";

            seznamRezervaci.Add(temp);  // simulovana prnvni rezervace

            temp.Date = "12.12.2019";
            temp.Name = "Schuzka s FirmaXYZ";
            temp.Time = "12:21";
            temp.Type = "2) Schuzka se zakaznikem";
            temp.Vehicle = "VW Golf";
            temp.CreatedBy = "Zbyna";

            seznamRezervaci.Add(temp); // simulovana druha drzervace 
        }
    }
}
