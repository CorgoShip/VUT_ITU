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

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage1 : ContentPage
    {
        private readonly ObservableCollection<Reservation> _seznamRezervaci;
        public ModalPage1(ObservableCollection<Reservation> seznamRezervaci)
        {
            this.BindingContext = this;
            InitializeComponent();
            _seznamRezervaci = seznamRezervaci;            
        }

        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public string type { get; set; }
        public string vehicle { get; set; }
        public string name { get; set; }


        public ICommand DestroyModal1CMD => new Command(DestryModal1);

        async void DestryModal1()
        {
            await this.Navigation.PopModalAsync();
        }

        public ICommand AddRezervaceCMD => new Command(AddRezervace);

        public void AddRezervace()
        {
            Reservation temp = new Reservation();
            temp.Date = date.ToShortDateString();
            temp.Name = name;
            temp.Time = time.ToString();
            temp.Type = type;
            temp.Vehicle = vehicle;
            _seznamRezervaci.Add(temp);
            DestryModal1();
        }

        public List<string> CarLsit { get; set; } = new List<string>(){"Skoda Octavia", "VW Golf", "VW Caddy", "VW Transporter"};
        public List<string> TypeList { get; set; } = new List<string>() { "1) Oprava Serveru", "2) Schuzka se zakaznikem", "3) Interni IT", "4) Kontrola Serveru" };

    }
}