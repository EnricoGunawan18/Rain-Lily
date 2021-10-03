using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
	LoadDialogue loadDialogue;
	Animator FadeAnim;

	public float dialogueSpeed;
	public bool next = false;

	private void Start()
	{
		dialogueSpeed = PlayerPrefs.GetFloat("DialogueSpeed");
		FadeAnim = GameObject.Find("Fader").GetComponent<Animator>();
	}
	public Coroutine Run(string textToType, Text textLabel)
	{
		string Filtered1 = textToType.Replace("「", "");
		string Filtered2 = Filtered1.Replace("」", "");
		string Filtered3 = Filtered2.Replace("\"", "");
		return StartCoroutine(TypeText(Filtered3, textLabel));
	}

	private IEnumerator TypeText(string textToType, Text textLabel)
	{
		loadDialogue = GetComponent<LoadDialogue>();
		textLabel.text = string.Empty;

		if (loadDialogue.waitForFadeAnim == true)
		{
			float tempSpeed = dialogueSpeed;
			dialogueSpeed = 0;
			yield return new WaitForSeconds(1.5f);
			dialogueSpeed = tempSpeed;
			loadDialogue.waitForFadeAnim = false;
		}

		int miniGame1 = PlayerPrefs.GetInt("MiniGame1");
		int miniGame2 = PlayerPrefs.GetInt("MiniGame2");
		int miniGame3 = PlayerPrefs.GetInt("MiniGame3");

		if (miniGame1 == 1 || miniGame2 == 1 || miniGame3 == 1)
		{
			float tempSpeed = dialogueSpeed;
			dialogueSpeed = 0;
			FadeAnim.SetBool("Fading", true);
			yield return new WaitForSeconds(1.5f);
			FadeAnim.SetBool("Fading", false);
			dialogueSpeed = tempSpeed;
			SceneManager.LoadScene("Stage1");
		}

		float t = 0;
		int charIndex = 0;
		while (charIndex < textToType.Length)
		{
			t += Time.deltaTime * dialogueSpeed;
			charIndex = Mathf.FloorToInt(t);
			charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
			textLabel.text = textToType.Substring(0, charIndex);

			yield return null;
		}
		textLabel.text = textToType;
	}
}
