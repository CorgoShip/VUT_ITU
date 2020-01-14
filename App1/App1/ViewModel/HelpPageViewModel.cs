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
    public class HelpPageViewModel : ReservationService
    {

        //Seznam rezervaci
        public ObservableCollection<Reservation> seznamRezervaci { get; set; }

        //promena pro vyber zobrazovane stranky
        private readonly INavigation _navigation;
        //Prikazy
        public ICommand CreateHelpCMD0 => new Command(CreateHelp0);
        public ICommand CreateHelpCMD1 => new Command(CreateHelpShowAll);
        public ICommand CreateHelpCMD2 => new Command(HelpHistory);

        public ICommand CreateHelpCMD3 => new Command(HelpDelete);
        public ICommand CreateHelpCMD4 => new Command(HelpFinish);

        public ICommand CreateHelpCMD5 => new Command(HelpAdd);



        async void  CreateHelp0()
        {
            await _navigation.PopModalAsync();
        }

        void CreateHelpShowAll()
        {
            
        }

        void HelpHistory()
        {

        }

        void HelpDelete()
        {

        }

        void HelpFinish()
        {

        }

        void HelpAdd()
        {

        }
    }
}
