using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
	[SerializeField]
	public GameObject ItemButton;

	int[] ItemNumber;
	Vector2 ButtonPos;

	public void OnEnable()
	{
		ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

		for (int i = 0; i < 9; i++)
		{
			if (ItemNumber[i] != 0)
			{
				ItemButton.SetActive(true);
				Instantiate(ItemButton, ButtonPos, Quaternion.Euler(ButtonPos));
				ButtonPos.y += 200;
			}
		}
	}

	public void OnDisable()
	{
		GameObject.Destroy(ItemButton);
	}
}
