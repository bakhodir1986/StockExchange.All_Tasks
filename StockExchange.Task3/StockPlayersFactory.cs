namespace StockExchange.Task3
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var meditor = new StockExchangeController();

            var redSocks = new RedSocks(meditor);
            var blossomers = new Blossomers(meditor);
            var rossSocks = new RossSocks(meditor);

            meditor.Subcribe(redSocks);
            meditor.Subcribe(blossomers);
            meditor.Subcribe(rossSocks);

            return new Players
            {
                RedSocks = redSocks,
                Blossomers = blossomers,
                RossSocks = rossSocks
            };
        }
    }
}
