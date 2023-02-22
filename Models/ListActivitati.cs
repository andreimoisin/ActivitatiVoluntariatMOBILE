using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace ActivitatiVoluntariatMOBILE.Models
{
    public class ListActivitati
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ActivitateVoluntari))]
        public int ActivitateVoluntariID { get; set; }
        public int ActivitateID { get; set; }
    }
}