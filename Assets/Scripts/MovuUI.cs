using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovuUI : MonoBehaviour
{
    float savePosY;
    void Start()
    {
        savePosY = gameObject.transform.position.y;
    }

    public void transiActivated()
    {
        LeanTween.moveY(gameObject, 550, .75f);
    }

    public void transiDesactivated()
    {
        LeanTween.moveY(gameObject, savePosY, .75f);
    }
}
