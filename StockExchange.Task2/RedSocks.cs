﻿using System;

namespace StockExchange.Task2
{
    public class RedSocks : IPlayer
    {
        private string _uniqueId = Guid.NewGuid().ToString();
        private IStockExchangeMediator _mediator;
        public RedSocks(IStockExchangeMediator mediator)
        {
            _mediator = mediator;
        }

        public IStockExchangeMediator ExchangeMediator { get; set; }

        public bool SellOffer(string stockName, int numberOfShares)
        {
            return _mediator.Notify(new StockObject()
            {
                idOfPlayer = _uniqueId,
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
                idOfPlayer = _uniqueId,
                Name = stockName,
                NumberOfShares = numberOfShares,
                EventType = "BuyOffer",
                Player = this
            });
        }
    }
}
