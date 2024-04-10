using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class StaffForm : Window
{
    public StaffForm()
    {
        InitializeComponent();
        string fullTableShow = "SELECT * FROM staff;";
        ShowTable(fullTableShow);
    }
    private List<Staff> staff;
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;
    private void ShowTable(string sql)
    {
        staff = new List<Staff>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var fullstaff = new Staff()
            {
                ID = reader.GetInt32("ID"),
                Surname = reader.GetString("Surname"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description")
            };
            staff.Add(fullstaff);
        }
        conn.Close();
        StaffGrid.ItemsSource = staff;
    }
    private void BackToMenu(object? sender, RoutedEventArgs e)
    {
        MainMenu menu = new MainMenu();
        Close();
        menu.Show();
    }

    private void SearchTextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var stf = staff;
        stf = stf.Where(x => x.Description.Contains(SearchTextBox.Text)).ToList();
        StaffGrid.ItemsSource = stf;
    }
}