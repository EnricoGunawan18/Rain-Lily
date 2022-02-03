using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoScroll : MonoBehaviour
{
	[SerializeField]
	public Button ScrollBar;
	[SerializeField]
	public GameObject ScrollSlide;
	[SerializeField]
	public Button Pausing;
	[SerializeField]
	public Button Auto;
	[SerializeField]
	private TMP_Text autoSign;

	[SerializeField]
	private DialogueManager dialogueManager;

	[SerializeField]
	Animator ScrollAnim;

	public bool dialogueIsSkipped = false;
	public bool normalSpeed = true;
	bool autoOpen = false;
	public bool autoActive = false;
	public bool automated = false;

	// Start is called before the first frame update
	void Start()
	{
		ScrollBar.onClick.AddListener(ScrollShow);
		Pausing.onClick.AddListener(SkipDialogue);
		Auto.onClick.AddListener(AutoDialogue);

	}

	// Update is called once per frame
	private void ScrollShow()
	{
		if (autoOpen == false)
		{
			ScrollOpen();
		}
		else
		{
			ScrollClose();
		}
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
			dialogueManager.dialogueSpeed = 10f;
			automated = true;
			dialogueManager.next = true;
			autoActive = true;
		}
		else
		{
			dialogueManager.dialogueSpeed = 10f;
			automated = false;
			dialogueManager.next = false;
			autoActive = false;
		}
	}

	//button conditions

	public void ScrollOpen()
	{
		autoOpen = true;

		ScrollAnim.SetBool("isOpening", true);
	}


	public void ScrollClose()
	{
		autoOpen = false;

		ScrollAnim.SetBool("isOpening", false);
	}

	public void DialogueSkipped()
	{
		dialogueIsSkipped = true;
		automated = true;
		dialogueManager.next = true;
		dialogueManager.dialogueSpeed = 400f;
	}

	public void DialogueUnskipped()
	{
		dialogueIsSkipped = false;
		automated = false;
		dialogueManager.next = false;
		dialogueManager.dialogueSpeed = 10f;
	}
}
