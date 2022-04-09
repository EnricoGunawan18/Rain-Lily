using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
	[SerializeField]
	Text MonthText;
	[SerializeField]
	Text DayText;
	[SerializeField]
	GameObject LiedImage;
	[SerializeField]
	GameObject KleinImage;

	public int lied, klein;
	RectTransform liedPos;
	RectTransform kleinPos;

	// Update is called once per frame
	void OnEnable()
	{
		int menu = PlayerPrefs.GetInt("NovelMenu");
		int[] date = PlayerPrefsX.GetIntArray("Date");
		List<int> Aff = new List<int>(new int[] { 0, 1, 2 });


		lied = Aff[Random.Range(0, Aff.Count)];
		Aff.Remove(lied);
		klein = Aff[Random.Range(0, Aff.Count)];

		liedPos = LiedImage.GetComponent<RectTransform>();
		kleinPos = KleinImage.GetComponent<RectTransform>();

		Vector2 posLied = liedPos.anchoredPosition;
		Vector2 posKlein = kleinPos.anchoredPosition;

		for (int i = 0; i < 3; i++)
		{
			if (lied == i)
			{
				posLied.y -= i * 200;
				liedPos.anchoredPosition = posLied;
			}

			if (klein == i)
			{
				posKlein.y -= i * 200;
				kleinPos.anchoredPosition = posKlein;
			}
		}




		if (menu == 1)
		{
			MonthText.text = "10";
			DayText.text = "7";
		}
		else if (menu == 2)
		{
			MonthText.text = "10";
			DayText.text = "8";
		}
		else if (menu == 3)
		{
			MonthText.text = "10";
			DayText.text = "9";
		}
		else
		{
			MonthText.text = date[0].ToString();
			DayText.text = date[1].ToString();
		}
	}


	void OnDisable()
	{
		liedPos.anchoredPosition = new Vector2(-100, 150);
		kleinPos.anchoredPosition = new Vector2(-100, 150);
	}
}
