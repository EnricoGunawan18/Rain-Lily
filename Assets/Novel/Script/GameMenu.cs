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
    GameObject Menu;
    [SerializeField]
    GameObject AffectionScreen;
    [SerializeField]
    GameObject ItemsScreen;
    [SerializeField]
    GameObject QuitScreen;
    // Start is called before the first frame update
    void Start()
    {
        Affection.onClick.AddListener(affectionOpen);
        Items.onClick.AddListener(itemsOpen);
        Quit.onClick.AddListener(quitOpen);
        YesQuit.onClick.AddListener(quitYes);
        NoQuit.onClick.AddListener(quitNo);
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
}
