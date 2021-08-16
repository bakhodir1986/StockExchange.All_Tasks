using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange.Task3
{
    public class StockExchangeController : IStockExchangeMediator
    {
        private readonly List<StockObject> _stockObjects;
        private readonly List<IPlayer> _subcribers;

        public StockExchangeController()
        {
            _stockObjects = new List<StockObject>();
            _subcribers = new List<IPlayer>();
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
            player.Update(numberOfShares, numberOfShares);

        }

        public void Subcribe(IPlayer player)
        {
            _subcribers.Add(player);
        }

        public void UnSubcribe(IPlayer player)
        {
            _subcribers.Remove(player);
        }
    }
}
