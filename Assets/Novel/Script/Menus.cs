using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{

	[SerializeField]
	public AudioClip[] BGMFile;

	[SerializeField]
	AudioSource BGM;

	void OnEnable()
	{
		int menu = PlayerPrefs.GetInt("NovelMenu");

		if (menu == 1 || menu == 2 || menu == 3 || menu == 12)
		{
			BGM.clip = BGMFile[0];
			BGM.Play();
		}
		else
		{
			BGM.clip = BGMFile[1];
			BGM.Play();
		}
	}
}
