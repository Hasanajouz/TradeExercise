using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trades.Helpers;
using Trades.Models;

namespace Trades.UnitTest
{
    [TestClass]
    public class TradeCalculationsTest
    {
        //Should work well
        //Same as provided Example
        [TestMethod]
        public void TestGoodTradeList()
        {
            //Arrange
            MockDataStore mockDataStore = new MockDataStore();
            List<Trade> trades = mockDataStore.GetMockedGoodTradeList();

            //Act
            TradeLogicHelper tradeLogic = new TradeLogicHelper();
            List<TradeResult> actualResult = tradeLogic.CalculateResult(trades);

            //Assert
            List<TradeResult> expectedResult = mockDataStore.GetMockedGoodTradeResult();
            Assert.IsTrue(mockDataStore.TradeResultsAreEqual(expectedResult, actualResult));

        }

        //Should Pass because it doesn't have any duplicated id
        [TestMethod]
        public void TestSameDoesntHaveTradeID()
        {
            //Arrange
            MockDataStore mockDataStore = new MockDataStore();
            List<Trade> trades = mockDataStore.GetMockedGoodTradeList();

            //Act
            TradeLogicHelper tradeLogic = new TradeLogicHelper();
            bool doesntHaveSameId = tradeLogic.CheckNotSameTradeId(trades);

            //Assert
            Assert.IsTrue(doesntHaveSameId);

        }

        //should give error that list contains same TradeId
        [TestMethod]
        public void TestSameHasTradeID()
        {
            //Arrange
            MockDataStore mockDataStore = new MockDataStore();
            List<Trade> trades = mockDataStore.GetMockedDoublicatedTradeIdList();

            //Act
            TradeLogicHelper tradeLogic = new TradeLogicHelper();
            bool doesntHaveSameId = tradeLogic.CheckNotSameTradeId(trades);

            //Assert
            Assert.IsTrue(!doesntHaveSameId);

        }

        //should give error that list contains some wrong data
        [TestMethod]
        public void TestHasBadData()
        {
            //Arrange
            MockDataStore mockDataStore = new MockDataStore();
            List<Trade> trades = mockDataStore.GetMockedWrongLimitTradeIdList();

            //Act
            TradeLogicHelper tradeLogic = new TradeLogicHelper();
            List<TradingGroupStatus> groupStatuses = tradeLogic.CheckGroupsError(trades);

            //Assert
            bool ErrorFound = false;
            foreach (var item in groupStatuses)
            {
                if (!item.HasNoErrors)
                {
                    ErrorFound = true;
                }
            }
            Assert.IsTrue(ErrorFound);

        }
    }
}
