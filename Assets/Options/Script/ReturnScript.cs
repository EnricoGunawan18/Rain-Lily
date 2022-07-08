using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    [SerializeField]
    Button returnClick;
    [SerializeField]
    Slider SESlider;
    [SerializeField]
    Slider BGMSlider;


    int returnTo;
    // Start is called before the first frame update
    void Start()
    {
        returnTo = PlayerPrefs.GetInt("OptionsReturn");
        returnClick.onClick.AddListener(Click);
    }

    void Click()
    {
        PlayerPrefs.SetFloat("SE", SESlider.value);
        PlayerPrefs.SetFloat("BGM", BGMSlider.value);

        if(returnTo == 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else if(returnTo == 1)
        {
            SceneManager.LoadScene("Novel");
        }
    }
}
