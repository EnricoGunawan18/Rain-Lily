using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    [SerializeField]
    Button returnClick;

    int returnTo;
    // Start is called before the first frame update
    void Start()
    {
        returnTo = PlayerPrefs.GetInt("OptionsReturn");
        returnClick.onClick.AddListener(Click);
    }

    void Click()
    {
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
