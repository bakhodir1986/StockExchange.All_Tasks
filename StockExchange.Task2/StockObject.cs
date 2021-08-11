using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task2
{
    public class StockObject
    {
        public string idOfPlayer { get; set; }
        public IPlayer Player { get; set; }

        public string Name { get; set; }

        public int NumberOfShares { get; set; }

        public string EventType { get; set; }
    }
}
