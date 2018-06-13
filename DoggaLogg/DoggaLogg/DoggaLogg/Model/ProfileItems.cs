using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace DoggaLogg.Model
{
    [Table("Profiles")]
    public class ProfileItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string ProfileRace { get; set; }
        public string ProfileIcon { get; set; }
        public DateTime BDay { get; set; }

        //Change to IEnumerable to work with the join in the database method.
        //Don't put the InverseProperty because it don't work in this version of SQLite
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual IEnumerable<LoggItems> Loggs { get; set; }
    }
}
