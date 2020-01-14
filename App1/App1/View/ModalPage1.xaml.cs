﻿using System;
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
        private readonly ObservableCollection<Reservation> _mojeRezervace;
        public ModalPage1(ObservableCollection<Reservation> seznamRezervaci, ObservableCollection<Reservation> mojeRezervace)
        {
            this.BindingContext = this;
            InitializeComponent();
            _seznamRezervaci = seznamRezervaci;
            _mojeRezervace = mojeRezervace;
        }

        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public TimeSpan endTime { get; set; }
        public string type { get; set; }
        public string vehicle { get; set; }
        public string name { get; set; }
        public string creator { get; set; }


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
            temp.EndTime = endTime.ToString();
            temp.Type = type;
            temp.Vehicle = vehicle;
            temp.CreatedBy = creator;

            if (creator == "user1")
            {
                _mojeRezervace.Add(temp);
            }
            _seznamRezervaci.Add(temp);
            DestryModal1();
        }


        //TODO
        public List<string> CarLsit { get; set; } = new List<string>(){"Skoda Octavia", "VW Golf", "VW Caddy", "VW Transporter"};
        public List<string> TypeList { get; set; } = new List<string>() { "1) Oprava Serveru", "2) Schuzka se zakaznikem", "3) Interni IT", "4) Kontrola Serveru" };

    }
}