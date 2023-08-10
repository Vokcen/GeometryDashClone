using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CubeMovement>(out CubeMovement cube))
        {
            print("hit");
            EventManager.OnHitSpike?.Invoke(cube, EventArgs.Empty);
        }
    }

}
