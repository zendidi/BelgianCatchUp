using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public List<GameObject> OpponentCollection;
    public static bool hasToLoose;
    public GameObject battlesys;
    public string saine;
   

    private void Awake()
    {
        if (battlesys)
        {
            switch (saine)
            {
                case "SceneCombatTuto":
                    hasToLoose = true;
                    SelectTutoDude();
                    break;

                case "SalleCombat1":
                    hasToLoose = true;
                    if (GameManager.schoolselector=="BYWS")
                    {
                        SelectdirBYWS();
                    }
                    else if (GameManager.schoolselector == "BWS")
                    {
                        SelectdirBWS();
                    }
                    else
                    {
                        SelectdirWAC();
                    }
                    break;

                    case "SalleCombat2":
                    hasToLoose = true;
                    randomOpponent();
                    break;

                    case "SalleCombat3":
                    hasToLoose = false;
                    randomOpponent();
                    break;
            }
            battlesys.GetComponent<BattleSystem>().playerHasToWin = !hasToLoose;
        }


    }

    public void TutoFight()
    {
        SceneManager.LoadScene("SceneCombatTuto");
    }

    public void dirFight()
    {
        SceneManager.LoadScene("SalleCombat1");
    }

    public  void salle2()
    {
        SceneManager.LoadScene("SalleCombat2");
    }

    public void salle3()
    {
        SceneManager.LoadScene("SalleCombat3");
    }

    public void randomOpponent()
    {
        int rand = Random.Range(4,9);
        battlesys.GetComponent<BattleSystem>().enemyPrefab=OpponentCollection[rand];
    }

    public void SelectTutoDude()
    {
        battlesys.GetComponent<BattleSystem>().enemyPrefab = OpponentCollection[0];
    }
    public void SelectdirWAC()
    {
        battlesys.GetComponent<BattleSystem>().enemyPrefab = OpponentCollection[3];
    }
    public void SelectdirBYWS()
    {
        battlesys.GetComponent<BattleSystem>().enemyPrefab = OpponentCollection[2];
    }
    public void SelectdirBWS()
    {
        battlesys.GetComponent<BattleSystem>().enemyPrefab = OpponentCollection[1];
    }
}
