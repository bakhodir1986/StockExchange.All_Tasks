using System;

namespace StockExchange.Task1
{
    public class Blossomers : IPlayer
    {
        private IStockExchangeMediator _mediator;

        public Blossomers(IStockExchangeMediator mediator)
        {
            _mediator = mediator;
        }

        public bool SellOffer(string stockName, int numberOfShares)
        {
            return _mediator.Notify(new StockObject()
            {
                Name = stockName,
                NumberOfShares = numberOfShares,
                EventType = "SellOffer",
                Player = this
            });
        }

        public bool BuyOffer(string stockName, int numberOfShares)
        {
            return _mediator.Notify(new StockObject()
            {
                Name = stockName,
                NumberOfShares = numberOfShares,
                EventType = "BuyOffer",
                Player = this
            });
        }
    }
}
