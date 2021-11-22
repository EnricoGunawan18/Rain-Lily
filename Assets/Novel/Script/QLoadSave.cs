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
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber1");
			int[] date = PlayerPrefsX.GetIntArray("Date1");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart1");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart1");
			int money = PlayerPrefs.GetInt("Money1");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 2)
		{
			int log = PlayerPrefs.GetInt("SecondLog");
			int pos = PlayerPrefs.GetInt("SecondPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu2");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber2");
			int[] date = PlayerPrefsX.GetIntArray("Date2");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart2");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart2");
			int money = PlayerPrefs.GetInt("Money2");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 3)
		{
			int log = PlayerPrefs.GetInt("ThirdLog");
			int pos = PlayerPrefs.GetInt("ThirdPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu3");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber3");
			int[] date = PlayerPrefsX.GetIntArray("Date3");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart3");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart3");
			int money = PlayerPrefs.GetInt("Money3");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 4)
		{
			int log = PlayerPrefs.GetInt("FourthLog");
			int pos = PlayerPrefs.GetInt("FourthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu4");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber4");
			int[] date = PlayerPrefsX.GetIntArray("Date4");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart4");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart4");
			int money = PlayerPrefs.GetInt("Money4");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 5)
		{
			int log = PlayerPrefs.GetInt("FifthLog");
			int pos = PlayerPrefs.GetInt("FifthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu5");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber5");
			int[] date = PlayerPrefsX.GetIntArray("Date5");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart5");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart5");
			int money = PlayerPrefs.GetInt("Money5");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 6)
		{
			int log = PlayerPrefs.GetInt("SixthLog");
			int pos = PlayerPrefs.GetInt("SixthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu6");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber6");
			int[] date = PlayerPrefsX.GetIntArray("Date6");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart6");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart6");
			int money = PlayerPrefs.GetInt("Money6");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 7)
		{
			int log = PlayerPrefs.GetInt("SeventhLog");
			int pos = PlayerPrefs.GetInt("SeventhPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu7");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber7");
			int[] date = PlayerPrefsX.GetIntArray("Date7");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart7");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart7");
			int money = PlayerPrefs.GetInt("Money7");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 8)
		{
			int log = PlayerPrefs.GetInt("EighthLog");
			int pos = PlayerPrefs.GetInt("EighthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu8");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber8");
			int[] date = PlayerPrefsX.GetIntArray("Date8");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart8");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart8");
			int money = PlayerPrefs.GetInt("Money8");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 9)
		{
			int log = PlayerPrefs.GetInt("NinthLog");
			int pos = PlayerPrefs.GetInt("NinthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu9");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber9");
			int[] date = PlayerPrefsX.GetIntArray("Date9");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart9");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart9");
			int money = PlayerPrefs.GetInt("Money9");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
		}
		else if (whichFile == 10)
		{
			int log = PlayerPrefs.GetInt("TenthLog");
			int pos = PlayerPrefs.GetInt("TenthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu10");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber10");
			int[] date = PlayerPrefsX.GetIntArray("Date10");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart10");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart10");
			int money = PlayerPrefs.GetInt("Money10");

			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
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
