using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
    [Header("Param choose character")]
    public GameObject ensembleCam;
    public InputField nameText;
    public int nbrCatcheurs;
    public List<GameObject> prefabsPersos;
    public List<GameObject> prefabsPersosCatch;
    public GameObject slider;

    int ind = -1;
    Vector3 initPos;
    private Vector3 offset = new Vector3(4f, 0f, 0f);
    public GameObject oui;
    public GameObject GMM;

    private void Start()
    {
        initPos = ensembleCam.transform.position;
        ChooseCharac(1);
        GMM.GetComponent<GameManager>().LoadText1();
        oui.GetComponent<MovuUI>().transiActivated();
        StartCoroutine(SliderPlay(1));
    }

    public void LoadSceneInd(int index)
    {
        if (nameText.text != GameManager.CharacterName)
        {
            GameManager.CharacterName = nameText.text;
        }

        GameManager.CharacterPrefab = prefabsPersos[ind];
        GameManager.CharacterPrefabCatch = prefabsPersosCatch[ind];

        StartCoroutine(SliderPlay(0));
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChooseCharac(int sens)
    {
        switch (sens)
        {
            case 0:
                ind--;
                break;

            case 1:
                ind++;
                break;

            default:
                break;
        }

        if (ind < 0)
        {
            ind = nbrCatcheurs-1;
        }

        if (ind > nbrCatcheurs-1)
        {
            ind = 0;
        }

        ensembleCam.transform.position = initPos + (offset * ind);

    }

    IEnumerator SliderPlay(int action)
    {
        if (action == 0)
        {
            slider.LeanMoveX(960, 1f);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Appartement");
        }
        else
        {
            slider.LeanMoveX(-960, 1f);
            yield return new WaitForSeconds(1);
        }

    }

}
