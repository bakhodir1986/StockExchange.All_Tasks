using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange.Task4
{
    public class StockExchangeController : IStockExchangeMediator
    {
        private readonly List<StockObject> _stockObjects;
        private delegate void NotifyDealDelagate(int soldShares, int boughtShares);
        private event NotifyDealDelagate NotifyDealEvent;

        public StockExchangeController()
        {
            _stockObjects = new List<StockObject>();
        }

        public bool Notify(StockObject firstPlayersStockObject)
        {
            var matchResults = _stockObjects.Where(x => x.Player != firstPlayersStockObject.Player
                                                 && x.Name.Equals(firstPlayersStockObject.Name) &&
                                                 x.NumberOfShares == firstPlayersStockObject.NumberOfShares &&
                                                 x.EventType != firstPlayersStockObject.EventType);

            var stockObjects = matchResults as StockObject[] ?? matchResults.ToArray();
            if (stockObjects.Any())
            {
                var secondPlayersStockObject = stockObjects.First();

                NotifyDeal(firstPlayersStockObject.Player, firstPlayersStockObject.NumberOfShares);
                NotifyDeal(secondPlayersStockObject.Player, secondPlayersStockObject.NumberOfShares);

                _stockObjects.Remove(secondPlayersStockObject);

                return true;
            }

            _stockObjects.Add(firstPlayersStockObject);

            return false;
        }

        public void NotifyDeal(IPlayer player, int numberOfShares)
        {
            //When deal happen sold and bought shares always equal
            int soldShares = numberOfShares; int boughtShares = numberOfShares;

            NotifyDealEvent?.Invoke(soldShares, boughtShares);
        }

        public void Subcribe(IPlayer player)
        {
            NotifyDealEvent += player.Update;
        }

        public void UnSubcribe(IPlayer player)
        {
            NotifyDealEvent -= player.Update;
        }
    }
}
