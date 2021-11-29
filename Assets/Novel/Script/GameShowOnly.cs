using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameShowOnly : MonoBehaviour
{
	[SerializeField]
	Button OkayButton;
	[SerializeField]
	Text ShowText;
	[SerializeField]
	LoadDialogue loadDialogue;
	// Start is called before the first frame update
	void Start()
	{
		OkayButton.onClick.AddListener(ButtonClick);
	}

	// Update is called once per frame
	void OnEnable()
	{
		int whichFile = PlayerPrefs.GetInt("WhichFile");
		int startFrom = PlayerPrefs.GetInt("LogNow");
		int[] date = PlayerPrefsX.GetIntArray("Date");
		PlayerPrefs.SetInt("NovelMenu", 12);
		int menu = PlayerPrefs.GetInt("NovelMenu");

		date[1]++;

		if (date[0] == 10 && date[1] == 32)
		{
			date[0] = 11;
			date[1] = 1;
		}
		if (date[0] == 11 && date[1] == 31)
		{
			date[0] = 12;
			date[1] = 1;
		}

		if (whichFile == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("FirstPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("FirstLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date1", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu1", menu);
			PlayerPrefs.SetInt("LiedFail1", LiedFail);
			PlayerPrefs.SetInt("KleinFail1", KleinFail);
			PlayerPrefs.SetInt("Money1", money);
			PlayerPrefs.SetFloat("LiedHeart1", liedAff);
			PlayerPrefs.SetFloat("KleinHeart1", kleinAff);
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber1", cleanNumber);
			PlayerPrefs.SetInt("CookNumber1", cookNumber);
			PlayerPrefs.SetInt("ShopNumber1", shopNumber);
		}
		else if (whichFile == 2)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SecondLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SecondLog", startFrom + loadDialogue.whichLineNow);
			}

			PlayerPrefs.SetInt("SecondPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("SecondLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date2", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber2", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu2", menu);
			PlayerPrefs.SetInt("LiedFail2", LiedFail);
			PlayerPrefs.SetInt("KleinFail2", KleinFail);
			PlayerPrefs.SetInt("Money2", money);
			PlayerPrefs.SetFloat("LiedHeart2", liedAff);
			PlayerPrefs.SetFloat("KleinHeart2", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber2", cleanNumber);
			PlayerPrefs.SetInt("CookNumber2", cookNumber);
			PlayerPrefs.SetInt("ShopNumber2", shopNumber);
		}
		else if (whichFile == 3)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("ThirdLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("ThirdLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("ThirdPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("ThirdLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date3", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber3", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu3", menu);
			PlayerPrefs.SetInt("LiedFail3", LiedFail);
			PlayerPrefs.SetInt("KleinFail3", KleinFail);
			PlayerPrefs.SetInt("Money3", money);
			PlayerPrefs.SetFloat("LiedHeart3", liedAff);
			PlayerPrefs.SetFloat("KleinHeart3", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber3", cleanNumber);
			PlayerPrefs.SetInt("CookNumber3", cookNumber);
			PlayerPrefs.SetInt("ShopNumber3", shopNumber);
		}
		else if (whichFile == 4)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FourthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FourthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("FourthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("FourthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date4", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber4", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu4", menu);
			PlayerPrefs.SetInt("LiedFail4", LiedFail);
			PlayerPrefs.SetInt("KleinFail4", KleinFail);
			PlayerPrefs.SetInt("Money4", money);
			PlayerPrefs.SetFloat("LiedHeart4", liedAff);
			PlayerPrefs.SetFloat("KleinHeart4", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber4", cleanNumber);
			PlayerPrefs.SetInt("CookNumber4", cookNumber);
			PlayerPrefs.SetInt("ShopNumber4", shopNumber);
		}
		else if (whichFile == 5)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FifthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FifthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("FifthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("FifthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date5", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber5", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu5", menu);
			PlayerPrefs.SetInt("LiedFail5", LiedFail);
			PlayerPrefs.SetInt("KleinFail5", KleinFail);
			PlayerPrefs.SetInt("Money5", money);
			PlayerPrefs.SetFloat("LiedHeart5", liedAff);
			PlayerPrefs.SetFloat("KleinHeart5", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber5", cleanNumber);
			PlayerPrefs.SetInt("CookNumber5", cookNumber);
			PlayerPrefs.SetInt("ShopNumber5", shopNumber);
		}
		else if (whichFile == 6)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SixthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SixthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("SixthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("SixthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date6", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber6", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu6", menu);
			PlayerPrefs.SetInt("LiedFail6", LiedFail);
			PlayerPrefs.SetInt("KleinFail6", KleinFail);
			PlayerPrefs.SetInt("Money6", money);
			PlayerPrefs.SetFloat("LiedHeart6", liedAff);
			PlayerPrefs.SetFloat("KleinHeart6", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber6", cleanNumber);
			PlayerPrefs.SetInt("CookNumber6", cookNumber);
			PlayerPrefs.SetInt("ShopNumber6", shopNumber);
		}
		else if (whichFile == 7)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SeventhLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SeventhLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("SeventhPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("SeventhLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date7", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber7", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu7", menu);
			PlayerPrefs.SetInt("LiedFail7", LiedFail);
			PlayerPrefs.SetInt("KleinFail7", KleinFail);
			PlayerPrefs.SetInt("Money7", money);
			PlayerPrefs.SetFloat("LiedHeart7", liedAff);
			PlayerPrefs.SetFloat("KleinHeart7", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber7", cleanNumber);
			PlayerPrefs.SetInt("CookNumber7", cookNumber);
			PlayerPrefs.SetInt("ShopNumber7", shopNumber);
		}
		else if (whichFile == 8)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("EighthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("EighthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("EighthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("EighthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date8", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber8", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu8", menu);
			PlayerPrefs.SetInt("LiedFail8", LiedFail);
			PlayerPrefs.SetInt("KleinFail8", KleinFail);
			PlayerPrefs.SetInt("Money8", money);
			PlayerPrefs.SetFloat("LiedHeart8", liedAff);
			PlayerPrefs.SetFloat("KleinHeart8", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber8", cleanNumber);
			PlayerPrefs.SetInt("CookNumber8", cookNumber);
			PlayerPrefs.SetInt("ShopNumber8", shopNumber);
		}
		else if (whichFile == 9)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("NinthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("NinthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("NinthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("NinthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date9", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber9", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu9", menu);
			PlayerPrefs.SetInt("LiedFail9", LiedFail);
			PlayerPrefs.SetInt("KleinFail9", KleinFail);
			PlayerPrefs.SetInt("Money9", money);
			PlayerPrefs.SetFloat("LiedHeart9", liedAff);
			PlayerPrefs.SetFloat("KleinHeart9", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber9", cleanNumber);
			PlayerPrefs.SetInt("CookNumber9", cookNumber);
			PlayerPrefs.SetInt("ShopNumber9", shopNumber);
		}
		else if (whichFile == 10)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("TenthLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("TenthLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("TenthPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("TenthLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date10", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber10", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu10", menu);
			PlayerPrefs.SetInt("LiedFail10", LiedFail);
			PlayerPrefs.SetInt("KleinFail10", KleinFail);
			PlayerPrefs.SetInt("Money10", money);
			PlayerPrefs.SetFloat("LiedHeart10", liedAff);
			PlayerPrefs.SetFloat("KleinHeart10", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber10", cleanNumber);
			PlayerPrefs.SetInt("CookNumber10", cookNumber);
			PlayerPrefs.SetInt("ShopNumber10", shopNumber);
		}
		else if (whichFile == 0)
		{
			whichFile = 1;

			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + loadDialogue.whichLineNow);
			}
			PlayerPrefs.SetInt("FirstPos", loadDialogue.resetPos);

			int file = PlayerPrefs.GetInt("FirstLog");
			PlayerPrefs.SetInt("LogNow", file);
			
			PlayerPrefsX.SetIntArray("Date1", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("NovelMenu1", menu);
			PlayerPrefs.SetInt("LiedFail1", LiedFail);
			PlayerPrefs.SetInt("KleinFail1", KleinFail);
			PlayerPrefs.SetInt("Money1", money);
			PlayerPrefs.SetFloat("LiedHeart1", liedAff);
			PlayerPrefs.SetFloat("KleinHeart1", kleinAff);
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber1", cleanNumber);
			PlayerPrefs.SetInt("CookNumber1", cookNumber);
			PlayerPrefs.SetInt("ShopNumber1", shopNumber);
		}


		ShowText.text = "プレイデータをセーブデータ" + whichFile.ToString() + "に保存し、タイトルへ戻ります。";

	}

	void ButtonClick()
	{
		SceneManager.LoadScene("TitleScreen");
	}
}
