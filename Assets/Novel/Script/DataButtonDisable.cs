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
	GameObject[] NoData;

	[SerializeField]
	Image SaveOrLoad;
	[SerializeField]
	Image[] CharacterImage;

	[SerializeField]
	Sprite[] SaveOrLoadSprite;
	[SerializeField]
	Sprite[] Sprite;

	[SerializeField]
	Text[] Date;
	[SerializeField]
	Text[] CharacterName;

	[SerializeField]
	Button[] Button;

	float[] Lied;
	float[] Klein;
	string[] Name;

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
				NoData[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("NoData").gameObject;
				CharacterImage[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("UI").transform.Find("Character").GetComponent<Image>();
				Date[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("UI").transform.Find("Date").GetComponent<Text>();
				CharacterName[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("UI").transform.Find("PlayerName").GetComponent<Text>();
				Button[(i * 6)+j] = Pages[i].transform.Find($"File ({j})").transform.Find("Button").GetComponent<Button>();
			}
		}

		dateFile = new int[36][];

		Lied = new float[36];
		Klein = new float[36];
		Name = new string[36];

		for(int i = 0; i < 36; i++)
		{
			dateFile[i] = PlayerPrefsX.GetIntArray($"Date{i + 1}");
			Lied[i] = PlayerPrefs.GetFloat($"LiedHeart{i + 1}");
			Klein[i] = PlayerPrefs.GetFloat($"KleinHeart{i + 1}");
            Name[i] = PlayerPrefs.GetString($"PlayerName{i + 1}");
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
				NoData[i].SetActive(true);

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
				NoData[i].SetActive(false);

				for(int j = 0; j < 36; j++)
				{
					Date[j].text = dateFile[j][0].ToString() + "/" + dateFile[j][1].ToString();
					CharacterName[j].text = Name[j];
				}				

				if (Lied[i] < Klein[i])
				{
					CharacterImage[i].sprite = Sprite[2];
				}
				if (Lied[i] > Klein[i])
				{
					CharacterImage[i].sprite = Sprite[1];
				}
				else
				{
					CharacterImage[i].sprite = Sprite[0];
				}
			}
		}
	}
}
