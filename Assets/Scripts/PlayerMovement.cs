using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    protected LayerMask Sol;
    protected NavMeshAgent monAgent;
    protected Camera mainCam;
    protected Animator playerAnimator;
    protected bool isWalking = false;
    Vector3 offset;

    void Start()
    {
        offset = new Vector3(15f, 28.5f, 10.5f);
        monAgent = GetComponent<NavMeshAgent>();
        Sol = LayerMask.GetMask("Sol");
        mainCam = Camera.main;
        offset = mainCam.transform.position - gameObject.transform.position;
        playerAnimator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.position = gameObject.transform.position + offset;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(1))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(myRay, out hitInfo, 100, Sol))
                {
                    monAgent.SetDestination(hitInfo.point);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            GameManager.phaseRef = 1;
        }

        if (monAgent.hasPath)
        {
            isWalking = true;
        }

        playerAnimator.SetBool("walk", isWalking);

        isWalking = false;
    }
}
