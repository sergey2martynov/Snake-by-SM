using System.Collections.Generic;
using UnityEngine;

public class FruitMaker : MonoBehaviour
{
    [SerializeField] private MapController _mapController;

    [SerializeField] private FruitMaker _fruitMaker;

    [SerializeField] private SnakeMover _snakeMover;

    [SerializeField] private GameObject _applePrefab;

    [SerializeField] private RandomIndex _randomIndex;
    
    private List<List<FieldController>> _map;
    
    public int FruitRowIndex { get; set; }
    
    public int FruitColumnIndex { get; set; }

    public void CreateFruit()
    {
        _map = _mapController.ReturnMap();

        FindEmptyField();

        var spawnFruit = Instantiate(_applePrefab, _map[FruitRowIndex][FruitColumnIndex].transform.position,
            Quaternion.identity);
        var fruitController = spawnFruit.GetComponent<FruitController>();
        fruitController.SetMapAndSnakeControllers(_mapController, _snakeMover,_fruitMaker);

        _map[FruitRowIndex][FruitColumnIndex].FieldValue = FieldValueType.Fruit;

        fruitController.RowIndex = FruitRowIndex;
        fruitController.ColumnIndex = FruitColumnIndex;
    }

    public void FindEmptyField()
    {
        FruitRowIndex = _randomIndex.ReturnRandomIndex();

        FruitColumnIndex = _randomIndex.ReturnRandomIndex();

        while (_map[FruitRowIndex][FruitColumnIndex].FieldValue != FieldValueType.Empty)
        {
            FruitRowIndex = _randomIndex.ReturnRandomIndex();

            FruitColumnIndex = _randomIndex.ReturnRandomIndex();
        }
    }
}