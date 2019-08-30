using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Trades.Models
{
    //Class responisble of saving file as CSV
    public class TradesCSVHelper
    {
        const string csvTradeHeader = "CorrelationID,NumberOfTrades,State\n";

        private string CreateContentFromList(List<TradeResult> trades)
        {
            string lines = "";
            for (int i = 0; i < trades.Count; i++)
            {
                TradeResult item = trades[i];
                lines += $"{item.CorrelationId},{item.NumberOfTrades},{item.State}";
                lines += i != trades.Count - 1 ? "\n" : "";
            }
            return lines;
        }

        private void SaveFileAsCSV(string content,string url)
        {
            System.IO.File.WriteAllText(url, csvTradeHeader+content);
        }

        public void ConvertToCSV(List<TradeResult> trades,string url)
        {
            SaveFileAsCSV(CreateContentFromList(trades), url);
        }
    }
}
