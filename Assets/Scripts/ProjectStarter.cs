using UnityEngine;

public class ProjectStarter : MonoBehaviour
{
    [SerializeField] private MapController _mapController;

    [SerializeField] private SnakeController _snakeController;
    
    private void Awake()
    {
        _mapController.CreateAGameMap();
        _snakeController.CreateASnake();
    }
}
