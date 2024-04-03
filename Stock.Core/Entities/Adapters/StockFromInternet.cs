using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Entities.Adapters
{
    public class StockFromInternet
    {
        public StockFromInternet() { }
        public StockFromInternet(string Paper, string Quotation, string PEBIT, string EVEBIT, string EVEBITDA, string VolumeTraded, string DividendYield, string ROIC, string ROE)
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
        }

        public Stock BuildStock()
        {

            var stock = new Stock() {
                Paper = this.Paper,
                Quotation = CheckTypeFromNumber(this.Quotation),
                PEBIT = CheckTypeFromNumber(this.PEBIT),
                EVEBIT = CheckTypeFromNumber(this.EVEBIT),
                EVEBITDA = CheckTypeFromNumber(this.EVEBITDA),
                VolumeTraded = CheckTypeFromNumber(this.VolumeTraded),
                NetEquity = CheckTypeFromNumber(this.NetEquity),
                DividendYield = CheckTypeFromNumber(this.DividendYield),
                ROIC = CheckTypeFromNumber(this.ROIC),
                ROE = CheckTypeFromNumber(this.ROE),
            };

            return stock;
        }

        public decimal CheckTypeFromNumber(string content)
        {
            if (content.Equals("0,00"))
                return 0;

            return decimal.Parse(
                content.Replace("%", "").Replace(".", "").Replace(",", "."),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign
            );
        }

        public string Paper { get; set; } // Papel. Papel
        public string Quotation { get; set; } //Cotação
        public string PEBIT { get; set; }
        public string EVEBIT { get; set; }
        public string EVEBITDA { get; set; }
        public string VolumeTraded { get; set; } // Volume Negociado liq2Meses
        public string NetEquity { get; set; } // Patrimônio Liquido Patri.Liq
        public string DividendYield { get; set; } // %
        public string ROIC { get; set; }
        public string ROE { get; set; }
        public bool CanBeCheapest { get; set; }

    }
}
