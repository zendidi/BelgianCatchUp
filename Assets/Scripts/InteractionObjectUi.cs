using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObjectUi : MonoBehaviour
{

    public float dist;
    public GameObject myUI;
    public GameObject stream;
    public GameObject ExclamPoint;
    protected GameObject myPlayer;


    void OnMouseDown()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        if (!myPlayer)
        {
            myPlayer = GameObject.FindGameObjectWithTag("Playeuse");
        }


        if (Vector3.Distance(myPlayer.transform.position, gameObject.transform.position) < dist)
        {
            myUI.SetActive(true);

            if (ExclamPoint)
            {
                Destroy(ExclamPoint);
            }

            if (stream)
            {
                stream.GetComponent<StreamVideo>().restartVideoStream();
            }
        }
    }
}
