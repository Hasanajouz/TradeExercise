using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Models
{

    public class TradeResult
    {
        public string CorrelationId { get; set; }
        public int NumberOfTrades { get; set; }
        public State State { get; set; }

    }
}
