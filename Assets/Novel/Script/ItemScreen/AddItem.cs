using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
	[SerializeField]
	public Button[] ItemButton;
	[SerializeField]
	Text[] ItemName;
	[SerializeField]
	Text[] Quantity;
	[SerializeField]
	TextAsset ItemList;


	[SerializeField]
	LoadDialogue loadDialogue;
	[SerializeField]
	CharacterItemChoose characterItemChoose;

	[SerializeField]
	GameObject ItemScreen;

	List<GameObject> ButtonList;

	int[] ItemNumber;

	string[] itemData;
	string[] itemRow;

	void Awake()
	{
		itemData = ItemList.text.Split(new char[] { '$' });
		for (int i = 0; i < 14; i++)
		{
			int number = i;
			ItemButton[i].onClick.AddListener(() => ItemChooseClick(number));
		}
	}

	public void OnEnable()
	{
		ButtonList = new List<GameObject>();
		ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

		for (int i = 0; i < 14; i++)
		{
			itemRow = itemData[i + 1].Split(new char[] { ',' });
			ItemName[i].text = itemRow[2];
			Quantity[i].text = ItemNumber[i].ToString();
		}
	}

	void ItemChooseClick(int number)
	{
		PlayerPrefsX.SetIntArray("ItemNumber",ItemNumber);
		if (characterItemChoose.Character == "Riit")
		{
			if (ItemNumber[number] != 0)
			{
				ItemNumber[number] -= 1;
				PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);

				characterItemChoose.Character = "None";
				if (number == 0 || number == 7 || number == 8
					|| number == 9 || number == 10)
				{
					loadDialogue.RiitEffect(0);
				}
				else if (number == 1 || number == 5 || number == 6
					|| number == 11)
				{
					loadDialogue.RiitEffect(1);
				}
				else
				{
					loadDialogue.RiitEffect(2);
				}
				
				ItemScreen.SetActive(false);
			}
		}

		else if (characterItemChoose.Character == "Klein")
		{
			if (ItemNumber[number] != 0)
			{
				PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);

				characterItemChoose.Character = "None";
				if (number == 3 || number == 7 || number == 11
				|| number == 12 || number == 13)
				{
					loadDialogue.KleinEffect(0);
				}
				else if (number == 0 || number == 4 || number == 6
					|| number == 8 || number == 9 || number == 10)
				{
					loadDialogue.KleinEffect(1);
				}
				else
				{
					loadDialogue.KleinEffect(2);
				}
				ItemScreen.SetActive(false);
			}
		}


		else
		{
		}
	}
}
