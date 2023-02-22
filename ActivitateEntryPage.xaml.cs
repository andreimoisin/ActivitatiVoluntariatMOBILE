using ActivitatiVoluntariatMOBILE.Models;

namespace ActivitatiVoluntariatMOBILE;

public partial class ActivitateEntryPage : ContentPage
{
	public ActivitateEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetActivitateVoluntariAsync();
    }
    async void OnActivitateAddedClicked(object sender, EventArgs e) { await Navigation.PushAsync(new ActivitatePage { BindingContext = new ActivitateVoluntari() }); }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new ActivitatePage { BindingContext = e.SelectedItem as ActivitateVoluntari }); }
    }
}