using System;
using System.Xml.Serialization;

namespace Trades.Models
{
    [XmlRoot(ElementName = "Trade")]
    public class Trade
    {
        [XmlAttribute(AttributeName = "CorrelationId")]
        public string CorrelationId { get; set; }
        [XmlAttribute(AttributeName = "NumberOfTrades")]
        public int NumberOfTrades { get; set; }
        [XmlAttribute(AttributeName = "Limit")]
        public int Limit { get; set; }
        [XmlAttribute(AttributeName = "TradeID")]
        public string TradeID { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
}
