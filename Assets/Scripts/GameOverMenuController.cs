using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] private ProjectStarter _projectStarter;

    [SerializeField] private GameOverMenuDisabler _menuDisabler;
    
    [SerializeField] private Text _scoreResultText;

    [SerializeField] private Text _currentScore;

    private GameStateController _gameStateController;

    private void Start()
    {
        _gameStateController = _projectStarter.GetGameStateController();
        _gameStateController.GameStateChange += ActivateGameOverMenu;
    }

    private void ActivateGameOverMenu(GameState gameState)
    {
        if (gameState == GameState.GameOver)
        {
            _scoreResultText.text = _currentScore.text;
            _menuDisabler.SetGameOVerScreenActive(true);
        }
    }
}