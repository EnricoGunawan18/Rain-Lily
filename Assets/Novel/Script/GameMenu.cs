using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    Button Affection;
    [SerializeField]
    Button Items;
    [SerializeField]
    Button Quit;
    [SerializeField]
    Button YesQuit;
    [SerializeField]
    Button NoQuit;
    [SerializeField]
    Button ReturnMiniGame;
    [SerializeField]
    Button Sleep;

    [SerializeField]
    GameObject Menu;
    [SerializeField]
    GameObject AffectionScreen;
    [SerializeField]
    GameObject ItemsScreen;
    [SerializeField]
    GameObject QuitScreen;
    [SerializeField]
    GameObject MiniGameChoose;

    [SerializeField]
    GameObject[] Disable;

    [SerializeField]
    Sprite[] BackGround;
    [SerializeField]
    Image BG;
    // Start is called before the first frame update


    void Start()
    {
        Affection.onClick.AddListener(affectionOpen);
        Items.onClick.AddListener(itemsOpen);
        Quit.onClick.AddListener(quitOpen);
        YesQuit.onClick.AddListener(quitYes);
        NoQuit.onClick.AddListener(quitNo);
        ReturnMiniGame.onClick.AddListener(MiniGameReturn);
        Sleep.onClick.AddListener(NextDay);
    }

    void Update()
    {
        int menu = PlayerPrefs.GetInt("NovelMenu");

        if(menu == 1 || menu == 2 || menu == 3 || menu == 12)
        {
            Disable[0].SetActive(false);
            Disable[1].SetActive(true);
            BG.sprite = BackGround[0];
        }
        else
        {
            Disable[0].SetActive(true);
            Disable[1].SetActive(false);
            BG.sprite = BackGround[1];
        }
    }

    // Update is called once per frame
    void affectionOpen()
    {
        Menu.SetActive(false);
        AffectionScreen.SetActive(true);
    }

    void itemsOpen()
    {
        Menu.SetActive(false);
        ItemsScreen.SetActive(true);
    }

    void quitOpen()
    {
        QuitScreen.SetActive(true);
    }

    void quitYes()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    void quitNo()
    {
        QuitScreen.SetActive(false);
    }

    void MiniGameReturn()
    {
        MiniGameChoose.SetActive(true);
        Menu.SetActive(false);
    }


    void NextDay()
    {
        string date = PlayerPrefs.GetString("Date");
        if (date == "Prologue")
        {
            PlayerPrefs.SetInt("NovelMenu", 12);
            PlayerPrefs.SetString("Date", "10ŒŽ10“ú");
            SceneManager.LoadScene("Novel");
        }
    }
}
