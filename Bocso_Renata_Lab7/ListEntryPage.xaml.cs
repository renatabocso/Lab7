using Bocso_Renata_Lab7.Models;
using SQLitePCL;

namespace Bocso_Renata_Lab7;

public partial class ListEntryPage : ContentPage
{
    private object _selectedItem;
	public ListEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetShopListsAsync();
    }

    async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        var selectedItem = _selectedItem;
    }

    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new ShopList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            _selectedItem = e.SelectedItem;
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as ShopList
            });
        }
    }

}