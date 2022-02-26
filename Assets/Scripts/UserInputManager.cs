using System;
using UnityEngine;

public class UserInputManager : MonoBehaviour
{
    public event Action<DirectionOfMovement> RightPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightPressed?.Invoke(DirectionOfMovement.Right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RightPressed?.Invoke(DirectionOfMovement.Left);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RightPressed?.Invoke(DirectionOfMovement.Up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RightPressed?.Invoke(DirectionOfMovement.Down);
        }
    }
}