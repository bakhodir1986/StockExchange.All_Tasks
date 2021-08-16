using System;

namespace StockExchange.Task3
{
    public class RedSocks : IPlayer
    {
        private readonly IStockExchangeMediator _mediator;

        public RedSocks(IStockExchangeMediator mediator)
        {
            _mediator = mediator;
        }

        private int _soldShares;
        private int _boughtShares;

        public int SoldShares => _soldShares;

        public int BoughtShares => _boughtShares;


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

        public void Update(int soldShares, int boughtShares)
        {
            _soldShares = soldShares;
            _boughtShares = boughtShares;
        }
    }
}
