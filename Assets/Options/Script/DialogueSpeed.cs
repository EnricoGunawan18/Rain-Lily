using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSpeed : MonoBehaviour
{
	[SerializeField]
	Button Slow;
	[SerializeField]
	Button Normal;
	[SerializeField]
	Button Fast;
	[SerializeField]
	Sprite[] sprite;

	DialogueManager dialogueManager;

	float speed;

	// Start is called before the first frame update
	void Start()
	{
		Slow.onClick.AddListener(SlowSpeed);
		Normal.onClick.AddListener(NormalSpeed);
		Fast.onClick.AddListener(FastSpeed);

		speed = PlayerPrefs.GetFloat("DialogueSpeed");
		if( speed == 5)
		{
			ChangeColor(1,2,4);
		}
		else if( speed == 25)
		{
			ChangeColor(0,3,4);
		}
		else if( speed == 50)
		{
			ChangeColor(0,2,5);
		}
	}

	// Update is called once per frame
	void SlowSpeed()
	{
		ChangeColor(1,2,4);
		PlayerPrefs.SetFloat("DialogueSpeed", 5f);
	}

	void NormalSpeed()
	{
		ChangeColor(0,3,4);
		PlayerPrefs.SetFloat("DialogueSpeed", 25f);
	}

	void FastSpeed()
	{
		ChangeColor(0,2,5);
		PlayerPrefs.SetFloat("DialogueSpeed", 50f);
	}

	void ChangeColor( int num1, int num2, int num3)
	{
		Slow.image.sprite = sprite[num1];
		Normal.image.sprite = sprite[num2];
		Fast.image.sprite = sprite[num3];
	}
}
