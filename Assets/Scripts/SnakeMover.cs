using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private UserInputManager _inputManager;

    [SerializeField] private MapController _mapController;

    [SerializeField] private SnakeController _snakeController;

    [SerializeField] private ProjectStarter _projectStarter;

    private GameStateController _gameStateController;

    private List<SnakeCellController> _snake;

    private List<List<FieldController>> _map;

    private float _differenceTime = 0.3f;

    private float _fixedMovingTime;

    private DirectionOfMovement _lastDirection = DirectionOfMovement.Right;

    private DirectionOfMovement _firstDirection = DirectionOfMovement.Right;

    private bool _isNeedToAddCell;

    private int _fixedRowIndex = 3;

    private int _fixedColumnIndex = 3;

    public event Action FruitEaten;

    private void Start()
    {
        _snake = _snakeController.ReturnSnake();

        _map = _mapController.ReturnMap();

        _gameStateController = _projectStarter.GetGameStateController();

        GoSnake(_firstDirection);

        _inputManager.ArrowPressed += GoSnakeOnPressure;
    }

    private void OnDestroy()
    {
        _inputManager.ArrowPressed -= GoSnakeOnPressure;
    }

    private void Update()
    {
        if (Time.time - _fixedMovingTime >= _differenceTime &&
            _gameStateController.CurrentGameState == GameState.Game)
        {
            GoSnake(_lastDirection);
        }
    }

    private void GoSnakeOnPressure(DirectionOfMovement direction)
    {
        if (_gameStateController.CurrentGameState == GameState.Game)
        {
            if (_lastDirection == DirectionOfMovement.Up && direction == DirectionOfMovement.Down ||
                _lastDirection == DirectionOfMovement.Down && direction == DirectionOfMovement.Up ||
                _lastDirection == DirectionOfMovement.Right && direction == DirectionOfMovement.Left ||
                _lastDirection == DirectionOfMovement.Left && direction == DirectionOfMovement.Right ||
                _lastDirection == DirectionOfMovement.Up && direction == DirectionOfMovement.Up ||
                _lastDirection == DirectionOfMovement.Down && direction == DirectionOfMovement.Down ||
                _lastDirection == DirectionOfMovement.Right && direction == DirectionOfMovement.Right ||
                _lastDirection == DirectionOfMovement.Left && direction == DirectionOfMovement.Left )
            {
                return;
            }

            GoSnake(direction);
        }
    }

    private void GoSnake(DirectionOfMovement direction)
    {
        for (int snakeCellIndex = 0; snakeCellIndex < _snake.Count; snakeCellIndex++)
        {
            if (snakeCellIndex == 0)
            {
                if (_map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue ==
                    FieldValueType.FruitInsideSnake)
                {
                    _isNeedToAddCell = true;

                    _fixedRowIndex = _snake[snakeCellIndex].RowIndex;
                    _fixedColumnIndex = _snake[snakeCellIndex].ColumnIndex;
                }
                else if (_isNeedToAddCell)
                {
                    _snakeController.AddCellToSnake(_fixedRowIndex, _fixedColumnIndex);
                    _isNeedToAddCell = false;
                    _map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue =
                        FieldValueType.Empty;
                }
                else
                {
                    _map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue =
                        FieldValueType.Empty;
                }
            }


            if (_snake[snakeCellIndex] == _snake[_snake.Count - 1])
            {
                _snake[snakeCellIndex].ChangeIndex(direction);

                _snake[snakeCellIndex].transform.position = _mapController
                    .ReturnFieldToTheRight(_snake[snakeCellIndex].RowIndex, _snake[snakeCellIndex].ColumnIndex)
                    .transform.position;

                _lastDirection = direction;

                if (_map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue ==
                    FieldValueType.Fruit)
                {
                    FruitEaten?.Invoke();
                    _map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue =
                        FieldValueType.FruitInsideSnake;
                }
                else if (_map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue ==
                         FieldValueType.Snake)
                {
                    _gameStateController.CurrentGameState = GameState.GameOver;
                }
                else
                {
                    _map[_snake[snakeCellIndex].RowIndex][_snake[snakeCellIndex].ColumnIndex].FieldValue =
                        FieldValueType.Snake;
                }

                _fixedMovingTime = Time.time;
                return;
            }

            _snake[snakeCellIndex].RowIndex = _snake[snakeCellIndex + 1].RowIndex;

            _snake[snakeCellIndex].ColumnIndex = _snake[snakeCellIndex + 1].ColumnIndex;

            _snake[snakeCellIndex].transform.position = _snake[snakeCellIndex + 1].transform.position;
        }
    }

    public void SetLastDirection(DirectionOfMovement direction)
    {
        _lastDirection = direction;
    }
}