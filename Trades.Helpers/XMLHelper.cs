using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Trades.Models;
using System.Linq;
using System.Xml;

namespace Trades.Helpers
{
    //this class will only deal with Xml
    public class TradesXMLHelper
    {



        #region Public Method

        public bool IsGoodTradeXmlFile(string uri)
        {
            XmlReader reader = new XmlTextReader(uri);
            XmlSerializer serializer = new XmlSerializer(typeof(TradesList));
            return serializer.CanDeserialize(reader);
        }

        public TradesList GetTradesFromXmlFile(string uri)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TradesList));

            using (FileStream stream = File.OpenRead(uri))
            {
                return (TradesList)serializer.Deserialize(stream);
            }
            
        }
        

        #endregion


    }
}
