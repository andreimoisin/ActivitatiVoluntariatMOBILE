namespace ActivitatiVoluntariatMOBILE;
using ActivitatiVoluntariatMOBILE.Models;

public partial class ActivitatePage : ContentPage
{
	public ActivitatePage()
	{
		InitializeComponent();
	}

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Activitate echipament;
        var listechipament = (ActivitateVoluntari)BindingContext;
        if (listView.SelectedItem != null)
        {
            echipament = listView.SelectedItem as Activitate;

            var listProductAll = await App.Database.GetListActivitati();
            var listProduct = listProductAll.FindAll(x => x.ActivitateID == echipament.ID & x.ActivitateVoluntariID == listechipament.ID);
            await App.Database.DeleteListActivitatiAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e) { var slist = (ActivitateVoluntari)BindingContext; slist.Date = DateTime.UtcNow; await App.Database.SaveActivitateVoluntariAsync(slist); await Navigation.PopAsync(); }
    async void OnDeleteButtonClicked(object sender, EventArgs e) { var slist = (ActivitateVoluntari)BindingContext; await App.Database.DeleteActivitateVoluntariAsync(slist); await Navigation.PopAsync(); }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ActivitateAPage((ActivitateVoluntari)this.BindingContext) { BindingContext = new Activitate() });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ActivitateVoluntari)BindingContext;
        listView.ItemsSource = await App.Database.GetListActivitatiAsync(shopl.ID);
    }
}