using Microsoft.Data.SqlClient;
using SfDataGridSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class OrderInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OrderData orderData;

        private ObservableCollection<Order> orderInfo;
        public ObservableCollection<Order> OrderInfo
        {
            get
            {
                return orderInfo;
            }
            set
            {
                this.orderInfo = value;
                NotifyPropertyChanged(nameof(OrderInfo));
            }
        }


        public OrderInfoViewModel()
        {
            orderInfo = new ObservableCollection<Order>();
            orderData = new OrderData();
            GenerateData();
        }

        public async void GenerateData()
        {
            IEnumerable<Order> data = await orderData.GetOrdersAsync();
            foreach (var item in data)
            {
                orderInfo.Add(item);
            }
        }
    }

    public class OrderData
    {
        //TODO: Enter the connectionstring of database
        // Please change the path according to your location on your device.
        public string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Support\August Support\PagingOnDemandPaging\SfDataGridSample_1667a2fd\SfDataGridSample\App_Data\NORTHWND.MDF"";Integrated Security=True;Connect Timeout=30";
        public async Task<List<Order>> GetOrdersAsync()
        {
            //Create query to fetch data from database
            string Query = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
            List<Order>? Orders = null;
            //Create SQL Connection
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                //Using SqlDataAdapter and Query create connection with database 
                SqlDataAdapter Adapter = new SqlDataAdapter(Query, Connection);
                DataSet Data = new DataSet();
                Connection.Open();
                // Using SqlDataAdapter, process the query string and fill the data into the dataset
                Adapter.Fill(Data);
                //Cast the data fetched from SqlDataAdapter to List<T>
                Orders = Data.Tables[0].AsEnumerable().Select(r => new Order
                {
                    OrderID = r.Field<int>("OrderID"),
                    CustomerID = r.Field<string>("CustomerID"),
                    EmployeeID = r.Field<int>("EmployeeID"),
                    ShipCity = r.Field<string>("ShipCity"),
                    Freight = r.Field<decimal>("Freight")
                }).ToList();
                Connection.Close();
            }
            return Orders;
        }        
    }

}
