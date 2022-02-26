using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private UserInputManager _inputManager;

    [SerializeField] private MapController _mapController;

    [SerializeField] private SnakeController _snakeController;

    private List<SnakeCellController> _snake;

    private DirectionOfMovement _lastDirection;

    private void Start()
    {
        _snake = _snakeController.ReturnSnake();

        _inputManager.RightPressed += GoSnake;
    }

    private void OnDestroy()
    {
        _inputManager.RightPressed -= GoSnake;
    }

    private void GoSnake(DirectionOfMovement direction)
    {
        if (_lastDirection == DirectionOfMovement.Up && direction == DirectionOfMovement.Down ||
            _lastDirection == DirectionOfMovement.Down && direction == DirectionOfMovement.Up ||
            _lastDirection == DirectionOfMovement.Right && direction == DirectionOfMovement.Left ||
            _lastDirection == DirectionOfMovement.Left && direction == DirectionOfMovement.Right)
        {
            return;
        }

        for (int snakeCellIndex = 0; snakeCellIndex < _snake.Count; snakeCellIndex++)
        {
            if (_snake[snakeCellIndex] == _snake[_snake.Count - 1])
            {
                _snake[snakeCellIndex].ChangeIndex(direction);

                _snake[snakeCellIndex].transform.position = _mapController
                    .ReturnFieldToTheRight(_snake[snakeCellIndex].RowIndex, _snake[snakeCellIndex].ColumnIndex)
                    .transform.position;
                _lastDirection = direction;
                return;
            }

            _snake[snakeCellIndex].RowIndex = _snake[snakeCellIndex + 1].RowIndex;

            _snake[snakeCellIndex].ColumnIndex = _snake[snakeCellIndex + 1].ColumnIndex;

            _snake[snakeCellIndex].transform.position = _snake[snakeCellIndex + 1].transform.position;
        }
    }
}