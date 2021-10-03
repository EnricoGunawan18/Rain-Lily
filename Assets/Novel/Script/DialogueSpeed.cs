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

	DialogueManager dialogueManager;

	// Start is called before the first frame update
	void Start()
	{
		Slow.onClick.AddListener(SlowSpeed);
		Normal.onClick.AddListener(NormalSpeed);
		Fast.onClick.AddListener(FastSpeed);

		dialogueManager = GameObject.Find("LoadDialogue").GetComponent<DialogueManager>();

	}

	// Update is called once per frame
	void SlowSpeed()
	{
		PlayerPrefs.SetFloat("DialogueSpeed", 5f);
		dialogueManager.dialogueSpeed = PlayerPrefs.GetFloat("DialogueSpeed");
	}

	void NormalSpeed()
	{
		PlayerPrefs.SetFloat("DialogueSpeed", 25f);
		dialogueManager.dialogueSpeed = PlayerPrefs.GetFloat("DialogueSpeed");
	}

	void FastSpeed()
	{
		PlayerPrefs.SetFloat("DialogueSpeed", 50f);
		dialogueManager.dialogueSpeed = PlayerPrefs.GetFloat("DialogueSpeed");
	}

}
