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
    public partial class HelpModal : ContentPage
    {
        public HelpModal()
        {
            this.BindingContext = this;
            InitializeComponent();
        }

        public ICommand CreateHelpCMD1 => new Command(CreateHelpShowAll);
        public ICommand CreateHelpCMD2 => new Command(HelpHistory);

        public ICommand CreateHelpCMD3 => new Command(HelpDelete);
        public ICommand CreateHelpCMD4 => new Command(HelpFinish);

        public ICommand CreateHelpCMD5 => new Command(HelpAdd);

        public ICommand DestroyHelpCMD => new Command(DestroyModal4);

        async void DestroyModal4()
        {
            await this.Navigation.PopModalAsync();
        }


        async void CreateHelpShowAll()
        {
            await App.Current.MainPage.DisplayAlert("Vsechny rezervace", "Zobrazi vsechny rezervace, od vsetkych uzivatelov.", "Ok");
        }

        async void HelpHistory()
        {
            await App.Current.MainPage.DisplayAlert("Historie rezervaci", "Zobrazi historiu jazd od aktualneho uzivatela. Po kliknuti na ? zobrazi spravu s ktorou sa jazda skoncila.", "Ok");
        }

        async void HelpDelete()
        {
            await App.Current.MainPage.DisplayAlert("Delete", "Odstrani planovanu jazdu. " +
                "Po stlaceni Ne jazda ostava planovana. " +
                "Po stlaceni Ano jazda je odstranena.", "Ok");
        }

        async void HelpFinish()
        {
            await App.Current.MainPage.DisplayAlert("Finish", "Sluzi na ukoncenie jazdy. Po kliknuti je uzivatel vyzvany aby zadal, ake boli problemy s autom. Potvrdí to kliknutim na tlacidlo OK. Pre vratenie sa (a neukoncenie jazdy) sluzi tlacidlo Cancel. ", "Ok");
        }

        async void HelpAdd()
        {
            await App.Current.MainPage.DisplayAlert("Rezervovat", "Po kliknuti sa uzivatelovi otvori formular, kam moze zadat udaje potrebne pre novu jazdu. ", "Ok");
        }
    }
}