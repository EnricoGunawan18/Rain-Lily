using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QLoadSave : MonoBehaviour
{
	[SerializeField]
	Button QuickLoad;
	[SerializeField]
	Button QuickLoadYes;
	[SerializeField]
	Button QuickLoadNo;

	[SerializeField]
	GameObject QuickLoadAsker;

	[SerializeField]
	LoadDialogue loadDialogue;

	GameObject loadDialogueGameObject;

	// Start is called before the first frame update
	void Start()
	{
		loadDialogueGameObject = GameObject.Find("LoadDialogue");
		loadDialogue = loadDialogueGameObject.GetComponent<LoadDialogue>();

		QuickLoad.onClick.AddListener(QuickLoadClick);
		QuickLoadYes.onClick.AddListener(QuickLoadYesClick);
		QuickLoadNo.onClick.AddListener(QuickLoadNoClick);
	}


	void QuickLoadClick()
	{
		Time.timeScale = 0f;
		QuickLoadAsker.SetActive(true);
	}

	void QuickLoadYesClick()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Novel");
	}

	void QuickLoadNoClick()
	{
		Time.timeScale = 1;
		QuickLoadAsker.SetActive(false);
	}
}
