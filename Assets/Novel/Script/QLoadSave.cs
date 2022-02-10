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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber1");
			int cookNumber = PlayerPrefs.GetInt("CookNumber1");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber1");
			int LiedFail = PlayerPrefs.GetInt("LiedFail1");
			int KleinFail = PlayerPrefs.GetInt("KleinFail1");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip1");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber2");
			int cookNumber = PlayerPrefs.GetInt("CookNumber2");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber2");
			int LiedFail = PlayerPrefs.GetInt("LiedFail2");
			int KleinFail = PlayerPrefs.GetInt("KleinFail2");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip2");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber3");
			int cookNumber = PlayerPrefs.GetInt("CookNumber3");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber3");
			int LiedFail = PlayerPrefs.GetInt("LiedFail3");
			int KleinFail = PlayerPrefs.GetInt("KleinFail3");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip3");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber4");
			int cookNumber = PlayerPrefs.GetInt("CookNumber4");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber4");
			int LiedFail = PlayerPrefs.GetInt("LiedFail4");
			int KleinFail = PlayerPrefs.GetInt("KleinFail4");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip4");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber5");
			int cookNumber = PlayerPrefs.GetInt("CookNumber5");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber5");
			int LiedFail = PlayerPrefs.GetInt("LiedFail5");
			int KleinFail = PlayerPrefs.GetInt("KleinFail5");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip5");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber6");
			int cookNumber = PlayerPrefs.GetInt("CookNumber6");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber6");
			int LiedFail = PlayerPrefs.GetInt("LiedFail6");
			int KleinFail = PlayerPrefs.GetInt("KleinFail6");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip6");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber7");
			int cookNumber = PlayerPrefs.GetInt("CookNumber7");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber7");
			int LiedFail = PlayerPrefs.GetInt("LiedFail7");
			int KleinFail = PlayerPrefs.GetInt("KleinFail7");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip7");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber8");
			int cookNumber = PlayerPrefs.GetInt("CookNumber8");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber8");
			int LiedFail = PlayerPrefs.GetInt("LiedFail8");
			int KleinFail = PlayerPrefs.GetInt("KleinFail8");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip8");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber9");
			int cookNumber = PlayerPrefs.GetInt("CookNumber9");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber9");
			int LiedFail = PlayerPrefs.GetInt("LiedFail9");
			int KleinFail = PlayerPrefs.GetInt("KleinFail9");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip9");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber10");
			int cookNumber = PlayerPrefs.GetInt("CookNumber10");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber10");
			int LiedFail = PlayerPrefs.GetInt("LiedFail10");
			int KleinFail = PlayerPrefs.GetInt("KleinFail10");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip10");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		}
		else if (whichFile == 0)
		{
			int log = PlayerPrefs.GetInt("ZeroLog");
			int pos = PlayerPrefs.GetInt("ZeroPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu0");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber0");
			int[] date = PlayerPrefsX.GetIntArray("Date0");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart0");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart0");
			int money = PlayerPrefs.GetInt("Money0");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber0");
			int cookNumber = PlayerPrefs.GetInt("CookNumber0");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber0");
			int LiedFail = PlayerPrefs.GetInt("LiedFail0");
			int KleinFail = PlayerPrefs.GetInt("KleinFail0");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip0");

			PlayerPrefs.SetInt("LiedFail", LiedFail);
			PlayerPrefs.SetInt("KleinFail", KleinFail);
			PlayerPrefs.SetInt("CleanNumber", cleanNumber);
			PlayerPrefs.SetInt("CookNumber", cookNumber);
			PlayerPrefs.SetInt("ShopNumber", shopNumber);
			PlayerPrefs.SetInt("Money", money);
			PlayerPrefs.SetFloat("LiedHeart", liedAff);
			PlayerPrefs.SetFloat("KleinHeart", kleinAff);
			PlayerPrefsX.SetIntArray("Date", date);
			PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);
			PlayerPrefs.SetString("BackgroundClip", backgroundclip);
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
