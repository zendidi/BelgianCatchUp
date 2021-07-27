using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class CharacterPlayer : MonoBehaviour
{
    public Controls control;
    public NavMeshAgent playerAgent;
    public LayerMask myLayer;

    private Touch theTouch;
    private float timeTouchEnded;
    public Text phaseDisplayText;

    private void Awake()
    {
        control = new Controls();
        control.Gameplay.Deplacement.performed += ctx => goTo();
    }

    //Au cas où le touch du System Input nous les brise trop le Update fait fonctionner le déplacement par mobile.


    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        theTouch = Input.GetTouch(0);
    //        Ray myRay = Camera.main.ScreenPointToRay(theTouch.position);
    //        RaycastHit hit;

    //        if (Physics.Raycast(myRay, out hit, 100))
    //        {
    //            playerAgent.SetDestination(hit.point);
    //        }

    //        Debug.Log("coucou");
    //    }
    //}

    void OnEnable()
    {
        control.Gameplay.Enable();
    }

    void OnDisable()
    {
        control.Gameplay.Disable();
    }

    public void goTo()
    {
        Debug.Log("Function Called");
        Ray myRay;
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (myRay.origin== null)
        {
             myRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        RaycastHit hit;

        if (Physics.Raycast(myRay,out hit,100))
        {
            playerAgent.SetDestination(hit.point);
        }
  
    }
}
