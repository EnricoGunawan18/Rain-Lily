using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
	[SerializeField]
	private GameObject CanvasMain;
	[SerializeField]
	private GameObject AutoHide;
	[SerializeField]
	private Button HideButton;
	[SerializeField]
	private Button ShowAll;
	[SerializeField]
	private GameObject NextDialogue;

	private AutoScroll autoScroll;

	Animator Hider;
	Animator AutoHider;

	[SerializeField]
	DialogueManager dialogueManager;

	float speed = 0;

	public bool isHidden = false;

	// Start is called before the first frame update
	void Start()
	{
		Hider = CanvasMain.GetComponent<Animator>();
		AutoHider = AutoHide.GetComponent<Animator>();

		autoScroll = GameObject.Find("AutoScroll").GetComponent<AutoScroll>();

		HideButton.onClick.AddListener(Hiding);
		ShowAll.onClick.AddListener(Showing);
	}

	private void Hiding()
	{
		if (isHidden == false)
		{
			speed = dialogueManager.dialogueSpeed;
			dialogueManager.dialogueSpeed = 0;
			Hider.SetBool("Hiding", true);
			isHidden = true;
			NextDialogue.SetActive(false);
		}
		if (autoScroll.normalSpeed != true)
		{
			AutoHider.SetBool("autoIsHidden", true);
		}
	}

	private void Showing()
	{
		if (isHidden == true)
		{
			Hider.SetBool("Hiding", false);
			isHidden = false;
			NextDialogue.SetActive(true);
			dialogueManager.dialogueSpeed = speed;
		}
		if (autoScroll.normalSpeed != true)
		{
			AutoHider.SetBool("autoIsHidden", false);
		}
	}
}
