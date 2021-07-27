using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text rencontre;

    //public Text levelText;
    //public Slider hpSlider;
    public Slider entertainementSlider;

    //public void SetHUD(Unit unit)
    //{
    //    entertainementSlider.value += unit.entertainementPoint;
    //    entertainementSlider.maxValue = 500;
    //    //nameText.text = unit.unitName;
    //    //levelText.text = "Lvl " + unit.unitLevel;
    //    //hpSlider.maxValue = unit.maxHP;
    //    //hpSlider.value = unit.currentHP;
    //}

    //public void SetHP(int hp)
    //{
    //    hpSlider.value = hp;
    //}
    private void Awake()
    {
        entertainementSlider.maxValue = 175;
    }
    public bool SetEntertainement(int entertain)
    {
        entertainementSlider.value += entertain;
        if (entertainementSlider.value>=entertainementSlider.maxValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
