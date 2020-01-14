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
    public partial class HelpPage : ContentPage
    {
        public ICommand CreateHelpCMD0 => new Command(CreateHelp0);
        public ICommand CreateHelpCMD1 => new Command(CreateHelpShowAll);
        public ICommand CreateHelpCMD2 => new Command(HelpHistory);

        public ICommand CreateHelpCMD3 => new Command(HelpDelete);
        public ICommand CreateHelpCMD4 => new Command(HelpFinish);

        public ICommand CreateHelpCMD5 => new Command(HelpAdd);



        async void CreateHelp0()
        {
            await this.Navigation.PopModalAsync();
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