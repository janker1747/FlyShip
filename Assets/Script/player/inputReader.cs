using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpPressed;
    public event Action FirePressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FirePressed?.Invoke();
        }
    }
}
