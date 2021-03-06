﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;


namespace DoggaLogg.Model
{
    [Table("Loggs")]
    public class LoggItems
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string LoggTitle { get; set; }
        public string LoggText { get; set; }
        public DateTime LoggCreated { get; set; }
        public DateTime LoggUpdated { get; set; }

        public DateTime LoggTimesetStart { get; set; }
        public DateTime LoggTimesetEnd { get; set; }

        [ForeignKey(typeof(ProfileItems))]
        [InverseProperty("Loggs")]
        public int ProfileId { get; set; }
    }
}
