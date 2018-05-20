using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClothWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuriy\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");

        private ObservableCollection<string> _locations;
        public ObservableCollection<string> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Locations"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Locations = new ObservableCollection<string>();
            connection.Open();
            string qwery = $"SELECT Name FROM Product";
            SqlCommand command = new SqlCommand(qwery, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                Locations.Add(sqlReader["Name, IdProduct"].ToString());
                
            }
            connection.Close();
            sqlReader.Close();
           
            // Load our locations from the database here
            // You can instead populate yours from SQL
           
            // Now your combobox should be populated
        }
    }
}
