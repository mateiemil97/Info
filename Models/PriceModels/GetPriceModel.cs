using System;
using System.Collections.Generic;
using System.Text;

namespace Models.PriceModels
{
    public class GetPriceModel
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int CategoryId { get; set; }

        public float Value { get; set; }
    }
}
