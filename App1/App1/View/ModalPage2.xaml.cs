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
    public partial class ModalPage2 : ContentPage
    {
        private readonly ObservableCollection<Reservation> _seznamRezervaci;
        public ModalPage2(ObservableCollection<Reservation> seznamRezervaci)
        {
            this.BindingContext = this;
            InitializeComponent();
            _seznamRezervaci = seznamRezervaci;
        }
    }
}