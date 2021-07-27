using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject VideoCheck;
    public GameObject DM;
    public GameObject GMM;
    public GameObject Narrateur;
    public GameObject Directeur;
    public GameObject slider;
    protected static bool firstTime = true;

    void Start()
    {
        StartCoroutine(SliderPlay(1));

        GameObject tempPerso = Instantiate(GameManager.CharacterPrefab, spawner.transform.position,spawner.transform.rotation);
        tempPerso.transform.localScale = spawner.transform.localScale;
        tempPerso.name = GameManager.CharacterName;
        tempPerso.AddComponent<PlayerMovement>();
        tempPerso.AddComponent<NavMeshAgent>();
        tempPerso.GetComponent<NavMeshAgent>().speed = 9f;
        Destroy(spawner);
        //DM.GetComponent<DialogueTrigger>().TriggerDialogue();
        if (SceneManager.GetActiveScene().name=="Appartement")
        {
            
            if (tempPerso.tag=="Playeuse")
            {
                VideoCheck.GetComponent<StreamVideo>().WomenVideo();
            }
            
            GMM.GetComponent<GameManager>().LoadText2();           
        }
        else if (SceneManager.GetActiveScene().name != "Appartement" && firstTime)
        {
            firstTime = !firstTime;
            if (GameManager.CharacterPrefab.tag=="Playeuse")
            {
                Directeur.GetComponent<DialogueTrigger>().newDialog_1();
            }
            // première entrée dans l'école
        }
        else if (SceneManager.GetActiveScene().name != "Appartement" && !firstTime)
        {
            // respawn entrée dans l'école
        }

    }

    IEnumerator SliderPlay(int action)
    {
        if (action == 0)
        {
            slider.LeanMoveX(960, 1f);
            yield return new WaitForSeconds(1);
        }
        else
        {
            slider.LeanMoveX(-960, 1f);
            yield return new WaitForSeconds(1);
        }

    }

}
