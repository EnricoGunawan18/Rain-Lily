using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject MiniGameChoose;

    LoadDialogue loadDialogue;
    Animator FadeAnim;

    public float dialogueSpeed;
    public bool next = false;
    int menu;

    private void Start()
    {
        menu = PlayerPrefs.GetInt("NovelMenu");

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

        int miniGame = PlayerPrefs.GetInt("MiniGame");
        int menu = PlayerPrefs.GetInt("NovelMenu");

        if ((miniGame == 1 || miniGame == 2 || miniGame == 3) && menu == 4)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if ((miniGame == 1 || miniGame == 2 || miniGame == 3) && menu == 5)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if ((miniGame == 1 || miniGame == 2 || miniGame == 3) && menu != 6)
        {
            PlayerPrefs.SetFloat("DialogueSpeedTemp", dialogueSpeed);
            dialogueSpeed = 0;
            MiniGameChoose.SetActive(true);
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
