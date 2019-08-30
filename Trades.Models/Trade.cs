using System;
using System.Xml.Serialization;

namespace Trades.Models
{
    [XmlRoot(ElementName = "Trade")]
    public class Trade
    {
        [XmlAttribute(AttributeName = "CorrelationId")]
        public int CorrelationId { get; set; }
        [XmlAttribute(AttributeName = "NumberOfTrades")]
        public int NumberOfTrades { get; set; }
        [XmlAttribute(AttributeName = "Limit")]
        public double Limit { get; set; }
        [XmlAttribute(AttributeName = "TradeID")]
        public int TradeID { get; set; }
        [XmlText]
        public double Value { get; set; }
    }
}
