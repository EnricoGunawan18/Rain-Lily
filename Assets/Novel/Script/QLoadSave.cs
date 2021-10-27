using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QLoadSave : MonoBehaviour
{
	[SerializeField]
	Button QuickLoad;
	[SerializeField]
	Button QuickLoadYes;
	[SerializeField]
	Button QuickLoadNo;

	[SerializeField]
	GameObject QuickLoadAsker;

	[SerializeField]
	LoadDialogue loadDialogue;

	GameObject loadDialogueGameObject;

	// Start is called before the first frame update
	void Start()
	{
		loadDialogueGameObject = GameObject.Find("LoadDialogue");
		loadDialogue = loadDialogueGameObject.GetComponent<LoadDialogue>();

		QuickLoad.onClick.AddListener(QuickLoadClick);
		QuickLoadYes.onClick.AddListener(QuickLoadYesClick);
		QuickLoadNo.onClick.AddListener(QuickLoadNoClick);
	}


	void QuickLoadClick()
	{
		Time.timeScale = 0f;
		QuickLoadAsker.SetActive(true);
	}

	void QuickLoadYesClick()
	{
		int whichFile = PlayerPrefs.GetInt("WhichFile");
		if (whichFile == 1)
		{
			int log = PlayerPrefs.GetInt("FirstLog");
			int pos = PlayerPrefs.GetInt("FirstPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu1");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 2)
		{
			int log = PlayerPrefs.GetInt("SecondLog");
			int pos = PlayerPrefs.GetInt("SecondPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu2");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 3)
		{
			int log = PlayerPrefs.GetInt("ThirdLog");
			int pos = PlayerPrefs.GetInt("ThirdPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu3");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 4)
		{
			int log = PlayerPrefs.GetInt("FourthLog");
			int pos = PlayerPrefs.GetInt("FourthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu4");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 5)
		{
			int log = PlayerPrefs.GetInt("FifthLog");
			int pos = PlayerPrefs.GetInt("FifthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu5");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 6)
		{
			int log = PlayerPrefs.GetInt("SixthLog");
			int pos = PlayerPrefs.GetInt("SixthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu6");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 7)
		{
			int log = PlayerPrefs.GetInt("SeventhLog");
			int pos = PlayerPrefs.GetInt("SeventhPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu7");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 8)
		{
			int log = PlayerPrefs.GetInt("EighthLog");
			int pos = PlayerPrefs.GetInt("EighthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu8");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 9)
		{
			int log = PlayerPrefs.GetInt("NinthLog");
			int pos = PlayerPrefs.GetInt("NinthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu9");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 10)
		{
			int log = PlayerPrefs.GetInt("TenthLog");
			int pos = PlayerPrefs.GetInt("TenthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu10");

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}

		Time.timeScale = 1;
		SceneManager.LoadScene("Novel");
	}

	void QuickLoadNoClick()
	{
		Time.timeScale = 1;
		QuickLoadAsker.SetActive(false);
	}
}
