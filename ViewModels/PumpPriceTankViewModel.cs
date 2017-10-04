using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJunction.ViewModels
{
    public class PumpPriceTankViewModel
    {
        public int Id { get; set; }

        public int PumpPriceId { get; set; } // will come from PumpPriceViewModel

        public int TankId { get; set; } // will come from CodeDesc table

        public decimal BaseFuelCost { get; set; }

        public decimal HandlingFee { get; set; }

        public decimal Freight { get; set; }

        public decimal EnvImpactFee { get; set; }

        public decimal FederalMFT { get; set; }

        public decimal UndStorageTax { get; set; }

        public decimal ProfitMargin { get; set; }

        public decimal SalesTaxRate { get; set; }

        public decimal SalesTaxOnTaxableSales { get; set; }

        public decimal StateMFT { get; set; }

        public decimal CurrentGallonInventory { get; set; }

        public decimal BreakEven { get; set; }

        public decimal DeliveredGallons { get; set; }

        public decimal DeliveredBreakEven { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; } = 1;

        public DateTime Modified { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;
    }
}
