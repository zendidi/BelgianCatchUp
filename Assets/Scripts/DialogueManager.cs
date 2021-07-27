using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;

    protected Queue<Sentence> Sentences;
    public GameObject DialogBox;


    void Awake()
    {
        Sentences = new Queue<Sentence>();
    }

    public void StartDialogue (Dialogue dialogue)
       {
        LeanTween.moveY(DialogBox, 220, 1.5f).setEaseOutElastic();
        nameText.text = dialogue.name;
        Sentences.Clear();

        foreach(Sentence sentence in dialogue.sentences)
        {  
            Sentences.Enqueue(sentence);          
        }

        DisplayNextSentence();
       }

    public void DisplayNextSentence()
    {
        if (Sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        
        Sentence sentence = Sentences.Dequeue();
        string FinalString;
        string newString = sentence.phrase.Replace("PlayerName", GameManager.CharacterName);
        FinalString = newString;
        string newString2 = FinalString.Replace("PlayerPseudo", GameManager.CharacterSceneName);
        FinalString = newString2;
        if (sentence.phrase=="")
        {
            sentence.Action.Invoke();
            EndDialogue();
            return;
        }

        if (sentence.phrase.ToCharArray()[0] == '0')
        {
         sentence.Action.Invoke();
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(FinalString));
        
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        LeanTween.moveY(DialogBox, -750, 1.5f).setEaseOutElastic();

        Debug.Log("Qui parle ? " + nameText.text);
        if (nameText.text == "Directeur")
        {
            if (GameManager.phaseRef == 1)
            {
                GameManager.btnCombatTuto.SetActive(true);
            }

            if (GameManager.phaseRef == 2)
            {
                GameManager.btnCombatDir.SetActive(true);
            }
        }

    }
}
