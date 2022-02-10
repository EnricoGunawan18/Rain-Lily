using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionScript : MonoBehaviour
{
	[SerializeField]
	TextAsset DataText;

	[SerializeField]
	Scrollbar LiedBar;
	[SerializeField]
	Scrollbar KleinBar;

	[SerializeField]
	Text[] TextField;

	string[] data;
	string[] row;

	List<Dialogue> TextList;

	Dialogue dial;

	void OnEnable()
	{
		float LiedAffection = PlayerPrefs.GetFloat("LiedHeart");
		float KleinAffection = PlayerPrefs.GetFloat("KleinHeart");
		int countClean = PlayerPrefs.GetInt("CleanNumber");
		int countCook = PlayerPrefs.GetInt("CookNumber");
		int countShop = PlayerPrefs.GetInt("ShopNumber");
		int[] date = PlayerPrefsX.GetIntArray("Date");
		int LiedFail = PlayerPrefs.GetInt("LiedFail");
		int KleinFail = PlayerPrefs.GetInt("KleinFail");

		TextList = new List<Dialogue>();

		for (int i = 1; i < 25; i++)
		{
			data = DataText.text.Split(new char[] { '$' });

			row = data[i].Split(new char[] { ',' });

			dial = new Dialogue();
			dial.effect = row[1];

			TextList.Add(dial);
		}

		LiedBar.size = LiedAffection * 0.01f;
		KleinBar.size = KleinAffection * 0.01f;

		if (date[0] == 10 && date[1] <= 15)
		{
			TextField[0].text = TextList[0].effect;
		}
		else if (date[0] == 10 && date[1] <= 20 && LiedFail == 0)
		{
			TextField[0].text = TextList[1].effect;
		}
		else if (date[0] == 10 && date[1] <= 30 && LiedFail == 0)
		{
			TextField[0].text = TextList[2].effect;
		}
		else if (((date[0] == 10 && date[1] == 31) || (date[0] == 11 && date[1] <= 8)) && LiedFail == 0)
		{
			TextField[0].text = TextList[3].effect;
		}
		else if (date[0] == 11 && date[1] <= 15 && LiedFail == 0)
		{
			TextField[0].text = TextList[4].effect;
		}
		else if (date[0] == 11 && date[1] <= 17 && LiedFail == 0)
		{
			TextField[0].text = TextList[5].effect;
		}
		else if (date[0] == 11 && date[1] <= 25 && LiedFail == 0)
		{
			TextField[0].text = TextList[6].effect;
		}
		else if (date[0] == 11 && date[1] <= 30 && LiedFail == 0)
		{
			TextField[0].text = TextList[7].effect;
		}
		else if (date[0] == 12 && date[1] <= 3 && LiedFail == 0)
		{
			TextField[0].text = TextList[8].effect;
		}
		else if (date[0] == 12 && date[1] <= 6 && LiedFail == 0)
		{
			TextField[0].text = TextList[9].effect;
		}
		else if (date[0] == 12 && date[1] <= 9 && LiedFail == 0)
		{
			TextField[0].text = TextList[10].effect;
		}
		else
		{
			TextField[0].text = TextList[24].effect;
		}


		if (date[0] == 10 && date[1] <= 16)
		{
			TextField[1].text = TextList[11].effect;
		}
		else if (date[0] == 10 && date[1] <= 18 && KleinFail == 0)
		{
			TextField[1].text = TextList[12].effect;
		}
		else if (date[0] == 10 && date[1] <= 25 && KleinFail == 0)
		{
			TextField[1].text = TextList[13].effect;
		}
		else if (date[0] == 10 && date[1] <= 31 && KleinFail == 0)
		{
			TextField[1].text = TextList[14].effect;
		}
		else if (date[0] == 11 && date[1] <= 3 && KleinFail == 0)
		{
			TextField[1].text = TextList[14].effect;
		}
		else if (date[0] == 11 && date[1] <= 10 && KleinFail == 0)
		{
			TextField[1].text = TextList[15].effect;
		}
		else if (date[0] == 11 && date[1] <= 15 && KleinFail == 0)
		{
			TextField[1].text = TextList[16].effect;
		}
		else if (date[0] == 11 && date[1] <= 20 && KleinFail == 0)
		{
			TextField[1].text = TextList[17].effect;
		}
		else if (date[0] == 11 && date[1] <= 27 && KleinFail == 0)
		{
			TextField[1].text = TextList[18].effect;
		}
		else if (date[0] == 11 && date[1] <= 30 && KleinFail == 0)
		{
			TextField[1].text = TextList[19].effect;
		}
		else if (date[0] == 12 && date[1] <= 3 && KleinFail == 0)
		{
			TextField[1].text = TextList[19].effect;
		}
		else if (date[0] == 12 && date[1] <= 7 && KleinFail == 0)
		{
			TextField[1].text = TextList[20].effect;
		}
		else if (date[0] == 12 && date[1] <= 9 && KleinFail == 0)
		{
			TextField[1].text = TextList[21].effect;
		}
		else
		{
			TextField[1].text = TextList[24].effect;
		}

	}
}
