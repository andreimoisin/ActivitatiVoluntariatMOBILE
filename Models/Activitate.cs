using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ActivitatiVoluntariatMOBILE.Models
{
    public class Activitate
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Departament { get; set; }
        [OneToMany]
        public List<ListActivitati> ListActivitati { get; set; }
    }
}