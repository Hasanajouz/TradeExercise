using System;
using System.Collections.Generic;
using System.Text;
using Trades.Models;
using System.Linq;

namespace Trades.Helpers
{
    public class TradeLogicHelper
    {
        #region Private Methods
        //Calculate the sate of group
        private State CalcStateOfGroup(List<Trade> trades)
        {
            double sumOfValues = trades.Sum(t => t.Value);
            int numberOfTrades = trades.Count();
            if (numberOfTrades == trades[0].NumberOfTrades)
            {
                if (sumOfValues < trades[0].Limit)
                {
                    return State.Accepted;
                }
                return State.Rejected;
            }
            else
            {
                return State.Pending;
            }
        }
        //get groups of trades by CorrelationId
        private List<List<Trade>> GroupTradesById(List<Trade> trades)
        {
            return trades.GroupBy(u => u.CorrelationId).Select(grp => grp.ToList()).ToList();
        }
        #endregion


        #region Public Method


        //check if there are some rows with same tradeId which is wrong
        //not good for memory consumption  just made to show the case
        public bool CheckNotSameTradeId(List<Trade> trades)
        {
            int tradesCount = trades.GroupBy(t => t.TradeID).Count();
            if (tradesCount != trades.Count)
            {
                return false;
            }
            return true;
        }

        //check some constrains on data in each group
        //not good for memory consumption  just made to show the case
        public List<TradingGroupStatus> CheckGroupsError(List<Trade> trades)
        {
            List<TradingGroupStatus> tgStateList = new List<TradingGroupStatus>();
            List<List<Trade>> groubedTrades = GroupTradesById(trades);

            foreach (var list in groubedTrades)
            {
                TradingGroupStatus tgState = new TradingGroupStatus();
                tgState.HasNoErrors = true;
                tgState.ErrorMessage = "";
                int numberOfTrades = list[0].NumberOfTrades;
                double limit = list[0].Limit;
                if (list[0].NumberOfTrades < list.Count)
                {
                    tgState.HasNoErrors = false;
                    tgState.ErrorMessage += $"there are more trades with CorrelationID={list[0].CorrelationId} than the maximum number. {list.Count} while the maximum should be {list[0].NumberOfTrades} \n";
                }
                foreach (var item in list)
                {
                    if (item.NumberOfTrades != numberOfTrades)
                    {
                        tgState.HasNoErrors = false;
                        tgState.ErrorMessage += $"Number of trdaes where CorrelationID={item.CorrelationId} is not the same as others with same ID\n";
                    }
                    if (item.Limit != limit)
                    {
                        tgState.HasNoErrors = false;
                        tgState.ErrorMessage += $"limit where CorrelationID={item.CorrelationId} is not the same as others.\n";
                    }
                }
                tgStateList.Add(tgState);

            }
            return tgStateList;
        }

        //main calculation method to give all group its state
        public List<TradeResult> CalculateResult(List<Trade> trades)
        {
            List<TradeResult> result = new List<TradeResult>();
            List<List<Trade>> groubedTrades = GroupTradesById(trades);

            foreach (var list in groubedTrades)
            {
                TradeResult t = new TradeResult();
                t.CorrelationId = list[0].CorrelationId;
                t.NumberOfTrades = list[0].NumberOfTrades;
                t.State = CalcStateOfGroup(list);
                result.Add(t);
            }

            return result.OrderBy(r => r.CorrelationId).ToList();
        }
        #endregion
    }
}
