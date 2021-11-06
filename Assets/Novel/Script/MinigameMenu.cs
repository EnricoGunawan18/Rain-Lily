using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameMenu : MonoBehaviour
{
    [SerializeField]
    Button Menu;
    [SerializeField]
    Button Clean;
    [SerializeField]
    Button Cook;
    [SerializeField]
    Button Shop;
    [SerializeField]
    GameObject MinigameChoose;
    [SerializeField]
    GameObject Menus;

    DialogueManager dialogueManager;

    [SerializeField]
    public AutoScroll autoScroll;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("LoadDialogue").GetComponent<DialogueManager>();

        Menu.onClick.AddListener(MenuOpen);
        Clean.onClick.AddListener(CleanOpen);
        Cook.onClick.AddListener(CookOpen);
        Shop.onClick.AddListener(ShopOpen);
    }

    // Update is called once per frame
    void MenuOpen()
    {
        MinigameChoose.SetActive(false);
        Menus.SetActive(true);
    }

    void CleanOpen()
    {
        string date = PlayerPrefs.GetString("Date");

        if (date == "Prologue")
        {
            MinigameChoose.SetActive(false);
            PlayerPrefs.SetInt("NovelMenu", 6);
            dialogueManager.dialogueSpeed = 25f;
            autoScroll.automated = false;
        }
        else
        {
            SceneManager.LoadScene("Scene_pazle");
        }
    }

    void CookOpen()
    {
        string date = PlayerPrefs.GetString("Date");

        if (date == "Prologue")
        {
            MinigameChoose.SetActive(false);
            PlayerPrefs.SetInt("NovelMenu", 8);
            dialogueManager.dialogueSpeed = 25f;
            autoScroll.automated = false;
        }
        else
        {
            SceneManager.LoadScene("Stage1");
        }
    }

    void ShopOpen()
    {
        string date = PlayerPrefs.GetString("Date");

        if (date == "Prologue")
        {
            MinigameChoose.SetActive(false);
            PlayerPrefs.SetInt("NovelMenu", 7);
            dialogueManager.dialogueSpeed = 25f;
            autoScroll.automated = false;
        }
        else
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}