using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoScroll : MonoBehaviour
{
	[SerializeField]
	public Button Pausing;
	[SerializeField]
	public Button Auto;

	[SerializeField]
	private DialogueManager dialogueManager;

	public bool dialogueIsSkipped = false;
	public bool normalSpeed = true;
	bool autoOpen = false;
	public bool autoActive = false;
	public bool automated = false;

	// Start is called before the first frame update
	void Start()
	{
		Pausing.onClick.AddListener(SkipDialogue);
		Auto.onClick.AddListener(AutoDialogue);
	}



	private void SkipDialogue()
	{
		if (dialogueIsSkipped == false)
		{
			DialogueSkipped();
		}
		else if (dialogueIsSkipped == true)
		{
			DialogueUnskipped();
		}
	}

	private void AutoDialogue()
	{
		if (autoActive == false)
		{
			dialogueManager.dialogueSpeed = 25f;
			PlayerPrefs.SetFloat("DialogueSpeed",dialogueManager.dialogueSpeed);
			automated = true;
			dialogueManager.next = true;
			autoActive = true;
		}
		else
		{
			dialogueManager.dialogueSpeed = 25f;
			PlayerPrefs.SetFloat("DialogueSpeed",dialogueManager.dialogueSpeed);
			automated = false;
			dialogueManager.next = false;
			autoActive = false;
		}
	}

	//button conditions

	public void DialogueSkipped()
	{
		dialogueIsSkipped = true;
		automated = true;
		dialogueManager.next = true;
		dialogueManager.dialogueSpeed = 400f;
		PlayerPrefs.SetFloat("DialogueSpeed",dialogueManager.dialogueSpeed);
	}

	public void DialogueUnskipped()
	{
		dialogueIsSkipped = false;
		automated = false;
		dialogueManager.next = false;
		dialogueManager.dialogueSpeed = 25f;
		PlayerPrefs.SetFloat("DialogueSpeed",dialogueManager.dialogueSpeed);
	}
}
