using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StockExchange.Task2
{
    public class StockExchangeController : IStockExchangeMediator
    {
        private List<StockObject> StockObjects;

        public StockExchangeController()
        {
            StockObjects = new List<StockObject>();
        }

        public bool Notify(StockObject stockObject)
        {
            var matchResults = StockObjects.Where(x => x.Player != stockObject.Player
                                                 && x.Name.Equals(stockObject.Name) &&
                                                 x.NumberOfShares == stockObject.NumberOfShares &&
                                                 x.EventType != stockObject.EventType);

            if (matchResults.Any())
            {
                return true;
            }

            StockObjects.Add(stockObject);

            return false;
        }
    }
}
