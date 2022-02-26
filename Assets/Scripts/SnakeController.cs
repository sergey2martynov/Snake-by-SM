using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private MapController _mapController;

    [SerializeField] private GameObject _snakeCellPrefab;

    private List<SnakeCellController> _snake;

    private List<List<FieldController>> _rows;
    
    private const int StartRowIndex = 3;

    private const int IndexDifference = 2;

    public void CreateASnake ()
    {
        _rows = _mapController.ReturnField();
        
        _snake = new List<SnakeCellController>();

        for (int cellIndex = 0; cellIndex < 3; cellIndex++)
        {
            var columnIndex = cellIndex + IndexDifference;
            var spawnCell = Instantiate(_snakeCellPrefab, _rows[StartRowIndex][columnIndex].gameObject.transform.position,
                Quaternion.identity);
            
            _snake.Add(spawnCell.GetComponent<SnakeCellController>());
            
            _snake[cellIndex].RowIndex = StartRowIndex;
            _snake[cellIndex].ColumnIndex = columnIndex;
        }
    }

    public List<SnakeCellController> ReturnSnake()
    {
        return _snake;
    }
}
