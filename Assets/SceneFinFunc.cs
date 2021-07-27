using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFinFunc : MonoBehaviour
{
    public Text myText;

    void Start()
    {
        myText.text = "On arrive à la fin du semestre, et comme tu peux le voir… tes finances sont loins d’être au vert. Elles te permettent, tout au plus, d’arrondir tes fins de mois. Il y a tout simplement trop peu de matchs, et pas assez d’argent à la clé. Malgré tous tes talents au catch " + GameManager.CharacterSceneName + ", il semblerait bien que tu doives trouver un autre boulot en tant que " + GameManager.CharacterName + ". Ou alors, pourquoi pas alors tenter ta chance à l’étranger? Des circuits professionnels de catch existent au Japon, au Mexique, aux États - Unis, ou en Angleterre.Il est donc venu de prendre le dernier choix de cette aventure dans le monde du catch belge.Il marquera la fin du jeu :";

    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
