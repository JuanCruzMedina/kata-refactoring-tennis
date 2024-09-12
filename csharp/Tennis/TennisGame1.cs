namespace Tennis
{
    public class PlayerScore
    {
        public int Value;

        public void Increment() => Value += 1;
    }

    public class TennisGame1 : ITennisGame
    {
        private readonly PlayerScore _player1Score = new();
        private readonly PlayerScore _player2Score = new ();

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _player1Score.Increment();
                return;
            }
            _player2Score.Increment();
        }

        public string GetScore()
        {
            if (_player1Score.Value == _player2Score.Value)
            {
                return HandleWhenScoresAreEqual();
            }
            if (_player1Score.Value >= 4 || _player2Score.Value >= 4)
            {
                return HandleAdvantageOrWinScore();
            }
            return $"{ScoreValueToDescription(_player1Score.Value)}-{ScoreValueToDescription(_player2Score.Value)}";
        }

        private static string ScoreValueToDescription(int tempScore)
        {
            var description = tempScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => string.Empty
            };
            return description;
        }

        private string HandleAdvantageOrWinScore()
        {
            var scoresDifference = _player1Score.Value - _player2Score.Value;
            return scoresDifference switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string HandleWhenScoresAreEqual() =>
            _player1Score.Value switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
    }
}