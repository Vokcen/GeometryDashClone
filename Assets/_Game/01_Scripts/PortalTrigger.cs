using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] MovementMode cubeMovementChangeTo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<CubeMovement>(out CubeMovement cube))
        {
            EventManager.OnTriggerPortal(cube, cubeMovementChangeTo);
        }
    }
}
