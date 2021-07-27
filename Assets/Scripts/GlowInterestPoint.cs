using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowInterestPoint : MonoBehaviour
{
    public Light lp;
    public bool dejaVisite;
    private Color colorDejaInteraction = Color.blue;
    private Color colorActivable = Color.yellow;
    private Color colorInteraction = Color.green;
    private Color currentColor;
    public float duration = 1f;
    private void Start()
    {
        dejaVisite = false;
        currentColor = colorActivable;
        lp.color = currentColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"|| other.gameObject.tag == "Playeuse")
        {
            lp.color = Color.Lerp(currentColor, colorInteraction, duration);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Playeuse")
        {
            if (!dejaVisite)
            {
                lp.color = Color.Lerp(colorInteraction, colorDejaInteraction, duration);
                dejaVisite = true;

            }
            if (dejaVisite)
            {
                lp.color = Color.Lerp(colorInteraction, colorDejaInteraction, duration);
                currentColor = colorDejaInteraction;
            }
        }
    }


}
