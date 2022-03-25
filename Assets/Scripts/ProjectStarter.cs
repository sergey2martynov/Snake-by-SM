using UnityEngine;

public class ProjectStarter : MonoBehaviour
{
    [SerializeField] private MapController _mapController;

    [SerializeField] private SnakeController _snakeController;

    [SerializeField] private FruitMaker _fruitMaker;

    private GameStateController _gameStateController;
    
    private void Awake()
    {
        _gameStateController = new GameStateController();
        _mapController.CreateAGameMap();
        _snakeController.CreateASnake();
        _fruitMaker.CreateFruit();
    }

    public GameStateController GetGameStateController()
    {
        return _gameStateController;
    }
}
