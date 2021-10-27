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

	public ItemList il;

	string[] itemData;
	string[] itemRow;

	int[] Number = new int[] { 0, 0, 0 };

	List<int> Items;
	int[] ItemNumber;

	//Start is called before the first frame update
	void OnEnable()
	{
		Items = new List<int>();
		ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

		itemData = ItemLists.text.Split(new char[] { '$' });

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
			//ItemNumber[Number[i]]++;
		}

		Button1.onClick.AddListener(FirstClick);
		Button2.onClick.AddListener(SecondClick);
		Button3.onClick.AddListener(ThirdClick);
		Button4.onClick.AddListener(DontBuy);

		//
		//il = new ItemList();
		//int.TryParse(itemRow[0], out il.id);
		//il.itemName = itemRow[1];
		//il.itemDescription = itemRow[2];
		//il.price = itemRow[3];
		//il.effects = itemRow[4];
		//il.random = itemRow[5];

	}

	void FirstClick()
	{
		ItemNumber[Number[0]]++;

		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		ItemBuyScreen.SetActive(false);
		GiveWhoScreen.SetActive(true);

		//for (int i = 0; i < 14; i++)
		//{
		//	Debug.Log(ItemNumber[i]);
		//}
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
	}
}
