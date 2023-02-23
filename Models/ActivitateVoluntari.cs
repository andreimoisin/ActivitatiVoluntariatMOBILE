using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitatiVoluntariatMOBILE.Models
{
    public class ActivitateVoluntari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        public DateTime Date { get; set; }
    }
}
