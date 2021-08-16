namespace StockExchange.Task4
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var mediator = new StockExchangeController();

            var redSocks = new RedSocks(mediator);
            var blossomers = new Blossomers(mediator);
            var rossSocks = new RossSocks(mediator);

            mediator.Subcribe(redSocks);
            mediator.Subcribe(blossomers);
            mediator.Subcribe(rossSocks);

            return new Players
            {
                RedSocks = redSocks,
                Blossomers = blossomers,
                RossSocks = rossSocks
            };
        }
    }
}
