using System;
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
        // public AuthProviderEnum provider { get; set; }
        // public String? providerId { get; set; }
        // public bool isEnabled { get; set; }
        // public bool isLocked { get; set; }
        public DateTime _creationDate { get; set; }
        // public Set<Role> roles { get; set; } = new HashSet<>();
        // public ICollection<House>? favorite { get; set; }
        public ICollection<House>? _forSell { get; set; }
        // public const int VIEWS_HISTORY_CAPACITY = 10;
        // public int ViewsHistoryCapacity { get { return VIEWS_HISTORY_CAPACITY; } }
        // public const int FAVOURITE_LIST_CAPACITY = 20;
        // public int FavouriteListCapacity { get { return FAVOURITE_LIST_CAPACITY; } }

        class MyList<House> : List<House>
        {
            public int capacity;

            public MyList(int capacity) : base() 
            {
                this.capacity = capacity;
            }

            public new void Add(House house) 
            {
                if (base.Count == capacity)
                {
                    base.RemoveAt(0);
                }
                base.Add(house);
            }
        }
    }
}
