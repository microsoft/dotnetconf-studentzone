using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterConsumption.Proxy.Models
{
    public class WaterConsumptionModel
    {
        public virtual List<WaterConsumptionItemModel> Data { get; set; } = new List<WaterConsumptionItemModel>();
    }

    public class WaterConsumptionItemModel
    {
        public virtual DateTimeOffset DateTime { get; set; }
        public virtual decimal Consumption { get; set; }
    }
}