using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField]
    public Button OptionsShow;

    void Start()
    {
        OptionsShow.onClick.AddListener(OptionsOpening);
    }

    // Update is called once per frame
    void OptionsOpening()
    {
        PlayerPrefs.SetInt("OptionsReturn", 1);
		SceneManager.LoadScene("Options");
    }
}
