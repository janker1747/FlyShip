using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _ship.transform.position.x + _xOffset;
        transform.position = position;
    }
}
