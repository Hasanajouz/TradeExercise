using System;
using System.Collections.Generic;
using System.Text;
using Trades.Models;

namespace Trades.Helpers
{
    public class MockDataStore
    {
        public List<Trade> GetMockedGoodTradeList()
        {
            return  new List<Trade>
            {
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=654,Value=100},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=135,Value=200},
                new Trade{CorrelationId=222,Limit=500,NumberOfTrades=1,TradeID=423,Value=600},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=652,Value=200},
                new Trade{CorrelationId=200,Limit=1000,NumberOfTrades=2,TradeID=645,Value=1000}
            };
        }

        public List<Trade> GetMockedDoublicatedTradeIdList()
        {
            return new List<Trade>
            {
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=654,Value=100},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=135,Value=200},
                new Trade{CorrelationId=222,Limit=500,NumberOfTrades=1,TradeID=423,Value=600},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=654,Value=200},
                new Trade{CorrelationId=200,Limit=1000,NumberOfTrades=2,TradeID=645,Value=1000}
            };
        }


        public List<Trade> GetMockedWrongLimitTradeIdList()
        {
            return new List<Trade>
            {
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=654,Value=100},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=1,TradeID=135,Value=200},
                new Trade{CorrelationId=222,Limit=500,NumberOfTrades=1,TradeID=423,Value=600},
                new Trade{CorrelationId=234,Limit=1000,NumberOfTrades=3,TradeID=654,Value=200},
                new Trade{CorrelationId=200,Limit=1000,NumberOfTrades=2,TradeID=645,Value=1000}
            };
        }

        public List<TradeResult> GetMockedGoodTradeResult()
        {
            return new List<TradeResult>
            {
                new TradeResult{CorrelationId=200,NumberOfTrades=2,State=State.Pending},
                new TradeResult{CorrelationId=222,NumberOfTrades=1,State=State.Rejected},
                new TradeResult{CorrelationId=234,NumberOfTrades=3,State=State.Accepted}
            };
        }

        public bool TradeResultsAreEqual(List<TradeResult> one, List<TradeResult> two)
        {
            if (one==null&&two!=null)
            {
                return false;
            }
            if (one != null && two == null)
            {
                return false;
            }
            if (one.Count!=two.Count)
            {
                return false;
            }
            for (int i = 0; i < one.Count; i++)
            {
                if (one[i].CorrelationId!=two[i].CorrelationId||
                    one[i].NumberOfTrades != two[i].NumberOfTrades ||
                    one[i].State != two[i].State )
                {
                    return false;
                }
            }
            return true;
        }


    }
}
