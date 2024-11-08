using EaseManager2.Models;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace YourNamespace
{
    public class DatabaseService
    {
        private string connectionString;

        public DatabaseService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        public ObservableCollection<Partner> GetPartners()
        {
            var partners = new ObservableCollection<Partner>();
            string query = "SELECT * FROM Partner";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    partners.Add(new Partner
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        PartnerType = reader["partner_type"].ToString(),
                        Name = reader["name"].ToString(),
                        Director = reader["director"].ToString(),
                        Email = reader["email"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        INN = reader["inn"].ToString(),
                        Rating = Convert.ToInt32(reader["rating"])
                    });
                }
            }

            return partners;
        }

        public void AddPartner(Partner partner)
        {
            string query = @"INSERT INTO Partner (partner_type, name, director, email, phone, address, inn, rating)
                             VALUES (@PartnerType, @Name, @Director, @Email, @Phone, @Address, @INN, @Rating)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PartnerType", partner.PartnerType);
                command.Parameters.AddWithValue("@Name", partner.Name);
                command.Parameters.AddWithValue("@Director", partner.Director);
                command.Parameters.AddWithValue("@Email", partner.Email);
                command.Parameters.AddWithValue("@Phone", partner.Phone);
                command.Parameters.AddWithValue("@Address", partner.Address);
                command.Parameters.AddWithValue("@INN", partner.INN);
                command.Parameters.AddWithValue("@Rating", partner.Rating);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdatePartner(Partner partner)
        {
            string query = @"UPDATE Partner 
                             SET partner_type = @PartnerType,
                                 name = @Name,
                                 director = @Director,
                                 email = @Email,
                                 phone = @Phone,
                                 address = @Address,
                                 inn = @INN,
                                 rating = @Rating
                             WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PartnerType", partner.PartnerType);
                command.Parameters.AddWithValue("@Name", partner.Name);
                command.Parameters.AddWithValue("@Director", partner.Director);
                command.Parameters.AddWithValue("@Email", partner.Email);
                command.Parameters.AddWithValue("@Phone", partner.Phone);
                command.Parameters.AddWithValue("@Address", partner.Address);
                command.Parameters.AddWithValue("@INN", partner.INN);
                command.Parameters.AddWithValue("@Rating", partner.Rating);
                command.Parameters.AddWithValue("@Id", partner.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePartner(int partnerId)
        {
            string query = "DELETE FROM Partner WHERE id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", partnerId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
