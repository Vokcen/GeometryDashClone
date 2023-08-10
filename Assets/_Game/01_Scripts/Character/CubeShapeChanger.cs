using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShapeChanger : MonoBehaviour
{

    [SerializeField] private List<Transform> shapeList;

    private void OnEnable()
    {
        EventManager.OnTriggerPortal += OnTriggerPortal;
    }

    private void OnDisable()
    {
        EventManager.OnTriggerPortal -= OnTriggerPortal;

    }

    private void OnTriggerPortal(object sender, MovementMode comingMode)
    {
        foreach (var item in shapeList)
        {
            item.gameObject.SetActive(false);
        }
        shapeList[(int)comingMode].gameObject.SetActive(true);
    }
}
