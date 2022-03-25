using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private MapController _mapController;

    [SerializeField] private GameObject _snakeCellPrefab;

    private List<SnakeCellController> _snake;

    private List<List<FieldController>> _map;

    private const int StartRowIndex = 3;

    private const int IndexDifference = 2;

    public void CreateASnake()
    {
        _map = _mapController.ReturnMap();

        _snake = new List<SnakeCellController>();

        for (int cellIndex = 0; cellIndex < 3; cellIndex++)
        {
            var columnIndex = cellIndex + IndexDifference;
            var spawnCell = Instantiate(_snakeCellPrefab,
                _map[StartRowIndex][columnIndex].gameObject.transform.position,
                Quaternion.identity);

            _snake.Add(spawnCell.GetComponent<SnakeCellController>());

            _snake[cellIndex].RowIndex = StartRowIndex;
            _snake[cellIndex].ColumnIndex = columnIndex;
            _map[StartRowIndex][columnIndex].FieldValue = FieldValueType.Snake;
        }
    }

    public void AddCellToSnake(int spawnRowIndex, int spawnColumnIndex)
    {
        var newSnakeCell = Instantiate(_snakeCellPrefab.gameObject,
            _map[spawnRowIndex][spawnColumnIndex].transform.position,
            Quaternion.identity);
        _snake.Insert(0, newSnakeCell.GetComponent<SnakeCellController>());
        _snake[0].RowIndex = spawnRowIndex;
        _snake[0].ColumnIndex = spawnColumnIndex;
        _map[spawnRowIndex][spawnColumnIndex].FieldValue = FieldValueType.Snake;
    }

    public void ReplaceTheSnake()
    {
        for (int cellIndex = _snake.Count - 1; cellIndex > 2; cellIndex--)
        {
            _map[_snake[cellIndex].RowIndex][_snake[cellIndex].ColumnIndex].FieldValue = FieldValueType.Empty;
            Destroy(_snake[cellIndex].gameObject);
            _snake.Remove(_snake[cellIndex]);
        }

        for (int cellIndex = 0; cellIndex < 3; cellIndex++)
        {
            _map[_snake[cellIndex].RowIndex][_snake[cellIndex].ColumnIndex].FieldValue = FieldValueType.Empty;
            var columnIndex = cellIndex + IndexDifference;
            _snake[cellIndex].RowIndex = StartRowIndex;
            _snake[cellIndex].ColumnIndex = columnIndex;
            _snake[cellIndex].transform.position =
                _map[_snake[cellIndex].RowIndex][_snake[cellIndex].ColumnIndex].transform.position;
            _map[StartRowIndex][columnIndex].FieldValue = FieldValueType.Snake;
        }
    }

    public List<SnakeCellController> ReturnSnake()
    {
        return _snake;
    }
}