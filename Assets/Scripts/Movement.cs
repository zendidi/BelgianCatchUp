using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject UI;

    void Start()
    {
        LeanTween.moveY(gameObject, 999, 30).setLoopPingPong();
        StartCoroutine(showUIbtn());
    }

    IEnumerator showUIbtn()
    {
        yield return new WaitForSeconds(25);
        UI.SetActive(true);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
