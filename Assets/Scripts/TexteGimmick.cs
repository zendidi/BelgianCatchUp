using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexteGimmick : MonoBehaviour
{
    public InputField sceneName;
    public Text myTxt;

    private void Start()
    {
        myTxt.text = "Tu te doutes bien que monter sur le ring en tant que " + GameManager.CharacterName + " ne va pas vraiment enthousiasmer le public. Alors, maintenant que tu rentres dans le monde du catch, il faut te créer un personnage. C’est ce qu’on appelle dans le milieu, une gimmick. Pour t’aider à trouver ton nom de scène, voici l’exemple de deux gimmicks  du catch belge. \n <size=50><b>« Super Peggy », la dompteuse du vent </b></size>\n « Enfant, je savais que si un jour je devenais une super-héroïne, mon nom serait ‘Peggy’. Tout le monde se moquait de ma guide scoute parce qu’elle portait ce nom, mais elle restait cool. Ça m’a marquée » explique Marijs Boulogne. Des années plus tard, un voyage initiatique en Australie et… des pinces à linge finissent de la convaincre que ce nom est fait pour elle. « Je suis revenue de là - bas comme un grand arbre, alors que je n’étais qu’un petit brin d’herbe. Dans ce pays immense, pour suspendre le linge, il faut des grosses pinces en fer ou en bois parce qu’il y a énormément de vent. On les appelle des ‘pegs’. Peggy, c’est donc comme un symbole de la femme australienne: forte comme ces pinces qui ne lâchent jamais ! ». Sur le ring avec sa tenue or et mauve constellée de brillants, ‘Super Peggy’ scintille comme une étoile. Comme une super - héroïne à laquelle les enfants peuvent s’identifier. \n <size=50><b>« Légion », le marteau du ring</b></size> \n Presque deux mètres de haut pour 115 kilos de muscle: les cordes du ring tremblent sous les pas de « Légion ». Boxeur dans une autre vie, Jean - François a puisé dans la culture populaire de sa jeunesse pour créer sa gimmick: « J’ai grandi avec les super - héros et les monstres qu’on voyait à la télé dans les années 80 et 90.J’étais aussi un grand fan du catcheur Kane. J’aimais bien son masque ». Le résultat est impressionnant. « Légion » est une sorte de sombre Goliath aux allures de Batman, Dark Vador, Browly (Dragon Ball Z) et Hellraiser. Sa tête, entièrement recouverte d’un masque noir, finit d’ancrer son personnage du côté des méchants du ring. Pourtant, il peut parfois incarner le rôle du « gentil ». Après tout, Batman est bien un super-héros.";
    }

    public void chooseSceneName()
    {
        GameManager.CharacterSceneName = sceneName.text;
    }
}
