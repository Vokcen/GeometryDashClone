using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{


    
    private void OnEnable()
    {
        EventManager.OnHitSpike += OnHitSpike;
    }

    private void OnHitSpike(object sender, EventArgs e)
    {
        CubeMovement cube = (CubeMovement)sender;

        cube.transform.position = transform.position;
    }

    private void OnDisable()
    {
        EventManager.OnHitSpike -= OnHitSpike;
    }

}
