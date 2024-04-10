using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class CatalogForm : Window
{
    public CatalogForm()
    {
        InitializeComponent();
        string fullTableShow = "SELECT * FROM catalog;";
        ShowTable(fullTableShow);
    }

    private List<Catalog> catalog;
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;

    private void ShowTable(string sql)
    {
        catalog = new List<Catalog>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var fullcatalog = new Catalog()
            {
                ID = reader.GetInt32("ID"),
                Name = reader.GetString("Name"),
                Price = reader.GetInt32("Price")
            };
            catalog.Add(fullcatalog);
        }
        conn.Close();
        CatalogGrid.ItemsSource = catalog;
    }

private void BackToMenu(object? sender, RoutedEventArgs e)
    {
        MainMenu menu = new MainMenu();
        Close();
        menu.Show();
    }

    private void SearchTextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var ctlg = catalog;
        ctlg = ctlg.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
        CatalogGrid.ItemsSource = ctlg;
    }
}