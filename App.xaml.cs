using ActivitatiVoluntariatMOBILE.Data;
using System;
using System.IO;

namespace ActivitatiVoluntariatMOBILE;

public partial class App : Application
{
    static ActivitatiDatabase database;
    public static ActivitatiDatabase Database { get { if (database == null) { database = new ActivitatiDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activitate.db3")); } return database; } }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
