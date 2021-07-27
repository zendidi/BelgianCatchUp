﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextesNArrateur : ScriptableObject
{
    public Dictionary<string, string> AllTexts;
    private void Awake()
    {
        Dictionary<string, string> AllTexts = new Dictionary<string, string>();
        AllTexts.Add("Message d’accueil", "Let’s get ready to rumble ! Plongez dans les coulisses du catch belge francophone. Créez votre propre avatar, gérez votre carrière, montez sur le ring, et faites passer vos adversaires « par-dessus la troisième corde ! » \n .« Belgian Catch’Up » est un jeu vidéo entièrement basé sur l’enquête journalistique, un newsgame.Réalisée par des étudiants de l’Université libre de Bruxelles et de la Ludus Académie, cette simulation interactive explore l’amateurisme du catch en Belgique. Au travers des dialogues, d’articles et des règles du jeu, vous allez découvrir si la discipline est en bonne voie de se professionnaliser… ou pas.Les épaules sont rivées au sol : 3, 2, 1, c’est fini !Ah non, le doigt est sur la souris : 3, 2, 1, c’est parti !");
        AllTexts.Add("choix du personnage", "Avant de se lancer dans l’aventure, il convient de sélectionner ton avatar parmi les modèles proposés. Mais attention, le choix du sexe va impacter ton parcours dans le monde du catch ! Comme dans la vraie vie, être une femme représente parfois certaines difficultés.");
        AllTexts.Add("Choix fait H", "Bonjour "+ GameManager.CharacterName+" , et bienvenu dans l’aventure de “Belgian Catch’Up”. Il faut que tu saches que toutes les informations présentes dans ce jeu vidéo reflètent ce qu’il se passe vraiment dans l’univers du catch belge. Rien n’est laissé au hasard. Bien… C’est parti !");
        AllTexts.Add("Choix fait F", "Bonjour "+ GameManager.CharacterName+ ", et bienvenue dans l’aventure de “Belgian Catch’Up”. Il faut que tu saches que toutes les informations présentes dans ce jeu vidéo reflètent ce qu’il se passe vraiment dans l’univers du catch belge. Rien n’est laissé au hasard. Bien… C’est parti !");
        AllTexts.Add("Debut jeu", "Tu peux maintenant te déplacer à l’aide de la souris. Clique droit pour bouger et clique gauche pour interagir avec les objets en surbrillance. Essaye de te déplacer jusqu’au magazine, le “Belgian Catch’Up Mag” sur la table et découvre le premier article. Il t’apprendra que le catch américain a beaucoup d’importance pour son petit frère belge. ");
        AllTexts.Add("Fin chapitre 2 H", "Bravo, graine de champion ! Pour une première en public, tu as fait un très bon match, et ton personnage a eu beaucoup de succès. On entendait la foule crier "+ GameManager.CharacterName+ ", " + GameManager.CharacterName + " quand tu es sorti du ring ! Et en plus, regarde en haut à droite de l’écran, tu as gagné 20€. C’est un début modeste vers ton rêve de devenir catcheur professionnel et pouvoir vivre de ta passion. Il est temps d’envisager la suite de ta carrière maintenant ! Puisque tu as un bon niveau, tu peux maintenant participer à des matchs organisés par des fédérations, ou promotions comme on aime dire dans le milieu.Elles organisent des matchs et appellent des catcheurs d’un peu partout.Peut - être toi, qui sait ? Va voir le directeur de ton école pour en parler.Mais n’oublie pas aussi d’aller parler à tout le monde dans la salle.");
        AllTexts.Add("Fin chapitre 2 F", "Bravo, graine de championne ! Pour une première en public, tu as fait un très bon match, et ton personnage a eu beaucoup de succès. On entendait la foule crier " + GameManager.CharacterName + " , " + GameManager.CharacterName + " quand tu es sortie du ring ! Un vrai grand show ! On peut dire que tu sembles être de la même trempe que les meilleures du circuit !. Et en plus, regarde en haut à droite de l’écran, tu as gagné 20€. C’est un début modeste vers ton rêve, devenir catcheuse professionnelle et pouvoir vivre de ta passion. Il est temps d’envisager la suite de ta carrière maintenant. Puisque tu as un bon niveau, tu peux maintenant participer à des matchs organisés par des fédérations ou promotion comme on aime dire dans le milieu.Elles organisent des matchs et appellent des catcheurs d’un peu partout.Peut - être toi, qui sait ? Va voir le directeur de ton école pour en discuter.Mais n’oublie pas aussi d’aller parler à tout le monde dans la salle.");
        AllTexts.Add("Choix Final", "On arrive à la fin du semestre, et comme tu peux le voir… tes finances sont loins d’être au vert. Elles te permettent, tout au plus, d’arrondir tes fins de mois. Il y a tout simplement trop peu de matchs, et pas assez d’argent à la clé. Malgré tous tes talents au catch " + GameManager.CharacterName + " , il semblerait bien que tu doives trouver un autre boulot en tant que [playername]. Ou alors, pourquoi pas alors tenter ta chance à l’étranger ? Des circuits professionnels de catch existent au Japon, au Mexique, aux États-Unis, ou en Angleterre. Il est donc venu de prendre le dernier choix de cette aventure dans le monde du catch belge.Il marquera la fin du jeu :");
        AllTexts.Add("Texte de fin", "L’aventure de Belgian Catch’Up se termine ici ! Vous l’aurez compris, il était impossible de gagner, et ce qu’importe les chemins que vous auriez pu choisir. C’est une rhétorique particulière réalisée avec les règles du jeu vidéo pour vous montrer que devenir catcheur professionnel en Belgique reste une douce utopie. Et au vu des informations que vous aurez pu glaner à travers l’histoire de votre avatar, la situation n’est pas prête de changer. Les problèmes sont simplement trop nombreux : manque de public et d’argent, absence d’une fédération unique, exclusion des subsides culturels et sportifs, diffusion compromise à la télévision, luttes intestines ou encore, mauvaise scénarisation. Néanmoins, un petit espoir subsiste, avec des promotions qui tentent de changer la donne. C’est que le catch belge ne s’avoue pas KO facilement !");
    }
}
