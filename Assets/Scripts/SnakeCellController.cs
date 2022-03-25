using UnityEngine;

public class SnakeCellController : MonoBehaviour
{
    public int RowIndex { get; set; }
    
    public int ColumnIndex { get; set; }

    public void ChangeIndex(DirectionOfMovement direction)
    {
        if (direction == DirectionOfMovement.Right)
        {
            if (ColumnIndex == 9)
            {
                ColumnIndex = 0;
            }
            else
            {
                ColumnIndex++;
            }
        }
        else if (direction == DirectionOfMovement.Left)
        {
            if (ColumnIndex == 0)
            {
                ColumnIndex = 9;
            }
            else
            {
                ColumnIndex--;
            }
        }
        else if (direction == DirectionOfMovement.Up)
        {
            if (RowIndex == 9)
            {
                RowIndex = 0;
            }
            else
            {
                RowIndex++;
            }
        }
        else if (direction == DirectionOfMovement.Down)
        {
            if (RowIndex == 0)
            {
                RowIndex = 9;
            }
            else
            {
                RowIndex--;
            }
        }
    }
}
