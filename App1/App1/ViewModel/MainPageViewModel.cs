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
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class MainPageViewModel : ReservationService
    { 

        //Seznam rezervaci
        public ObservableCollection<Reservation> seznamRezervaci { get; set; }

        //promena pro vyber zobrazovane stranky
        private readonly INavigation _navigation;

        //Prikazy
        public ICommand CreateModal1CMD => new Command(CreateModal1);

        public ICommand CreateModal2CMD => new Command(CreateModal2);

        public ICommand Delete => new Command(DeleteH);

        public ICommand Finish => new Command(FinishH);

        async void FinishH(object obj)
        {
            string result = await App.Current.MainPage.DisplayPromptAsync("Jizda uspesne dokoncena", "Problemy s vozidlem:", placeholder: "S vozidlem nebyly zadne problemy");
            DeleteH(obj);
        }

        async void DeleteH (object p)
        {
            seznamRezervaci.Remove((Reservation)p);
        }

        async void CreateModal1()
        {
            ModalPage1 modal1 = new ModalPage1(seznamRezervaci);

            await this._navigation.PushModalAsync(modal1);
        }

        async void CreateModal2()
        {
            ModalPage2 modal2 = new ModalPage2(seznamRezervaci);

            await this._navigation.PushModalAsync(modal2);
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

            seznamRezervaci.Add(temp); // simulovana druha rezervace 
        }
    }
}
