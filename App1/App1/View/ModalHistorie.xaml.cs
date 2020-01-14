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

using App1.Services;
using App1.View;
using App1;


namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalHistorie : ContentPage
    {
        public ObservableCollection<Reservation> seznamHistorie2 { get; set; }
        public ModalHistorie(ObservableCollection<Reservation> seznamHistorie)
        {

            InitializeComponent();
            seznamHistorie2 = seznamHistorie;
            this.BindingContext = this;
        }

        public ICommand DestroyModal3CMD => new Command(DestroyModal3);

        public ICommand ShowCommentCMD => new Command(ShowComment);

        async void DestroyModal3()
        {
            await this.Navigation.PopModalAsync();
        }


        async void ShowComment(object p)
        {
            Reservation temp = new Reservation();
            temp = (Reservation)p;
            await App.Current.MainPage.DisplayAlert("Poznamka:", temp.Comment, "Ok"); // since we are using async, we should specify the DisplayAlert as awaiting.
        }
    }
}