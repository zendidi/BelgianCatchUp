using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue0;
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public Dialogue dialogue5;
    protected bool ready=false;
    protected LayerMask PNJ;

    Dialogue saveZero;

    private void Awake()
    {
        saveZero = dialogue0;
        PNJ = LayerMask.GetMask("PNJ");
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && ready)
        {
            
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo, 100, PNJ))
            {
                
                TriggerDialogue();
            }
        }
    }
    public void TriggerDialogue ()
    {
        ready = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue0);
    }
    
    public void CleanDialog ()
    {
        for (int i = 0; i < dialogue0.sentences.Length; i++)
        {
            dialogue0.sentences[i].phrase = "";
            
        }
    }

    public void addDialog(string[] newSentences)
    {
        for (int i = 0; i < newSentences.Length; i++)
        {
            dialogue0.sentences[i].phrase = newSentences[i];
        }
      
    }

    public void newDialog_0()
    {
        dialogue0 = saveZero;
    }
    public void newDialog_1()
    {
        dialogue0 = dialogue1;
    }

    public void newDialog_2()
    {
        dialogue0 = dialogue2;
    }

    public void newDialog_3()
    {
        dialogue0 = dialogue3;
    }

    public void newDialog_4()
    {
        dialogue0 = dialogue4;
    }

    public void newDialog_5()
    {
        dialogue0 = dialogue5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player"|| other.gameObject.tag=="Playeuse")
        {
            ready = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Playeuse")
        {
            ready = false;
        }        
    }
}
