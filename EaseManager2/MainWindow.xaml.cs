using EaseManager2.Models;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EaseManager2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=materials_sales_db;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
            LoadPartners();
        }

        private void LoadPartners()
        {
            var partners = new List<Partner>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Partner";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            partners.Add(new Partner
                            {
                                Id = reader.GetInt32(0),
                                PartnerType = reader.GetString(1),
                                Name = reader.GetString(2),
                                Director = reader.GetString(3),
                                Email = reader.GetString(4),
                                Phone = reader.GetString(5),
                                Address = reader.GetString(6),
                                Inn = reader.GetString(7),
                                Rating = reader.GetInt32(8)
                            });
                        }
                    }
                }
            }

            PartnersItemsControl.ItemsSource = partners;
        }

        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Partner partner)
            {
                // Вызовите форму для редактирования данных партнера и сохраните изменения
                EditPartnerWindow editWindow = new EditPartnerWindow(partner, ConnectionString);
                if (editWindow.ShowDialog() == true)
                {
                    LoadPartners();
                }
            }
        }

        private void DeletePartner_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Partner partner)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Partner WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", partner.Id);
                        command.ExecuteNonQuery();
                    }
                }
                LoadPartners();
            }
        }
    }

}