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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
