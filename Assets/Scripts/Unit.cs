using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    
    public string unitName;
    public int unitLevel;

    public int damage;
    public int entertainementPoint;
    //public int entertainementGoal;

    public int maxHP;
    public int currentHP;

    public string charState;


    public void TakeDamage(int dmg)
    {
        Debug.Log("Domage " + dmg);
        //currentHP -= dmg;
        entertainementPoint = dmg;

        //if (currentHP<=0)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
    public void TakeGermanSuplex(int dmg)
    {
        Debug.Log("Domage " + dmg);
        //currentHP -= dmg*2;
        entertainementPoint += dmg*2;

        //if (currentHP<=0)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
    public void Heal(int amout)
    {
        currentHP += amout;

        if (currentHP>maxHP)
        {
            currentHP = maxHP;
        }
    }
    public void Snakecatch(int dmg)
    {
        charState = "ENTRAVE";
        //currentHP -= dmg/2;
        entertainementPoint += dmg/2;

        //if (currentHP <= 0)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
    public int Claim()
    {
        charState = "EXALTE";
        int rand = Random.Range(0, 12);
        return rand;

    }
    public void TakeBodySlam(int dmg)
    {
        //currentHP -= dmg;
        entertainementPoint += dmg;

        //if (currentHP <= 0)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}
