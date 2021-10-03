using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScroll : MonoBehaviour
{
	[SerializeField]
	public Button MenuBar;
	[SerializeField]
	public GameObject MenuSlide;

	Animator MenuAnim;

	bool menuIsOpen = false;

	// Start is called before the first frame update
	void Start()
	{
		MenuAnim = MenuSlide.GetComponent<Animator>();

		MenuBar.onClick.AddListener(MenuShow);
	}

	// Update is called once per frame
	private void MenuShow()
	{
		if (menuIsOpen == false)
		{
			MenuOpen();
		}
		else if (menuIsOpen == true)
		{
			MenuClose();
		}
	}

	public void MenuOpen()
	{
		menuIsOpen = true;

		MenuAnim.SetBool("isOpening", true);
	}


	public void MenuClose()
	{
		menuIsOpen = false;

		MenuAnim.SetBool("isOpening", false);
	}
}
