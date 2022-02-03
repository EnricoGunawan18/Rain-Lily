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

        Cook.interactable = false;

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
        int[] date = PlayerPrefsX.GetIntArray("Date");

        if (date[0] == 10 && date[1] == 7)
        {
            SceneManager.LoadScene("Scene_pazzle");
        }
        else
        {
            PlayerPrefs.SetInt("MiniGame", 4);
            SceneManager.LoadScene("Scene_pazzle");
        }
    }

    void CookOpen()
    {
        int[] date = PlayerPrefsX.GetIntArray("Date");

        if (date[0] == 10 && date[1] == 8)
        {
            //PlayerPrefs.SetInt("NovelMenu", 0);
            SceneManager.LoadScene("Scene_cook");
        }
        else
        {
            PlayerPrefs.SetInt("MiniGame", 5);
            SceneManager.LoadScene("Scene_cook");
        }
    }

    void ShopOpen()
    {
        int[] date = PlayerPrefsX.GetIntArray("Date");

        if (date[0] == 10 && date[1] == 9)
        {
            SceneManager.LoadScene("Stage1");
        }
        else
        {
            PlayerPrefs.SetInt("MiniGame", 6);
            SceneManager.LoadScene("Stage1");

            //PlayerPrefs.SetInt("NovelMenu", 11);
            //SceneManager.LoadScene("Novel");

        }
    }
}
