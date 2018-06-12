using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DoggaLogg.Model
{
    [Table("Loggs")]
    public class LoggItems
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [ForeignKey(typeof(ProfileItems))]
        public int ProfileId { get; set; }
    }
}
