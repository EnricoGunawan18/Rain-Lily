using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FileScreen : MonoBehaviour
{
    [SerializeField]
    Button[] Files;
    [SerializeField]
    Button Save;
    [SerializeField]
    Button MenuSave;
    [SerializeField]
    Button Load;
    [SerializeField]
    Button MenuLoad;
    [SerializeField]
    Button Back;
    [SerializeField]
    GameObject FilePanel;

    LoadDialogue loadDialogue;

    int saveOrLoad = 0;

    // Start is called before the first frame update
    void Start()
    {
        loadDialogue = GameObject.Find("LoadDialogue").GetComponent<LoadDialogue>();

        Save.onClick.AddListener(SavePanel);
        MenuSave.onClick.AddListener(SavePanel);
        Load.onClick.AddListener(LoadPanel);
        MenuLoad.onClick.AddListener(LoadPanel);
        Back.onClick.AddListener(ReturnToGame);

        Files[0].onClick.AddListener(FirstFile);
        Files[1].onClick.AddListener(SecondFile);
        Files[2].onClick.AddListener(ThirdFile);
        Files[3].onClick.AddListener(FourthFile);
        Files[4].onClick.AddListener(FifthFile);
        Files[5].onClick.AddListener(SixthFile);
        Files[6].onClick.AddListener(SeventhFile);
        Files[7].onClick.AddListener(EighthFile);
        Files[8].onClick.AddListener(NinthFile);
        Files[9].onClick.AddListener(TenthFile);
    }


    void SavePanel()
    {
        Time.timeScale = 0;
        saveOrLoad = 1;

        FilePanel.SetActive(true);
    }

    void LoadPanel()
    {
        Time.timeScale = 0;
        saveOrLoad = 2;

        FilePanel.SetActive(true);
    }

    void ReturnToGame()
    {
        Time.timeScale = 1;
        saveOrLoad = 0;

        FilePanel.SetActive(false);
    }

    void FirstFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 1);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date1", date);
            PlayerPrefs.SetInt("NovelMenu1", novelMenu);
            PlayerPrefs.SetInt("FirstPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("FirstLog");
            int pos = PlayerPrefs.GetInt("FirstPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu1");
            string date = PlayerPrefs.GetString("Date1");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber1");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void SecondFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 2);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("SecondLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("SecondLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date2", date);

            PlayerPrefs.SetInt("NovelMenu2", novelMenu);
            PlayerPrefs.SetInt("SecondPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber2", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("SecondLog");
            int pos = PlayerPrefs.GetInt("SecondPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu2");
            string date = PlayerPrefs.GetString("Date2");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber2");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void ThirdFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 3);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("ThirdLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("ThirdLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date3", date);

            PlayerPrefs.SetInt("NovelMenu3", novelMenu);
            PlayerPrefs.SetInt("ThirdPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber3", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("ThirdLog");
            int pos = PlayerPrefs.GetInt("ThirdPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu3");
            string date = PlayerPrefs.GetString("Date3");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber3");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void FourthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 4);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("FourthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("FourthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date4", date);

            PlayerPrefs.SetInt("NovelMenu4", novelMenu);
            PlayerPrefs.SetInt("FourthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber4", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("FourthLog");
            int pos = PlayerPrefs.GetInt("FourthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu4");
            string date = PlayerPrefs.GetString("Date4");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber4");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void FifthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 5);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("FifthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("FifthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date5", date);
            PlayerPrefs.SetInt("NovelMenu5", novelMenu);
            PlayerPrefs.SetInt("FifthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber5", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("FifthLog");
            int pos = PlayerPrefs.GetInt("FifthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu5");
            string date = PlayerPrefs.GetString("Date5");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber5");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void SixthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 6);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("SixthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("SixthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date6", date);

            PlayerPrefs.SetInt("NovelMenu6", novelMenu);
            PlayerPrefs.SetInt("SixthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber6", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("SixthLog");
            int pos = PlayerPrefs.GetInt("SixthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu6");

            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);
            string date = PlayerPrefs.GetString("Date6");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber6");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void SeventhFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 7);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("SeventhLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("SeventhLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date7", date);
            PlayerPrefs.SetInt("NovelMenu7", novelMenu);
            PlayerPrefs.SetInt("SeventhPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber7", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("SeventhLog");
            int pos = PlayerPrefs.GetInt("SeventhPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu7");
            string date = PlayerPrefs.GetString("Date7");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber7");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void EighthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 8);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("EighthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("EighthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date8", date);

            PlayerPrefs.SetInt("NovelMenu8", novelMenu);
            PlayerPrefs.SetInt("EighthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber8", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("EighthLog");
            int pos = PlayerPrefs.GetInt("EighthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu8");
            string date = PlayerPrefs.GetString("Date8");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber8");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void NinthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 9);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("NinthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("NinthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date9", date);
            PlayerPrefs.SetInt("NovelMenu9", novelMenu);
            PlayerPrefs.SetInt("NinthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber9", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("NinthLog");
            int pos = PlayerPrefs.GetInt("NinthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu9");
            string date = PlayerPrefs.GetString("Date9");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber9");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }

    void TenthFile()
    {
        int startFrom = PlayerPrefs.GetInt("LogNow");

        PlayerPrefs.SetInt("WhichFile", 10);

        if (saveOrLoad == 1)
        {
            if (loadDialogue.whichLineNow != 0)
            {
                PlayerPrefs.SetInt("TenthLog", startFrom + loadDialogue.whichLineNow - 1);
            }
            else
            {
                PlayerPrefs.SetInt("TenthLog", startFrom + loadDialogue.whichLineNow);
            }
            int novelMenu = PlayerPrefs.GetInt("NovelMenu");
            string date = PlayerPrefs.GetString("Date");

            PlayerPrefs.SetString("Date10", date);
            PlayerPrefs.SetInt("NovelMenu10", novelMenu);
            PlayerPrefs.SetInt("TenthPos", loadDialogue.resetPos);
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
            PlayerPrefsX.SetIntArray("ItemNumber10", ItemNumber);
        }
        else if (saveOrLoad == 2)
        {
            int log = PlayerPrefs.GetInt("TenthLog");
            int pos = PlayerPrefs.GetInt("TenthPos");
            int novelMenu = PlayerPrefs.GetInt("NovelMenu10");
            string date = PlayerPrefs.GetString("Date10");
            int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber10");

            PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
            PlayerPrefs.SetString("Date", date);
            PlayerPrefs.SetInt("NovelMenu", novelMenu);
            PlayerPrefs.SetInt("LogNow", log);
            PlayerPrefs.SetInt("ResetPos", pos);

            Time.timeScale = 1;
            SceneManager.LoadScene("Novel");
        }

    }
}
