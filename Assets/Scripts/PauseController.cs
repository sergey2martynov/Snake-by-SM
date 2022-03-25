using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private UserInputManager _userInputManager;

    [SerializeField] private ProjectStarter _projectStarter;
    [SerializeField] private PauseScreenDisabler _pauseScreenDisabler;

    private GameStateController _gameStateController;

    private void Start()
    {
        _gameStateController = _projectStarter.GetGameStateController();

        _userInputManager.EscapePressed += MakePause;
    }

    private void MakePause()
    {
        if (_gameStateController.CurrentGameState == GameState.Game)
        {
            _gameStateController.CurrentGameState = GameState.Pause;
            _pauseScreenDisabler.SetPauseScreenActive(true);
        }
        else if (_gameStateController.CurrentGameState == GameState.Pause)
        {
            _gameStateController.CurrentGameState = GameState.Game;
            _pauseScreenDisabler.SetPauseScreenActive(false);
        }
    }
}