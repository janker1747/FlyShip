using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode FireKey = KeyCode.Mouse1;

    public event Action JumpPressed;
    public event Action FirePressed;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(FireKey))
        {
            FirePressed?.Invoke();
        }
    }
}
