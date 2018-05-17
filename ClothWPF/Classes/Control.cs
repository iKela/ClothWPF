using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ClothWPF.Classes
{
    //
    //organized working class
    //
    public class Control
    {
        int KodProductu;

        SqlConnection connection = new SqlConnection("connection string");
        private void UpdateProduct(object sender, EventArgs e)
        {
            string query = "select * from Product";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            DataTable dt2 = new DataTable("Product");
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            for (int i = 0; i < sqlReader.FieldCount; i++)
            {
                DataColumn col = new DataColumn(sqlReader.GetName(i), sqlReader.GetFieldType(i));
                dt2.Columns.Add(col);
            }
            while (sqlReader.Read())
            {
                DataRow row = dt2.NewRow();
                for (int i = 0; i < sqlReader.FieldCount; i++)
                {
                    row[i] = sqlReader[i];
                }
                dt2.Rows.Add(row);
            }

            System.Windows.Controls.DataGrid.DataSource = dt2;
            DataGrid.Columns[0].Visible = false;
            sqlReader.Close();
            connection.Close();
        }
        public void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KodProductu = Convert.ToInt32(DataGrid.SelectedRows[0].Cells[0].Value);
        }
        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGrid.SelectedRows.Count == 0) throw new Exception("Продукт не вказаний, виберiть будь-ласка продукт!");
                else
                {
                    connection.Open();
                    string qwery = $"INSERT into Product(KodProductu, Name, Price, Metric, Madein)" +
                        $"VALUES('{KodProductu}', '{Name}', '{Price}', '{Metric}', '{Madein}')";
                    SqlCommand command = new SqlCommand(qwery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Додано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void BTN_Update_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                string query =
                     "update Product " + $"set Name = N'{NameTextBox.Text}', " +
                     $"Price = N'{PriceTextBox.Text}', " + $"Metric = '{MetricTextBox.Text}', " + $"Madein = '{Madein}'" + $"where KodProductu = {KodProductu}";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                string query = $"delete from Auto where id = {KodProductu}";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

