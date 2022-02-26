using UnityEngine;

public class SnakeCellController : MonoBehaviour
{
    public int RowIndex { get; set; }
    
    public int ColumnIndex { get; set; }

    public void ChangeIndex(DirectionOfMovement direction)
    {
        if (direction == DirectionOfMovement.Right)
        {
            ColumnIndex++;
        }
        else if (direction == DirectionOfMovement.Left)
        {
            ColumnIndex--;
        }
        else if (direction == DirectionOfMovement.Up)
        {
            RowIndex++;
        }
        else if (direction == DirectionOfMovement.Down)
        {
            RowIndex--;
        }
    }
}
