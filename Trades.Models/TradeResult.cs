using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Models
{

    public class TradeResult
    {
        public int CorrelationId { get; set; }
        public int NumberOfTrades { get; set; }
        public State State { get; set; }

    }
}
