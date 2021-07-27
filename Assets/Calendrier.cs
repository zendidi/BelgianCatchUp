using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendrier : MonoBehaviour
{
    public Button combat1;
    public Button combat2;
    public Button combat3;
    public GameObject UiExpl;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.nbrCombat >= 1)
        {
            UiExpl.SetActive(false);
        }

        if (GameManager.phaseRef == 3)
        {
            Debug.Log(GameManager.nbrCombat);
            switch (GameManager.nbrCombat)
            {
                case 0:
                    combat1.interactable = true;
                    combat2.interactable = false;
                    combat3.interactable = false;
                    break;

                case 1:
                    combat1.interactable = false;
                    combat2.interactable = true;
                    combat3.interactable = false;
                    break;

                case 2:
                    combat1.interactable = false;
                    combat2.interactable = false;
                    combat3.interactable = true;
                    break;

                default:
                    break;
            }

            GameManager.nbrCombat++;
            Debug.Log("After = "+GameManager.nbrCombat);
        }
    }
}
