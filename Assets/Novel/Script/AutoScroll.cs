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

	private DialogueManager dialogueManager;

	Animator ScrollAnim;

	bool dialogueIsPaused = false;
	public bool normalSpeed = true;
	bool autoOpen = false;
	bool oneHalfSpeed = false;
	bool twiceSpeed = false;
	public bool autoActive = false;
	public bool automated = false;

	// Start is called before the first frame update
	void Start()
	{
		ScrollAnim = ScrollSlide.GetComponent<Animator>();

		dialogueManager = GameObject.Find("LoadDialogue").GetComponent<DialogueManager>();

		ScrollBar.onClick.AddListener(ScrollShow);
		Pausing.onClick.AddListener(PauseDialogue);
		Auto.onClick.AddListener(AutoDialogue);

	}

	// Update is called once per frame
	private void ScrollShow()
	{
		if (normalSpeed == true)
		{
			ScrollOpen();
		}
		else if (autoOpen == true)
		{
			OneHalfingSpeed();
		}
		else if (oneHalfSpeed == true)
		{
			DoublingSpeed();
		}
		else if (twiceSpeed == true)
		{
			ScrollClose();
		}
	}

	private void PauseDialogue()
	{
		if (dialogueIsPaused == false)
		{
			DialoguePaused();
		}
		else if (dialogueIsPaused == true)
		{
			DialogueUnpaused();
		}
	}

	private void AutoDialogue()
	{
		if (autoActive == false)
		{
			automated = true;
			dialogueManager.next = true;
			autoActive = true;
		}
		else
		{
			automated = false;
			dialogueManager.next = false;
			autoActive = false;
		}
	}

	//button conditions

	public void ScrollOpen()
	{
		normalSpeed = false;
		autoOpen = true;

		ScrollAnim.SetBool("isOpening", true);
	}

	public void OneHalfingSpeed()
	{
		autoOpen = false;
		oneHalfSpeed = true;
		automated = true;
		autoActive = false;

		dialogueManager.next = true;

		dialogueManager.dialogueSpeed = 300f;
	}

	public void DoublingSpeed()
	{
		oneHalfSpeed = false;
		twiceSpeed = true;
		autoActive = false;

		dialogueManager.next = true;

		dialogueManager.dialogueSpeed = 400f;
	}


	public void ScrollClose()
	{
		twiceSpeed = false;
		normalSpeed = true;
		automated = false;
		autoActive = false;

		dialogueManager.dialogueSpeed = 25f;

		ScrollAnim.SetBool("isOpening", false);
	}

	public void DialoguePaused()
	{
		dialogueIsPaused = true;
		dialogueManager.dialogueSpeed = 0f;
	}

	public void DialogueUnpaused()
	{
		dialogueIsPaused = false;
		dialogueManager.dialogueSpeed = 25f;
	}
}
