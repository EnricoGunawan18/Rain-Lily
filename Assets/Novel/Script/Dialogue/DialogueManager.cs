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
    GameObject GameMenu;
    [SerializeField]
    GameObject Skipper;

    [SerializeField]
    Button[] MinGameButton;
    [SerializeField]
    Button SkipDialogueButton;

    LoadDialogue loadDialogue;
    Animator FadeAnim;

    public float dialogueSpeed;
    public bool next = false;
    public bool isSkipped;
    int menu;

    private void Start()
    {
        menu = PlayerPrefs.GetInt("NovelMenu");

        dialogueSpeed = PlayerPrefs.GetFloat("DialogueSpeed");

        FadeAnim = GameObject.Find("Fader").GetComponent<Animator>();

        SkipDialogueButton.onClick.AddListener(SkipDialogue);
    }

    private void Update()
    {
        if (isSkipped == false)
        {
            Skipper.SetActive(true);
        }
        else
        {
            Skipper.SetActive(false);
        }
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

        isSkipped = false;

        int menu = PlayerPrefs.GetInt("NovelMenu");

        if (menu == 1 || menu == 2 || menu == 3)
        {
            dialogueSpeed = 0;
            MiniGameChoose.SetActive(true);
            loadDialogue.waitForFadeAnim = false;
        }
        else if(menu == 10)
        {
            FadeAnim.SetBool("Fading", false);
            dialogueSpeed = 0;
            GameMenu.SetActive(true);
            loadDialogue.waitForFadeAnim = false;
        }
        else if (loadDialogue.waitForFadeAnim == true)
        {
            float tempSpeed = dialogueSpeed;
            dialogueSpeed = 0;
            yield return new WaitForSeconds(1.5f);
            dialogueSpeed = tempSpeed;
            loadDialogue.waitForFadeAnim = false;
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
            //PlayerPrefs.SetInt("NovelMenu", 0);
            //SceneManager.LoadScene("Novel");
            SceneManager.LoadScene("Scene_pazle");
        }
        
        if ((miniGame == 2 || miniGame == 3) && menu == 5)
        {
            //PlayerPrefs.SetInt("NovelMenu", 0);
            //SceneManager.LoadScene("Novel");
            SceneManager.LoadScene("Stage1");
        }

        float t = 0;
        int charIndex = 0;
        while (charIndex < textToType.Length && isSkipped == false)
        {
            t += Time.deltaTime * dialogueSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        
        isSkipped = true;
        textLabel.text = textToType;
    }

    void SkipDialogue()
    {
        isSkipped = true;
    }
}
