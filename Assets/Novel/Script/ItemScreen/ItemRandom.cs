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

	[SerializeField]
	GameObject ItemBuyScreen;
	[SerializeField]
	GameObject GiveWhoScreen;
	[SerializeField]
	LoadDialogue loadDialogue;

	string[] itemData;
	string[] itemRow;

	int[] Number = new int[] { 0, 0, 0 };

	List<int> Items;
	int[] ItemNumber;

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
		Items = new List<int>();
		ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

		for (int i = 1; i < 9; i++)
		{
			Items.Add(i);
		}

		for (int i = 0; i < 3; i++)
		{
			Number[i] = Items[Random.Range(0, Items.Count)];
			itemRow = itemData[Number[i]].Split(new char[] { ',' });
			Text[i].text = itemRow[2];
			Money[i].text = itemRow[4];
			Items.Remove(Number[i]);
		}
	}

	void FirstClick()
	{
		ItemNumber[Number[0]]++;

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void SecondClick()
	{
		ItemNumber[Number[1]]++;

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void ThirdClick()
	{
		ItemNumber[Number[2]]++;

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);
	}

	void DontBuy()
	{
		loadDialogue.ItemEffect = true;
		ItemBuyScreen.SetActive(false);
		loadDialogue.AfterShopPrologue();
		loadDialogue.ShowDialogue();
	}
}
