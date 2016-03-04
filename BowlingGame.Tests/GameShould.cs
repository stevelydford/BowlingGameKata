using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameShould
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void ScoreZeroForAGutterGame()
        {
            RollMany(20, 0);

            Assert.That(_game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void ScoreTwentyIfRolledAllOnes()
        {
            RollMany(20, 1);

            Assert.That(_game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void AwardASpareForKnockingDownTenPinsInASingleFrame()
        {
            RollSpare();
            _game.Roll(1);
            RollMany(17, 0);

            Assert.That(_game.Score(), Is.EqualTo(12));
        }

        [Test]
        public void AwardAStrikeForKnockingDownTenPinsOnFirstBallOfFrame()
        {
            RollStrike();
            _game.Roll(1);
            _game.Roll(1);
            RollMany(16, 0);

            Assert.That(_game.Score(), Is.EqualTo(14));
        }

        [Test]
        public void GiveCorrectScoreForAPerfectGame()
        {
            RollMany(12, 10);
            
            Assert.That(_game.Score(), Is.EqualTo(300));
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}
