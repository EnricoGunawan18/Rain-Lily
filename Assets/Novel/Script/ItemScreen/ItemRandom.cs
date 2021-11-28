using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRandom : MonoBehaviour
{
	[SerializeField]
	TextAsset ItemLists;
	[SerializeField]
	Text[] Text;
	[SerializeField]
	Text[] Money;

	[SerializeField]
	Button Button1;
	[SerializeField]
	Button Button2;
	[SerializeField]
	Button Button3;
	[SerializeField]
	Button Button4;

	//[SerializeField]


	[SerializeField]
	GameObject ItemBuyScreen;
	[SerializeField]
	GameObject GiveWhoScreen;
	[SerializeField]
	LoadDialogue loadDialogue;

	[SerializeField]
	Text MoneyShow;

	[SerializeField]
	Button[] Disabler;

	string[] itemData;
	string[] itemRow;

	int[] Number = new int[] { 0, 0, 0 };

	int[] Cost = new int[] { 300, 100, 500, 500, 100, 300, 300, 500, 500, 500, 300, 500, 300, 300 };

	List<int> Items;
	int[] ItemNumber;

	int ownedMoney;

	void Awake()
	{
		itemData = ItemLists.text.Split(new char[] { '$' });

		Button1.onClick.AddListener(FirstClick);
		Button2.onClick.AddListener(SecondClick);
		Button3.onClick.AddListener(ThirdClick);
		Button4.onClick.AddListener(DontBuy);
	}

	void OnEnable()
	{
		float liedHeart = PlayerPrefs.GetFloat("LiedHeart");
		float kleinHeart = PlayerPrefs.GetFloat("KleinHeart");

		Items = new List<int>();
		ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

		ownedMoney = PlayerPrefs.GetInt("Money");
		MoneyShow.text = ownedMoney.ToString() + "枚";

		for (int i = 0; i < 8; i++)
		{
			Items.Add(i);
		}
		if (liedHeart >= 50f || kleinHeart >= 50f)
		{
			for (int i = 8; i < 14; i++)
			{
				Items.Add(i);
			}
		}


		for (int i = 0; i < 3; i++)
		{
			Number[i] = Items[Random.Range(0, Items.Count)];
			itemRow = itemData[Number[i] + 1].Split(new char[] { ',' });
			Text[i].text = itemRow[2];
			Money[i].text = itemRow[4];
			Items.Remove(Number[i]);

			if (ownedMoney < Cost[Number[i]])
			{
				Disabler[i].interactable = false;
			}
		}
	}

	void FirstClick()
	{
		ItemNumber[Number[0]]++;
		ownedMoney-= Cost[Number[0]];
		PlayerPrefs.SetInt("Money", ownedMoney);

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void SecondClick()
	{
		ItemNumber[Number[1]]++;
		ownedMoney -= Cost[Number[1]];
		PlayerPrefs.SetInt("Money", ownedMoney);

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void ThirdClick()
	{
		ItemNumber[Number[2]]++;
		ownedMoney -= Cost[Number[2]];
		PlayerPrefs.SetInt("Money", ownedMoney);

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void DontBuy()
	{
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}
}
