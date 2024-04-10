using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class OrdersForm : Window
{
    public OrdersForm()
    {
        InitializeComponent();
        string fullTableShow = "SELECT * FROM orders;";
        ShowTable(fullTableShow);
    }
    private List<Orders> orders;
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;
    private void ShowTable(string sql)
    {
        orders = new List<Orders>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var fullorder = new Orders()
            {
                ID = reader.GetInt32("ID"),
                ID_Member = reader.GetInt32("ID_Member"),
                ID_Catalog = reader.GetInt32("ID_Catalog"),
                Amount = reader.GetInt32("Amount")
            };
            orders.Add(fullorder);
        }
        conn.Close();
        OrderGrid.ItemsSource = orders;
    }
    private void BackToMenu(object? sender, RoutedEventArgs e)
    {
        MainMenu menu = new MainMenu();
        Close();
        menu.Show();
    }
}