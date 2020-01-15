using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;
using App1.ResFormat;
using System.Windows.Input;
using System.Net.Http;
using System.Globalization;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage1 : ContentPage
    {
        private readonly ObservableCollection<Reservation> _seznamRezervaci;
        private readonly ObservableCollection<Reservation> _mojeRezervace;
        public ModalPage1(ObservableCollection<Reservation> seznamRezervaci, ObservableCollection<Reservation> mojeRezervace)
        {
            this.BindingContext = this;
            InitializeComponent();
            _seznamRezervaci = seznamRezervaci;
            _mojeRezervace = mojeRezervace;
            GetData();
            GetData2();
        }

        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public TimeSpan endTime { get; set; }
        public string type { get; set; }
        public string vehicle { get; set; }
        public string name { get; set; }
        public string creator { get; set; }

        public async Task GetData()
        {
            var result = await new HttpClient().GetAsync("https://gist.githubusercontent.com/CorgoShip/7f8c056ebab6b575efe8a2e8f356fd20/raw/1df9ec7c96ad2d28230775cf71367bd65c5242fc/CarList.txt");
            var text = await result.Content.ReadAsStringAsync();

            string[] cars = text.Split(',');
            foreach (var item in cars)
            {
                CarLsit.Add(item);
            }
        }

        public async Task GetData2()
        {
            var result = await new HttpClient().GetAsync("https://gist.githubusercontent.com/CorgoShip/7c1134535ca446acc779fa7a2327e59e/raw/3e34b0a396221f51ca8dd1e9f9df15e55f6726e8/TypeList");
            var text = await result.Content.ReadAsStringAsync();

            string[] types = text.Split(',');
            foreach (var item in types)
            {
                TypeList.Add(item);
            }
        }

        public ICommand DestroyModal1CMD => new Command(DestryModal1);

        async void DestryModal1()
        {
            await this.Navigation.PopModalAsync();
        }

        public ICommand AddRezervaceCMD => new Command(AddRezervace);

        public async void AddRezervace()
        {
            Reservation temp = new Reservation();
            temp.Date = date.ToShortDateString();
            temp.Name = name;
            temp.Time = time.ToString();
            temp.EndTime = endTime.ToString();
            temp.Type = type;
            temp.Vehicle = vehicle;
            temp.CreatedBy = creator;

            // proleze celou obsercoll a najde auto a cas
            foreach (var data in _seznamRezervaci)
            {
                if (data.Vehicle == vehicle)
                {
                    if (data.Date == temp.Date)
                    {
                        if (TimeSpan.ParseExact(temp.Time, @"hh\:mm\:ss", CultureInfo.InvariantCulture) >= TimeSpan.ParseExact(data.Time, @"hh\:mm\:ss", CultureInfo.InvariantCulture) &&
                            TimeSpan.ParseExact(temp.Time, @"hh\:mm\:ss", CultureInfo.InvariantCulture) <= TimeSpan.ParseExact(data.EndTime, @"hh\:mm\:ss", CultureInfo.InvariantCulture))
                            {
                            //  nedovoli auto vybrat
                            await DisplayAlert("Pozor", "Toto vozidlo je ve vybranem terminu obsazene", "OK");
                            return;
                        }
                    } 
                }
            }

            if (creator == "user1")
            {
                _mojeRezervace.Add(temp);
            }
            _seznamRezervaci.Add(temp);
            DestryModal1();
        }

        public ObservableCollection<string> CarLsit { get; set; } = new ObservableCollection<string>();//{"Skoda Octavia", "VW Golf", "VW Caddy", "VW Transporter"};
        public ObservableCollection<string> TypeList { get; set; } = new ObservableCollection<string>(); //{ "1) Oprava Serveru", "2) Schuzka se zakaznikem", "3) Interni IT", "4) Kontrola Serveru" };

    }
}