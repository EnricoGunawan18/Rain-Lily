using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataButtonDisable : MonoBehaviour
{
	[SerializeField]
	GameObject[] Pages;
	[SerializeField]
	GameObject[] UICluster;

	[SerializeField]
	Image SaveOrLoad;

	[SerializeField]
	Sprite[] SaveOrLoadSprite;
	[SerializeField]
	Sprite[] Sprite;

	[SerializeField]
	Text[] Date;

	[SerializeField]
	Button[] Button;

	float[] Lied;
	float[] Klein;

	int[][] dateFile;

	[SerializeField]
	FileScreen fileScreen;

	void OnEnable()
	{

		for(int i = 0; i < 6; i++)
		{
			for(int j = 0; j < 6; j++)
			{
				UICluster[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("UI").gameObject;
				Date[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("UI").transform.Find("Date").GetComponent<Text>();;
				Button[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("Button").GetComponent<Button>();
			}
		}

		dateFile = new int[36][];

		Lied = new float[36];
		Klein = new float[36];

		for(int i = 0; i < 36; i++)
		{
			dateFile[i] = PlayerPrefsX.GetIntArray($"Date{i}");
			Lied[i] = PlayerPrefs.GetFloat($"LiedHeart{i}");
			Klein[i] = PlayerPrefs.GetFloat($"KleinHeart{i}");
		}


		if (fileScreen.saveOrLoad == 2)
		{
			SaveOrLoad.sprite = SaveOrLoadSprite[0];
		}
		else if(fileScreen.saveOrLoad == 1)
		{
			SaveOrLoad.sprite = SaveOrLoadSprite[1];
		}


		for (int i = 0; i < 36; i++)
		{
			if (dateFile[i][0] == 0)
			{
				UICluster[i].SetActive(false);

				if (fileScreen.saveOrLoad == 2)
				{
					Button[i].interactable = false;
				}
				else
				{
					Button[i].interactable = true;
				}
			}
			else
			{
				UICluster[i].SetActive(true);

				for(int j = 0; j < 36; j++)
				{
					Date[j].text = dateFile[j][0].ToString() + "/" + dateFile[j][1].ToString();
				}				

				if (Lied[i] < Klein[i])
				{
				}
				else
				{
				}
			}
		}
	}
}
