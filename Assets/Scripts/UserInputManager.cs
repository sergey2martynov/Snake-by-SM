using System;
using UnityEngine;

public class UserInputManager : MonoBehaviour
{
    public event Action<DirectionOfMovement> ArrowPressed;

    public event Action EscapePressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ArrowPressed?.Invoke(DirectionOfMovement.Right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ArrowPressed?.Invoke(DirectionOfMovement.Left);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ArrowPressed?.Invoke(DirectionOfMovement.Up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ArrowPressed?.Invoke(DirectionOfMovement.Down);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed?.Invoke();
        }
    }
}