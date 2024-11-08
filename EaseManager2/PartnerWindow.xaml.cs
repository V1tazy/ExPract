using EaseManager2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EaseManager2
{
    /// <summary>
    /// Логика взаимодействия для PartnerWindow.xaml
    /// </summary>
    public partial class PartnerWindow : Window
    {
        public Partner Partner { get; private set; }

        public PartnerWindow()
        {
            InitializeComponent();
            Partner = new Partner();
            this.DataContext = this;
        }


        public PartnerWindow(Partner partner) : this()
        {
            Partner = new Partner
            {
                Id = partner.Id,
                PartnerType = partner.PartnerType,
                Name = partner.Name,
                Director = partner.Director,
                Email = partner.Email,
                Phone = partner.Phone,
                Address = partner.Address,
                INN = partner.INN,
                Rating = partner.Rating
            };
            this.DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
        }
    }
}
