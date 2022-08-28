using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOMizzaAPI.Models
{
    public class BunchMizza
    {
        public MizzaSize mizzaSizes;
        public MizzaSKU mizzaSKUs;
        public MizzaSkuBasePrice mizzaSkuBasePrices;
        public MizzaSKUStock mizzaSKUStocks;
        public MizzaStyle mizzaStyles;
        public MizzaToppingSKUPrice mizzaToppingSKUPrices;
        public MizzaToppingSKUStock mizzaToppingSKUStocks;
        public MizzaToppingsStyleSKU mizzaToppingsStyleSKUs;
        public MizzaToppingStyle mizzaToppingStyles;
    }
}