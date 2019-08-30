using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Trades.Models
{
    [XmlRoot(ElementName = "Trades")]
    public class TradesList
    {
        [XmlElement(ElementName = "Trade")]
        public List<Trade> Trades { get; set; }
    }
}
