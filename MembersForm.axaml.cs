using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class MembersForm : Window
{
    public MembersForm()
    {
        InitializeComponent();
        string fullTableShow = "SELECT * FROM members;";
        ShowTable(fullTableShow);
        FiltrTable();
    }
    private List<Members> memberlist;
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;
    private void ShowTable(string sql)
    {
        memberlist = new List<Members>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentMembers = new Members()
            {
                ID = reader.GetInt32("ID"),
                Surname  = reader.GetString("Surname"),
                Name = reader.GetString("Name"),
                Age = reader.GetInt32("Age"),
                Phone = reader.GetString("Phone"),
                Adress = reader.GetString("Adress"),
                ID_Squad = reader.GetInt32("ID_Squad")
            };
            memberlist.Add(currentMembers);
        }
        conn.Close();
        MemberGrid.ItemsSource = memberlist;
    }
    private void FiltrTable()
    {
        memberlist = new List<Members>();
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand("SELECT * FROM Members", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentMembers = new Members()
            {
                ID = reader.GetInt32("ID"),
                Surname  = reader.GetString("Surname"),
                Name = reader.GetString("Name"),
                ID_Squad = reader.GetInt32("ID_Squad"),
                Age = reader.GetInt32("Age"),
                Phone = reader.GetString("Phone"),
                Adress = reader.GetString("Adress")
            };
            memberlist.Add(currentMembers);
        }
        conn.Close();
        var typecmb = this.Find<ComboBox>(name:"FiltrComboBox");
        typecmb.ItemsSource = memberlist;
    }

    private void FiltrTable_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var TypeCmB = (ComboBox)sender;
        var currentMember = TypeCmB.SelectedItem as Members;
        var fltrmember = memberlist
            .Where(x => x.ID == currentMember.ID)
            .ToList();
        MemberGrid.ItemsSource = fltrmember;
    }

    private void SearchTextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var mbr = memberlist;
        mbr = mbr.Where(x => x.Surname.Contains(SearchTextBox.Text)).ToList();
        MemberGrid.ItemsSource = mbr;
    }

    private void ResetTable_OnClick(object? sender, RoutedEventArgs e)
    {
        SearchTextBox.Text = string.Empty;
        string fullTableShow = "SELECT * FROM members;";
        ShowTable(fullTableShow);
    }

    private void AddData(object? sender, RoutedEventArgs e)
    {
        Members newMember = new Members();
        RSOpracAPP.AddUpdate addWindow = new AddUpdate(newMember, memberlist);
        addWindow.Show();
        this.Close();
    }

    private void EditData(object? sender, RoutedEventArgs e)
    {
        Members currentMember = MemberGrid.SelectedItem as Members;
        if (currentMember == null)
        {
            return;
        }
        RSOpracAPP.AddUpdate updateWindow = new AddUpdate(currentMember, memberlist);
        updateWindow.Show();
        this.Close();
    }

    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            Members currentMember = MemberGrid.SelectedItem as Members;
            if (currentMember == null)
            {
                return;
            }
            conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "DELETE FROM Members WHERE ID = " + currentMember.ID;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            memberlist.Remove(currentMember);
            ShowTable("SELECT * FROM Members;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void BackToMenu(object? sender, RoutedEventArgs e)
    {
        MainMenu menu = new MainMenu();
        this.Close();
        menu.Show();
    }
}