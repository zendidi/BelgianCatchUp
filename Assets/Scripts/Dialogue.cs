using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue 
{
    public string name;
    public Sentence[] sentences;
}

[System.Serializable]
public struct Sentence
{
    [TextArea(3, 10)]
    public string phrase;
    public UnityEvent Action;   
}
