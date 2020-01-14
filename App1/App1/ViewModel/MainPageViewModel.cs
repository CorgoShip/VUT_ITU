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
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class MainPageViewModel : ReservationService
    { 

        //Seznam rezervaci
        public ObservableCollection<Reservation> seznamRezervaci { get; set; }

        public ObservableCollection<Reservation> MojeRezervace { get; set; }
        public ObservableCollection<Reservation> HistorieRezervaci { get; set; }

        //promena pro vyber zobrazovane stranky
        private readonly INavigation _navigation;

        //Prikazy
        public ICommand CreateModal1CMD => new Command(CreateModal1);

        public ICommand CreateModal2CMD => new Command(CreateModal2);
        public ICommand CreateHelpCMD => new Command(CreateHelp);

        public ICommand CreateHistorieCMD => new Command(CreateHistorie);

        public ICommand Delete => new Command(DeleteH);


        public ICommand Finish => new Command(FinishH);
        
        public ICommand Delete2 => new Command(AreUSure);

        public async void AreUSure(object p)
        {
            var result = await App.Current.MainPage.DisplayAlert("Pozor", "Opravdu chcete odstranit tuto jizdu?", "Ano", "Ne"); // since we are using async, we should specify the DisplayAlert as awaiting.
            if (result == true) // if it's equal to Ok
            {
                DeleteH(p);
            }
            else // if it's equal to Cancel
            {
                return; // just return to the page and do nothing.
            }
        }

        async void FinishH(object obj)
        {
            string result = await App.Current.MainPage.DisplayPromptAsync("Jizda uspesne dokoncena", "Problemy s vozidlem:", placeholder: "Zde zadejte poznámky k cestě");
            if (result == null)
            {
                return;
            }
           else
            {
                Reservation temp = new Reservation();
                temp = (Reservation)obj;
                temp.Comment = result;
                HistorieRezervaci.Add(temp);
                DeleteH(obj);
            }
        }

        async void DeleteH (object p)
        {
            Reservation temp = new Reservation();
            temp = (Reservation)p;

            if (temp.CreatedBy == "user1")
            {
                MojeRezervace.Remove((Reservation)p);
            }

            seznamRezervaci.Remove((Reservation)p);
  
        }

        async void CreateModal1()
        {
            ModalPage1 modal1 = new ModalPage1(seznamRezervaci,MojeRezervace);

            await this._navigation.PushModalAsync(modal1);
        }

        async void CreateModal2()
        {
            ModalPage2 modal2 = new ModalPage2(seznamRezervaci);

            await this._navigation.PushModalAsync(modal2);
        }

        async void CreateHelp()
        {
            HelpPage modal4 = new HelpPage(seznamRezervaci);
            await this._navigation.PushModalAsync(modal4);
            return; 
        }
        async void CreateHistorie()
        {
            ModalHistorie modal3 = new ModalHistorie(HistorieRezervaci);

            await this._navigation.PushModalAsync(modal3);
        }

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            seznamRezervaci = new ObservableCollection<Reservation>();
            HistorieRezervaci = new ObservableCollection<Reservation>();
            MojeRezervace = new ObservableCollection<Reservation>();

            // Tato data jsou pouze pro visualizaci
            Reservation temp = new Reservation();
            temp.Date = "8.12.2019"; 
            temp.Name = "Oprava serveru v Ostrave";
            temp.Time = "14:54";
            temp.Type = "1) Oprava Serveru";
            temp.Vehicle = "Skoda Octavia";
            temp.CreatedBy = "user1";

            MojeRezervace.Add(temp);  // simulovana prnvni rezervace
            seznamRezervaci.Add(temp);

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
