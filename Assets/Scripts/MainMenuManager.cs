using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject Slider;

    public void CallPlay()
    {
        StartCoroutine(Play());
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Play()
    {
        Slider.LeanMoveX(960, 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SelectCharacter");
    }

}
