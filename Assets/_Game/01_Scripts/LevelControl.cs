using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;
using DG.Tweening;

public class LevelControl : MonoBehaviour
{
    [SerializeField]private bool isLeft;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Struct"))
        {
            if(isLeft)
            {
               
                other.transform.DOScale(Vector3.zero, .3f);
                other.transform.DOScale(Vector3.one, .1f).SetDelay(1);

            }
            else
            {

               
                other.transform.localScale = Vector3.zero;
                other.transform.DOScale(Vector3.one, .5f);


            }
        }
    }
    
}
