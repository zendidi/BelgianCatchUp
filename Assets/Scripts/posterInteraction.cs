using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posterInteraction : MonoBehaviour
{
    public GameObject InterfaceInfoPoster;
    public GameObject ExclamPoint;
    private float saveposY;
    protected LayerMask poster;
    private bool isOnPosition=false;

   
    private void Start()
    {
        saveposY=InterfaceInfoPoster.transform.position.y;
        poster = LayerMask.GetMask("poster");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isOnPosition)
        {
            if (ExclamPoint)
            {
                Destroy(ExclamPoint);
            }
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo, 100,poster))
            {
                LeanTween.moveY(InterfaceInfoPoster, 500, .75f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player" || other.gameObject.tag=="Playeuse")
        {
            isOnPosition = true;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Playeuse")
        {
            isOnPosition = false;
        }
    }

    public void transiActivated()
    {
        LeanTween.moveY(InterfaceInfoPoster, 500, .75f);
    }

    public void transiDesactivated()
    {
        LeanTween.moveY(InterfaceInfoPoster, saveposY, .75f);
    }
}
