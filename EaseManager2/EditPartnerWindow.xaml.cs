using EaseManager2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class EditPartnerWindow : Window
    {
        private Partner _partner;
        private readonly string _connectionString;

        public EditPartnerWindow(Partner partner, string connectionString)
        {
            InitializeComponent();
            _partner = partner;
            DataContext = _partner;
            _connectionString = connectionString;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Partner SET Name = @Name, Director = @Director, Email = @Email, Phone = @Phone WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", _partner.Name);
                    command.Parameters.AddWithValue("@Director", _partner.Director);
                    command.Parameters.AddWithValue("@Email", _partner.Email);
                    command.Parameters.AddWithValue("@Phone", _partner.Phone);
                    command.Parameters.AddWithValue("@Id", _partner.Id);
                    command.ExecuteNonQuery();
                }
            }
            DialogResult = true;
            Close();
        }
    }
}
