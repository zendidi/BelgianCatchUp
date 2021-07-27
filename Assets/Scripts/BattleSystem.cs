using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, DRAW }
public class BattleSystem : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;


    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleHUD entertainementHUD;

    public Button attackButton;
    public Button healButton;
    public Button snakeButton;
    public Button claimButton;

    public string resultatFinal;

    public BattleState state;

    public bool isChoregraphied;
    public List<int> choregraphie;
    public List<int> playerAction;
    public List<string> insulte;
    public bool playerHasToWin;
    public static int moneyToWin;

    void Start()
    {
        moneyToWin = GameManager.moneyToGagner;
        isChoregraphied = false;
        if (playerHasToWin)
        {
            resultatFinal = "WON";
        }
        else
        {
            resultatFinal = "LOST";
        }
        
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()       //SET UP DU COMBAT
    {
        ButtonDisable();
        GameObject playerGO = Instantiate(GameManager.CharacterPrefabCatch, playerBattleStation.position, Quaternion.identity);
        playerGO.AddComponent<Unit>();                                                                                                                    //INSTANCITION DU JOUEUR
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity);          //INSTANCITION DE L'ADVERSAIRE
        enemyGO.AddComponent<Unit>();
        enemyUnit = enemyGO.GetComponent<Unit>();
        playerUnit.damage = 15;

        playerGO.transform.LookAt(enemyGO.transform);
        enemyGO.transform.LookAt(playerGO.transform);

        dialogueText.text = "Mesdames, messieurs, que le combat commence !";      //SET UP DIALOGUE

        //entertainementHUD.rencontre.text = playerUnit.name+ " VERSUS " + enemyUnit.name;

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;                                             //CHANGEMENT D'ETAT -> PLAYERTURN
        PlayerTurn();
    }
    IEnumerator ChokeSlam()      //FONCTION SUR ONATTACKBUTTON 
    {
        if (playerUnit.charState=="EXALTE")                                         //VERIFICATION DE L'ETAT DU JOUEUR
        {                                                                           //SI EXALTE DOUBLE LES DOMMAGES
            playerUnit.damage *= 2;
            playerUnit.charState = "NORMAL";
        }
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage);                      //APPLY DES DEGATS SUR L'ADVERSAIRE
        enemyUnit.TakeDamage(playerUnit.damage);
        entertainementHUD.SetEntertainement(enemyUnit.entertainementPoint);
        
        dialogueText.text = "Mais quelle attaque de " + GameManager.CharacterSceneName + "! On l'a entendue jusqu'ici"; //UPDATE DIALOGUE
        playerAction.Add(1);                                                        //AJOUT A LA LISTE D'ACTION JOUEUR
        yield return new WaitForSeconds(3.5f);
        Debug.Log("NOM PLAYER : " + playerUnit.name);
        state = BattleState.ENEMYTURN;                                          //IF FALSE TOUR DE L'ADVERSAIRE
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerHeal()        //FONCTION SUR ONHEALBUTTON
    {
        playerUnit.Heal(5);                                                         //LE JOUEUR SE SOIGNE DE 5 HP
        //playerHUD.SetHP(playerUnit.currentHP);                                      //UPDATE DU HUD JOUEUR
        dialogueText.text =GameManager.CharacterSceneName + " semble recouvrer ses forces!";                           //UPDATE DIALOGUE

        yield return new WaitForSeconds(3.5f);
        state = BattleState.ENEMYTURN;                                              //PASSAGE AU TOUR ADVERSE
        StartCoroutine(EnemyTurn());
    }

    IEnumerator GermanSuplex()  //FONCTION SUR LE ONSNAKECATCHBUTTON
    {
        if (playerUnit.charState == "EXALTE")                                       //IF ETAT DU JOUEUR EST EXALTE
        {
            playerUnit.damage *= 2;                                                 //DOUBLE LES DEGATS DU JOUEUR
            playerUnit.charState = "NORMAL";                                        //REPASSE L'ETAT DU JOUEUR A NORMAL
        }
        enemyUnit.Snakecatch(playerUnit.damage);
        entertainementHUD.SetEntertainement(enemyUnit.entertainementPoint);                       //APPLY DES DEGATS SUR L'ADVERSAIRE
        Debug.Log("DAMAGE :" + playerUnit.damage);
        dialogueText.text = "Ne regardez pas ça les enfants, "+GameManager.CharacterSceneName + " a littéralement enfoncé la tête de son adversaire dans le sol!";
        playerAction.Add(2);                                                        //AJOUT A LA LISTE D'ACTION JOUEUR
        yield return new WaitForSeconds(3.5f);

        state = BattleState.ENEMYTURN;                                          //IF FALSE TOUR DE L'ADVERSAIRE
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerClaim()       //FONCTION SUR LE CLAIMBUTTON
    {
        int insulteIndex = playerUnit.Claim();                                                                 //LE JOUEUR DOUBLE SES DEGATS
        dialogueText.text = GameManager.CharacterSceneName + " se lance dans les noms d'oiseaux :\n"+ insulte[insulteIndex];      //UPDATE DIALOGUE
        playerUnit.Heal(5);
        //playerHUD.SetHP(playerUnit.currentHP);
        playerAction.Add(3);                                                        //AJOUT A LA LISTE D'ACTION JOUEUR
        yield return new WaitForSeconds(5f);
        state = BattleState.ENEMYTURN;                                                      //PASSAGE AU TOUR ADVERSE
        StartCoroutine(EnemyTurn());
    }

    IEnumerator arbitreTaunt()
    {
        enemyUnit.TakeGermanSuplex(playerUnit.damage);
        bool entertainMAx = entertainementHUD.SetEntertainement(enemyUnit.entertainementPoint);
        //playerUnit.currentHP -= playerUnit.damage;
        
        dialogueText.text = "C'est pas possible! Cette prise est proscrite, que fait l'arbitre?!";
        playerAction.Add(4);                                                        //AJOUT A LA LISTE D'ACTION JOUEUR
        yield return new WaitForSeconds(3.5f);
        if (resultatFinal == "WON")
        {
            if (entertainMAx)
            {
                state = BattleState.WON;                                                //IF TRUE BATTLEWON
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;                                              //PASSAGE AU TOUR ADVERSE
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            state = BattleState.ENEMYTURN;                                              //PASSAGE AU TOUR ADVERSE
            StartCoroutine(EnemyTurn());
        }

    }
    IEnumerator DDT()
    {
        enemyUnit.TakeBodySlam(playerUnit.damage);
        bool entertainementMax = entertainementHUD.SetEntertainement(enemyUnit.entertainementPoint);
        playerUnit.charState = "EXALTE";
        dialogueText.text = GameManager.CharacterSceneName + " monte sur la troisième corde... Il projette son corps! Et voilà le BODY SLAM!";
        playerAction.Add(5);                                                        //AJOUT A LA LISTE D'ACTION JOUEUR
        yield return new WaitForSeconds(3.5f);
        if (entertainementMax && resultatFinal == "WON")                                                                 //VERIFICATION MORT DE L'ADVERSAIRE + DU RESULTAT PREDIFINI
        {
            state = BattleState.WON;                                                //IF TRUE BATTLEWON
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;                                          //IF FALSE TOUR DE L'ADVERSAIRE
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()                //FONCTION DE FIN DE COMBAT
    {
        if (isChoregraphied)
        {
            bool check = ChoregraphieCheck();
            if (check)
            {
                CheckEndBattle();
            }
            else
            {
                entertainementHUD.entertainementSlider.value = 0;
                state = BattleState.START;
                StartCoroutine(SetupBattle());
            }
        }
        else
        {
            CheckEndBattle();
        }
        
    }

    IEnumerator EnemyTurn()         //FONCTION DU TOUR DE L'ADVERSAIRE
    {
        if (enemyUnit.charState=="ENTRAVE")                                 //IF ETAT ADVERSE EST ENTRAVE
        {
            enemyUnit.Snakecatch(playerUnit.damage);
            entertainementHUD.SetEntertainement(enemyUnit.entertainementPoint);              //APPLY LES DEGATS DU JOUEUR A L'ADVERSAIRE
            dialogueText.text = "Il ne sait plus bouger... Il souffre!";            //UPDATE DIALOGUE
            yield return new WaitForSeconds(2.5f);
            enemyUnit.charState = "NORMAL";                                     //IF FALSE ETAT DE L'ADVERSAIRE DEVIENT NORMAL
            state = BattleState.PLAYERTURN;                                     //PASSAGE AU TOUR DU JOUEUR
            PlayerTurn();
        }
        else                                                                //IF ETAT ADVERSE EST NORMAL
        {
            dialogueText.text = "L'adversaire rétorque!";                   //UPDATE DIALOGUE        
            yield return new WaitForSeconds(2.5f);

            int rand = Random.Range(10, 40);
            playerUnit.TakeDamage(rand);
            bool entertainementMax = entertainementHUD.SetEntertainement(playerUnit.entertainementPoint);                   //APPLY LES DEGATS DE L'ADVERSAIRE AU JOUEUR
            yield return new WaitForSeconds(1f);

            if (entertainementMax)                                                             //VERIFICATION MORT DU JOUEUR
            {
                state = BattleState.LOST;                                           //IF MORT BATTLE LOST
                EndBattle();
            }
            else
            {
                state = BattleState.PLAYERTURN;                                     //IF FALSE PASSAGE AU TOUR DU JOUEUR
                PlayerTurn();
            }
        }
        
    }

    void PlayerTurn()               //FONCTION DU TOUR DU JOUEUR
    {
        dialogueText.text = "Mais que va faire " + GameManager.CharacterSceneName + "!";       //UPDATE DIALOGUE
        ButtonEnable();
    }
    public void ChokeslamButton()    //EVENEMENT SUR LE BOUTON ATTACK
    {
        if (state!=BattleState.PLAYERTURN)                                          //IF DIFFERENT TOUR JOUEUR
            return;
        ButtonDisable();
        StartCoroutine(ChokeSlam());                                             //APPELLE LA FONCTION ATTACK DU JOUEUR
    }
    public void OnHealButton()      //EVENEMENT SUR LE BOUTON HEAL
    {
        if (state!=BattleState.PLAYERTURN)
            return;
        ButtonDisable();
        StartCoroutine(PlayerHeal());
    }
    public void GermanSuplexButton()    //EVENEMENT SUR LE BOUTON SNAKE CATCH
    {
        if (state != BattleState.PLAYERTURN)
            return;
        ButtonDisable();
        StartCoroutine(GermanSuplex());
    }

    public void OnClaimButton()         //EVENEMENT SUR LE BOUTON CLAIM
    {
        if (state != BattleState.PLAYERTURN)
            return;
        ButtonDisable();
        StartCoroutine(PlayerClaim());
    }
    public void arbitreTauntButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        ButtonDisable();
        StartCoroutine(arbitreTaunt());
    }
    public void DDT_button()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        ButtonDisable();
        StartCoroutine(DDT());
    }

    public void ButtonDisable()
    {
        attackButton.enabled = false;                                               //DESACTIVATION DES BOUTONS D'ACTIONS
        healButton.enabled = false;
        snakeButton.enabled = false;
        claimButton.enabled = false;
    }
    public void ButtonEnable()
    {
        attackButton.enabled = true;                                               //DESACTIVATION DES BOUTONS D'ACTIONS
        healButton.enabled = true;
        snakeButton.enabled = true;
        claimButton.enabled = true;
    }
    public bool ChoregraphieCheck()
    {
        bool check = false;
        for (int i = 0; i < choregraphie.Count; i++)
        {
            if (playerAction[i] == choregraphie[i])
            {
                check = true;
                
            }          
        }
        return check;
    }           //FONCTION CHECK DE LA LISTE D'ACTION JOUEUR
    public void CheckEndBattle()
    {
        if (state == BattleState.WON)                                                         //IF COMBAT GAGNE
        {
            if (playerHasToWin)
            {
                GameManager.correctResult = true;
                GameManager.money += moneyToWin;
                if (SceneManager.GetActiveScene().name == "SalleCombat3")
                {
                    SceneManager.LoadScene("SceneFin");
                }
                else
                {
                    SceneManager.LoadScene(GameManager.schoolselector);
                }
            }
            else
            {
                GameManager.correctResult = false;
                if (SceneManager.GetActiveScene().name == "SalleCombat3")
                {
                    SceneManager.LoadScene("SceneFin");
                }
                else
                {
                    SceneManager.LoadScene(GameManager.schoolselector);
                }
            }
            
            dialogueText.text = "Et c'est une victoire pour " + GameManager.CharacterSceneName + "!";
        }
        else if (state == BattleState.LOST)                                                   //IF COMBAT PERDU
        {
            if (playerHasToWin)
            {
                GameManager.correctResult = false;
                if (SceneManager.GetActiveScene().name=="SalleCombat3")
                {
                    SceneManager.LoadScene("SceneFin");
                }
                else
                {
                    SceneManager.LoadScene(GameManager.schoolselector);
                }
            }
            else
            {
                GameManager.money += moneyToWin;
                GameManager.correctResult = true;
                if (SceneManager.GetActiveScene().name == "SalleCombat3")
                {
                    SceneManager.LoadScene("SceneFin");
                }
                else
                {
                    SceneManager.LoadScene(GameManager.schoolselector);
                }
            }
            dialogueText.text = GameManager.CharacterSceneName + " est mis à terre, il ne bouge plus... " + enemyUnit.unitName + " est déclaré vainqueur!";
        }
        if (state == BattleState.DRAW)                                                        //IF MATCH NUL
        {
            dialogueText.text = "Oh mon Dieu, ils sont tous les deux à terre... Et c'est un double K.O! Match nul.";
        }
    }        //CHECK DE L'ETAT FINAL DU COMBAT
}