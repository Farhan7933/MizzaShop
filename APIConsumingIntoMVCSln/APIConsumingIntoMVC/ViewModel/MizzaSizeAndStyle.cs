using APIConsumingIntoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIConsumingIntoMVC.ViewModel
{
    public class MizzaSizeAndStyle
    {
        public IEnumerable<MizzaSize> mizzaSizes { get; set; }
        public IEnumerable<MizzaStyle> mizzaStyles { get; set; }
    }
}