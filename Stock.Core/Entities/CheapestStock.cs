using Stock.Core.Repository;
using System.Reflection.Metadata.Ecma335;

namespace Stock.Core.Entities
{
    public class CheapestStock : Entity
    {
        public CheapestStock() { }
        public CheapestStock(string Paper, decimal Quotation, decimal PEBIT, decimal EVEBIT, decimal EVEBITDA, decimal VolumeTraded, decimal DividendYield, decimal ROIC, decimal ROE, decimal NetEquity)
        {
            this.Paper = Paper;
            this.Quotation = Quotation;
            this.PEBIT = PEBIT;
            this.EVEBIT = EVEBIT;
            this.EVEBITDA = EVEBITDA;
            this.VolumeTraded = VolumeTraded;
            this.DividendYield = DividendYield;
            this.ROIC = ROIC;
            this.ROE = ROE;
            this.NetEquity = NetEquity;
        }

        public string Paper { get; set; } // Papel. Papel
        public decimal Quotation { get; set; } //Cotação
        public decimal PEBIT { get; set; }
        public decimal EVEBIT { get; set; }
        public decimal EVEBITDA { get; set; }
        public decimal VolumeTraded { get; set; } // Volume Negociado liq2Meses
        public decimal NetEquity { get; set; } // Patrimônio Liquido Patri.Liq
        public decimal DividendYield { get; set; } // %
        public decimal ROIC { get; set; }
        public decimal ROE { get; set; }
        public bool CanBeCheapest { get; set; }

        public bool DetermineIfCanBeCheapest()
        {
            this.CanBeCheapest = false;

            //if (this.VolumeTraded < 200000)
            //    return false;

            //if (this.PEBIT < 0)
            //    return false;

            this.CanBeCheapest = true;
            return true;
        }
    }
}
