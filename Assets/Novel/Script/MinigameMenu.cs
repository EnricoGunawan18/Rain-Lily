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
    [SerializeField]
    Date dateScript;

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
        int[] date = PlayerPrefsX.GetIntArray("Date");

        if (date[0] == 10 && date[1] == 7)
        {
            SceneManager.LoadScene("Scene_pazzle");
        }
        else
        {
            if (dateScript.lied == 0)
            {
                PlayerPrefs.SetInt("AffUpLied", 1);
            }
            if (dateScript.klein == 0)
            {
                PlayerPrefs.SetInt("AffUpKlein", 1);
            }

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
            if (dateScript.lied == 1)
            {
                PlayerPrefs.SetInt("AffUpLied", 2);
            }
            if (dateScript.klein == 1)
            {
                PlayerPrefs.SetInt("AffUpKlein", 2);
            }

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
            if (dateScript.lied == 2)
            {
                PlayerPrefs.SetInt("AffUpLied", 3);
            }
            if (dateScript.klein == 2)
            {
                PlayerPrefs.SetInt("AffUpKlein", 3);
            }

            PlayerPrefs.SetInt("MiniGame", 6);
            SceneManager.LoadScene("Stage1");

            //PlayerPrefs.SetInt("NovelMenu", 11);
            //SceneManager.LoadScene("Novel");

        }
    }
}
