using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace RSOpracAPP;

public partial class MainMenu : Window
{
    public MainMenu()
    {
        InitializeComponent();
    }

    private void MembersButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MembersForm membersForm = new MembersForm();
        this.Hide();
        membersForm.Show();
    }

    private void Logon_OnClick(object? sender, RoutedEventArgs e)
    {
        LoginWindow lw = new LoginWindow();
        this.Hide();
        lw.Show();
    }

    private void CatalogButton_OnClick(object? sender, RoutedEventArgs e)
    {
        CatalogForm catalogForm = new CatalogForm();
        this.Hide();
        catalogForm.Show();
    }

    private void StaffButton_OnClick(object? sender, RoutedEventArgs e)
    {
        StaffForm staffForm = new StaffForm();
        this.Hide();
        staffForm.Show();
    }

    private void OrdersButton_OnClick(object? sender, RoutedEventArgs e)
    {
        OrdersForm ordersForm = new OrdersForm();
        this.Hide();
        ordersForm.Show();
    }

    private void SquadButton_OnClick(object? sender, RoutedEventArgs e)
    {
        SquadForm squadForm = new SquadForm();
        this.Hide();
        squadForm.Show();
    }

    private void LaureatesButton_OnClick(object? sender, RoutedEventArgs e)
    {
        LaureatesForm laureatesForm = new LaureatesForm();
        this.Hide();
        laureatesForm.Show();
    }

    private void EventsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        EventsForm eventsForm = new EventsForm();
        this.Hide();
        eventsForm.Show();
    }
}