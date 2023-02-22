using ActivitatiVoluntariatMOBILE.Models;

namespace ActivitatiVoluntariatMOBILE;

public partial class ActivitateAPage : ContentPage
{
    ActivitateVoluntari sl;
    public ActivitateAPage(ActivitateVoluntari slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e) { var activitate = (Activitate)BindingContext; await App.Database.SaveActivitateAsync(activitate); listView.ItemsSource = await App.Database.GetActivitateAsync(); }
    async void OnDeleteButtonClicked(object sender, EventArgs e) { var activitate = (Activitate)BindingContext; await App.Database.DeleteActivitateAsync(activitate); listView.ItemsSource = await App.Database.GetActivitateAsync(); }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetActivitateAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Activitate p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Activitate;
            var lp = new ListActivitati()
            {
                ActivitateVoluntariID = sl.ID,
                ActivitateID = p.ID
            };
            await App.Database.SaveListActivitatiAsync(lp);
            p.ListActivitati = new List<ListActivitati> { lp };
            await Navigation.PopAsync();
        }
    }
}