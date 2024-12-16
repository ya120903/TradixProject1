using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradixProject.DtoLayer.ExchangeRateDtos
{
    public class ResualtExhangeRateDto
    {
            public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string Unit { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
