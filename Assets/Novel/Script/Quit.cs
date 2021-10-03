using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField]
    Button TitleReturn;

    [SerializeField]
    LoadDialogue loadDialogue;

    GameObject loadDialogueGameObject;

    // Start is called before the first frame update
    void Start()
    {
        loadDialogueGameObject = GameObject.Find("LoadDialogue");
        loadDialogue = loadDialogueGameObject.GetComponent<LoadDialogue>();

        TitleReturn.onClick.AddListener(ReturnToTitle);
    }

    void ReturnToTitle()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");
        PlayerPrefs.SetInt("LogNow", startFrom + loadDialogue.whichLineNow - 1);
        loadDialogue.whichLineNow = 0;
        Time.timeScale = 1;

        SceneManager.LoadScene("TitleScreen");
    }
}
