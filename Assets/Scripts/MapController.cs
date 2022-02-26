using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    [SerializeField] private GameObject _fieldPrefab;

    [SerializeField] private GameObject _parentGameFields;

    private List<FieldController> _columns;

    private List<List<FieldController>> _rows;

    private int _numberOfRows = 10;
    
    private int _numberOfColumns = 10;

    public void CreateAGameMap()
    {
        _rows = new List<List<FieldController>>(_numberOfRows);

        for (int rowIndex = 0; rowIndex < _numberOfRows; rowIndex++)
        {
            _columns = new List<FieldController>(_numberOfColumns);
            
            for (int columnIndex = 0; columnIndex < _numberOfColumns; columnIndex++)
            {
                var fieldPositionX = columnIndex;
                var fieldPositionY = rowIndex;
                var spawnField = Instantiate(_fieldPrefab, new Vector2(fieldPositionX, fieldPositionY), Quaternion.identity, _parentGameFields.transform);
                _columns.Add(spawnField.GetComponent<FieldController>());
            }
            _rows.Add(_columns);
        }
    }

    public List<List<FieldController>> ReturnField()
    {
        return _rows;
    }

    public FieldController ReturnFieldToTheRight(int rowIndex, int columnIndex)
    {
        return _rows[rowIndex][columnIndex];
    }
}
