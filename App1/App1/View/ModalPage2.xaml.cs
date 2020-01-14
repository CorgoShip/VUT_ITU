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

        public ObservableCollection<Reservation> seznamRezervaci2 { get; set; }
        public ObservableCollection<Reservation> DescOrderedList { get; set; }
        public ModalPage2(ObservableCollection<Reservation> seznamRezervaci)
        {
            
            InitializeComponent();
            seznamRezervaci2 = seznamRezervaci;
            DescOrderedList = new ObservableCollection<Reservation>(seznamRezervaci.OrderBy(x => x.Date));

            seznamRezervaci2 = DescOrderedList;
            this.BindingContext = this;

        }

        public ICommand DestroyModal2CMD => new Command(DestroyModal2);

        async void DestroyModal2()
        {
            await this.Navigation.PopModalAsync();
        }
    }
}