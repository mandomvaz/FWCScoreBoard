using ScoreBoardNS;

namespace ScoreBoardTests
{
    public class ScoreBoardTests
    {
        private ScoreBoard ScoreBoard { get; set; }
        [SetUp]
        public void Setup()
        {
            ScoreBoard = new ScoreBoard();
        }

        [Test]
        public void CanStartGame()
        {
            ScoreBoard.StartGame("Spain", "Germany");

            Assert.Pass();
        }

        [Test]
        [TestCase("", "Germany")]
        [TestCase("Spain", "")]
        [TestCase("", "")]
        public void StartGameThrowExceptionOnEmptyValues(string homeTeam, string awayTeam)
        {
            Assert.Throws<ArgumentException>(() => ScoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        public void StartGameReturnIntegerId()
        {
            var id = ScoreBoard.StartGame("Spain", "Germany");

            Assert.That(id, Is.TypeOf<int>());
        }
    }
}