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
        public void StartGameThrowExceptionOnEmptyValues()
        {
            ScoreBoard scoreBoard = new ScoreBoard();

            Assert.Throws<ArgumentException>(() => scoreBoard.StartGame("", "Germany"));
        }
    }
}