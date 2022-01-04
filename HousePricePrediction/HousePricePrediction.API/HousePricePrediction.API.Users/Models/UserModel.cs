using System;
using System.Collections.Generic;

namespace HousePricePrediction.API.Users.Model
{
    public class UserModel
    {
        private long id { get; set; }
        private String? name { get; set; }
        private String? phoneNumber { get; set; }
        private String? username { get; set; }
        private String? email { get; set; }
        private String? password { get; set; }
        // private AuthProviderEnum provider { get; set; }
        private String? providerId { get; set; }
        private bool isEnabled { get; set; }
        private bool isLocked { get; set; }
        private DateTime creationDate { get; set; }
        // private Set<Role> roles { get; set; } = new HashSet<>();
        private ICollection<House>? favorite { get; set; }
        private ICollection<House>? forSell { get; set; }
        public const int VIEWS_HISTORY_CAPACITY = 10;
        public int ViewsHistoryCapacity { get { return VIEWS_HISTORY_CAPACITY; } }
        public const int FAVOURITE_LIST_CAPACITY = 20;
        public int FavouriteListCapacity { get { return FAVOURITE_LIST_CAPACITY; } }

        class MyList<House> : List<House>
        {
            private int capacity;

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
