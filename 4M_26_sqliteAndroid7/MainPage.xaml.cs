
using SQLite;
namespace _4M_26_sqliteAndroid7
{
    public class Baza
    {
        public const string dbName = "baza3.db";
        public static string dbpath =
                Path.Combine(FileSystem.AppDataDirectory, dbName);
        private const SQLiteOpenFlags flagi = SQLiteOpenFlags.Create
            | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;
        SQLiteConnection database;

        public Baza()
        {

        }

        public void Init()
        {
            if (database is not null)
                return;
            database = new SQLiteConnection(dbpath, flagi);
            var result = database.CreateTable<Uczen>();
        }


        public int Add(Uczen item)
        {
            return database.Insert(item);
        }

    }
    public class Uczen
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string klasa { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Baza baza = new Baza();
            baza.Init();
            Uczen u = new Uczen();
            u.name = "Ala Kot";
            u.klasa = "4 M";
            baza.Add(u);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}


