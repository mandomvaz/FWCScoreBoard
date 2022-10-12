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
    }
}