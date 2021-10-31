using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject MiniGameChoose;
    [SerializeField]
    Button[] MinGameButton;

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

        int menu = PlayerPrefs.GetInt("NovelMenu");

        if (menu == 1 || menu == 2 || menu == 3 || menu == 10)
        {
            MiniGameChoose.SetActive(true);
        }


        int miniGame = PlayerPrefs.GetInt("MiniGame");
        if (menu == 1)
        {
            MinGameButton[0].interactable = true;
            MinGameButton[1].interactable = false;
            MinGameButton[2].interactable = false;
        }

        else if (menu == 2)
        {
            MinGameButton[0].interactable = false;
            MinGameButton[1].interactable = true;
            MinGameButton[2].interactable = false;
        }
        else if (menu == 3)
        {
            MinGameButton[0].interactable = false;
            MinGameButton[1].interactable = false;
            MinGameButton[2].interactable = true;
        }
        else
        {
            MinGameButton[0].interactable = true;
            MinGameButton[1].interactable = true;
            MinGameButton[2].interactable = true;
        }

        if ((miniGame == 1) && menu == 4)
        {
            SceneManager.LoadScene("Scene_pazle");
        }
        else if ((miniGame == 2 || miniGame == 3) && menu == 5)
        {
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
