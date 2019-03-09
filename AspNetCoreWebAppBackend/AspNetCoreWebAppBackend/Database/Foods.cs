using System;
using System.Collections.Generic;

namespace AspNetCoreWebAppBackend.Database
{
    public partial class Foods
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int? FoodCarbonhydrate { get; set; }
        public int? FoodProtein { get; set; }
        public int? FoodFat { get; set; }

        public virtual Events Events { get; set; }
    }
}
