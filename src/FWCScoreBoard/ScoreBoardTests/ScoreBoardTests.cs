using ScoreBoardNS;

namespace ScoreBoardTests
{
    public class ScoreBoardTests
    {
        [Test]
        public void ScoreBoardCanInstantiate()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            
            Assert.That(scoreBoard, Is.Not.Null);
        }

        [Test]
        public void CanStartGame()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.StartGame("Spain", "Germany");

            Assert.Pass();
        }

        [Test]
        [TestCase("", "Germany")]
        [TestCase("Spain", "")]
        [TestCase("", "")]
        public void StartGameThrowExceptionOnEmptyValues(string homeTeam, string awayTeam)
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            Assert.Throws<ArgumentException>(() => scoreBoard.StartGame(homeTeam, awayTeam));
        }

        [Test]
        public void StartGameReturnIntegerId()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            var id = scoreBoard.StartGame("Spain", "Germany");

            Assert.That(id, Is.TypeOf<int>());
        }
    }
}