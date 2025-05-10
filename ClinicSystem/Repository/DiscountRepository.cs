using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicSystem.Helpers;
using ClinicSystem.UserLoginForm;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ClinicSystem.Repository
{
    public class DiscountRepository
    {
        public List<Discount> getDiscounts()
        {
            List<Discount> list = new List<Discount>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM discount_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Discount discount = EntityMapping.GetDiscount(reader);
                                list.Add(discount);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON getDiscount()" + ex.Message);
            }
            return list;
        }

        public Discount getDiscountsbyType(string type)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM discount_tbl WHERE discounttype = @discounttype", conn))
                    {
                        command.Parameters.AddWithValue("discounttype", type);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return EntityMapping.GetDiscount(reader);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON getDiscount()" + ex.Message);
            }
            return null;
        }
    }
}
