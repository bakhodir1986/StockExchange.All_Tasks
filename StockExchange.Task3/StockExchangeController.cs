using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange.Task3
{
    public class StockExchangeController : IStockExchangeMediator
    {
        private List<StockObject> StockObjects;
        private List<IPlayer> subcribers;

        public StockExchangeController()
        {
            StockObjects = new List<StockObject>();
            subcribers = new List<IPlayer>();
        }

        public bool Notify(StockObject stockObject)
        {
            var matchResults = StockObjects.Where(x => x.Player != stockObject.Player
                                                 && x.Name.Equals(stockObject.Name) &&
                                                 x.NumberOfShares == stockObject.NumberOfShares &&
                                                 x.EventType != stockObject.EventType);

            if (matchResults.Any())
            {
                var secondPlayer = matchResults.First();

                NotifyDeal(stockObject.Player, stockObject.NumberOfShares);
                NotifyDeal(secondPlayer.Player, stockObject.NumberOfShares);

                StockObjects.Remove(secondPlayer);

                return true;
            }

            StockObjects.Add(stockObject);

            return false;
        }

        public void NotifyDeal(IPlayer player, int NumberOfShares)
        {
            player.Update(NumberOfShares, NumberOfShares);

        }

        public void Subcribe(IPlayer player)
        {
            subcribers.Add(player);
        }

        public void UnSubcribe(IPlayer player)
        {
            subcribers.Remove(player);
        }
    }
}
