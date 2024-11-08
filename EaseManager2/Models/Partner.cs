using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaseManager2.Models
{
    public class Partner : INotifyPropertyChanged
    {
        private int id;
        private string partnerType;
        private string name;
        private string director;
        private string email;
        private string phone;
        private string address;
        private string inn;
        private int rating;

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string PartnerType
        {
            get => partnerType;
            set { partnerType = value; OnPropertyChanged(nameof(PartnerType)); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Director
        {
            get => director;
            set { director = value; OnPropertyChanged(nameof(Director)); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        public string Address
        {
            get => address;
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }

        public string INN
        {
            get => inn;
            set { inn = value; OnPropertyChanged(nameof(INN)); }
        }

        public int Rating
        {
            get => rating;
            set { rating = value; OnPropertyChanged(nameof(Rating)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
