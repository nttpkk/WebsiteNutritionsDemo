using System;
using System.Collections.Generic;

namespace AspNetCoreWebAppBackend.Database
{
    public partial class Events
    {
        public int EventId { get; set; }
        public int? UserId { get; set; }
        public DateTime? EventDate { get; set; }
        public int? FoodId { get; set; }
        public int? FoodAmount { get; set; }
        public int? FoodCarbonhydrate { get; set; }
        public int? FoodProtein { get; set; }
        public int? FoodFat { get; set; }

        public virtual Foods Event { get; set; }
        public virtual Users User { get; set; }
    }
}
