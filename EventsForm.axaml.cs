using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class EventsForm : Window
{
    public EventsForm()
    {
        InitializeComponent();
        string fullTableShow = "SELECT * FROM events;";
        ShowTable(fullTableShow);
    }
    private List<Events> events;
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;
    private void ShowTable(string sql)
    {
        events = new List<Events>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var fullevents = new Events()
            {
                ID = reader.GetInt32("ID"),
                Name = reader.GetString("Name"),
                ID_Type = reader.GetInt32("ID_Type"),
                Description = reader.GetString("Description")
            };
            events.Add(fullevents);
        }
        conn.Close();
        EventsGrid.ItemsSource = events;
    }
    private void BackToMenu(object? sender, RoutedEventArgs e)
    {
        MainMenu menu = new MainMenu();
        Close();
        menu.Show();
    }

    private void SearchTextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var evnts = events;
        evnts = evnts.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
        EventsGrid.ItemsSource = evnts;
    }
}