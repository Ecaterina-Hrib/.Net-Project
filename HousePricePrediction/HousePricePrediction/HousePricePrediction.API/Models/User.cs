using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HousePricePrediction.API.Models
{
    [Table("users")]
    public class User
    {
                
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid _id { get; set; }
        public String? _name { get; set; }
        public String? _phoneNumber { get; set; }
        public String? _username { get; set; }
        public String? _email { get; set; }
        public String? _password { get; set; }
        public DateTime _creationDate { get; set; }

        public  byte[]? key { get; set; }
        public  byte[]? iv { get; set; }

        public int _totalViews { get; set; } = 0;
        // public virtual List<House> _forSell { get; set; } = new List<House>();
    }
}
