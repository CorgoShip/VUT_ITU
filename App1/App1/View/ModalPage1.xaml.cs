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

        public string date { get; set; }
        public string time { get; set; }
        public string type { get; set; }
        public string vehicle { get; set; }
        public string name { get; set; }


        public ICommand DestroyModal1CMD => new Command(DestryModal1);

        async void DestryModal1()
        {
            await this.Navigation.PopModalAsync();
        }

        public ICommand AddRezervaceCMD => new Command(AddRezervace);

        public string novaRezervance { get; set; }

        public void AddRezervace()
        {
            Reservation temp = new Reservation();
            temp.Date = date;
            temp.Name = name;
            temp.Time = time;
            temp.Type = type;
            temp.Vehicle = vehicle;
            _seznamRezervaci.Add(temp);
            DestryModal1();
        }
    }
}