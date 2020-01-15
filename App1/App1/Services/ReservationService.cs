using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using App1.ResFormat;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using App1.Services;
using System.Linq;

namespace App1.Services
{
    public interface IReservationService
    {
        Task<ObservableCollection<Reservation>> GetReservationsAsync();
    }

    public class ReservationService
    {
        public ObservableCollection<Reservation> GetReservationsAsync()
        {
            //await Task.Delay(500);
            String text = "";

            ObservableCollection<Reservation> rezervace = new ObservableCollection<Reservation>();

            var dataFilePath = $@"Data/Reservations.txt";
            if (!File.Exists(dataFilePath)) return rezervace;

            text = File.ReadAllText(dataFilePath);

            string[] reservations = text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in reservations)
            {
                Reservation temp = new Reservation();
                string[] attributes = line.Split(' ');
                temp.Name = attributes[0];
                temp.Type = attributes[1];
                temp.Vehicle = attributes[2];
                temp.Date = attributes[3];
                temp.Time = attributes[4];
                rezervace.Add(temp);
               
            }

            return rezervace;
        }
    }

}