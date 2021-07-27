using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatigueIncoming : MonoBehaviour
{
    protected GameObject player;
    protected string textGirl;
    protected string textBoy;

    public GameObject target;

    private void Start()
    {
        textBoy = "Doucement « John Cena » en herbe ! Un catcheur averti en vaut deux… Alors, avant de monter sur le ring, il convient de bien comprendre la discipline dans laquelle tu t’apprêtes à faire tes premiers pas. \n\nLe catch est un sport spectacle, et ces deux dimensions ne vont pas l’une sans l’autre.\n\nUn sport parce que, si les coups sont retenus et les mouvements exagérés, il faut de vraies aptitudes physiques pour pouvoir encaisser les chutes, réaliser les voltiges et tenir le rythme. C’est souvent la blessure qui attend le catcheur mal préparé.\n\nUn spectacle car tout n’est que jeu de rôle, s’amusant à brouiller le vrai du faux. Les catcheurs y incarnent des personnages hauts en couleur(appelés ‘gimmick’), et doivent pouvoir interagir avec le spectateur. L’art du micro, de la prestance et des fourberies deviennent aussi importants que la cascade sensationnelle.\n\nMais à quoi on reconnait - on un bon catcheur alors ? Pour « The Real Talk » qui arpente les rings depuis six ans, la réponse est basique : « c’est le mec qui fait réagir le public, tout simplement ». Le gars le plus <i>show</i> en somme.\n\nCette introduction au catch effectuée, il est l’heure maintenant de choisir ta future école. Attention, ton choix sera définitif. Pour t’aider, voici la description des trois clubs, avec les commentaires des directeurs de chacun d’eux.\n\n ";
        textGirl = "Doucement « Becky Lynch » en herbe ! Une catcheuse avertie en vaut deux… Alors, avant de monter sur le ring, il convient de bien comprendre la discipline dans laquelle tu t’apprêtes à faire tes premiers pas.\n\nLe catch est un sport spectacle, et ces deux dimensions ne vont pas l’une sans l’autre.\n\nUn sport parce que, si les coups sont retenus et les mouvements exagérés, il faut de vraies aptitudes physiques pour pouvoir encaisser les chutes, réaliser les voltiges et tenir le rythme.C’est souvent la blessure qui attend la catcheuse mal préparée.\n\nUn spectacle car tout n’est que jeu de rôle, s’amusant à brouiller le vrai du faux. Les catcheuses y incarnent des personnages hauts en couleur(appelés ‘gimmick’), et doivent pouvoir interagir avec le spectateur. L’art du micro, de la prestance et des fourberies deviennent aussi importants que la cascade sensationnelle.\n\nMais à quoi on reconnait-on une bonne catcheuse alors ? Pour « The Real Talk » qui arpente les rings depuis six ans, la réponse est basique : « c’est celle qui fait réagir le public, tout simplement ». La fille la plus <i>show</i> en somme.\n\nCette introduction au catch effectuée, il est l’heure maintenant de choisir ta future école. Attention, ton choix sera définitif. Pour t’aider, voici la description des trois clubs, avec les commentaires des directeurs de chacun d’eux.";


   player = GameObject.FindGameObjectWithTag("Playeuse");
        if (player != null)
        {
            target.GetComponent<Text>().text = textGirl;
        }
        else
        {
            target.GetComponent<Text>().text = textBoy;
        }
    }
}
