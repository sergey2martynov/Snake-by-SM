using System;

public class GameStateController
{
    public event Action<GameState> GameStateChange;
    
    private GameState _currentGameState = GameState.Game;

    public GameState CurrentGameState
    {
        get
        {
            return _currentGameState;
        }

        set
        {
            _currentGameState = value;
            GameStateChange?.Invoke(_currentGameState);
        }
    }
}
