using UnityEngine;

public class RestartController : MonoBehaviour
{
    [SerializeField] private RestartButtnonController _buttonController;

    [SerializeField] private GameOverMenuDisabler _gameOverMenuDisabler;

    [SerializeField] private SnakeController _snakeController;

    [SerializeField] private ProjectStarter _projectStarter;

    [SerializeField] private SnakeMover _snakeMover;

    [SerializeField] private ScoreController _scoreController;

    private GameStateController _gameStateController;

    private void Start()
    {
        _gameStateController = _projectStarter.GetGameStateController();
        
        _buttonController.Clicked += RestartTheGame;
    }

    private void RestartTheGame()
    {
        _gameOverMenuDisabler.SetGameOVerScreenActive(false);
        _snakeController.ReplaceTheSnake();
        _snakeMover.SetLastDirection(DirectionOfMovement.Right);
        _scoreController.ResetScore();
        _gameStateController.CurrentGameState = GameState.Game;
    }
}
