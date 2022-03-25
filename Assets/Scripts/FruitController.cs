using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private MapController _mapController;

    private SnakeMover _snakeMover;

    private FruitMaker _fruitMaker;

    private List<List<FieldController>> _map;

    public int RowIndex { get; set; }

    public int ColumnIndex { get; set; }

    private void Start()
    {
        _snakeMover.FruitEaten += ChangePositionOfTheFruit;
    }

    private void OnDestroy()
    {
        _snakeMover.FruitEaten += ChangePositionOfTheFruit;
    }

    private void ChangePositionOfTheFruit()
    {
        _map = _mapController.ReturnMap();

        _fruitMaker.FindEmptyField();

        transform.position = _map[_fruitMaker.FruitRowIndex]
            [_fruitMaker.FruitColumnIndex].transform.position;
        _map[_fruitMaker.FruitRowIndex][_fruitMaker.FruitColumnIndex].FieldValue = FieldValueType.Fruit;

        //RowIndex = _fruitMaker.FruitRowIndex;
        //ColumnIndex = _fruitMaker.FruitColumnIndex;
    }

    public void SetMapAndSnakeControllers(MapController mapController, SnakeMover snakeMover, FruitMaker fruitMaker)
    {
        _mapController = mapController;
        _snakeMover = snakeMover;
        _fruitMaker = fruitMaker;
    }
}