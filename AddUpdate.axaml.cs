using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace RSOpracAPP;

public partial class AddUpdate : Window
{
    private List<Members> members;
    private Members CurrentMember;
    public AddUpdate(Members currentMember, List<Members> member)
    {
        InitializeComponent();
        CurrentMember = currentMember;
        this.DataContext = CurrentMember;
        members = member;
    }
    private string connString = "server=localhost;database=rsodb;User Id=root;password=landoNorris4";
    private MySqlConnection conn;
    private void AddUpdateSaveOnClick(object? sender, RoutedEventArgs e)
    {
        var memberz = members.FirstOrDefault(x => x.ID == CurrentMember.ID);
        if (memberz == null)
        {
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                string add = "INSERT INTO members VALUES (" + Convert.ToInt32(ID.Text)+ ", '" + Фамилия.Text + "', '" + Имя.Text + "','" + Convert.ToInt32(Возраст.Text ) +"', '" + Номер_телефона.Text + "', '" + Адрес.Text + "','" + Convert.ToInt32(Идентификатор_отряда.Text ) + "');";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                string upd = "UPDATE members SET Surname = '" + Фамилия.Text + "', Name = '" + Имя.Text + "', Age = "+ Convert.ToInt32(Возраст.Text) + ", Phone = "+ Номер_телефона.Text + ", Adress = '"+ Адрес.Text + "', ID_Squad = "+ Convert.ToInt32(Идентификатор_отряда.Text) + " WHERE id = " + Convert.ToInt32(ID.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }

    private void BackMenu(object? sender, RoutedEventArgs e)
    {
        MembersForm mf = new MembersForm();
        this.Close();
        mf.Show();
    }
}