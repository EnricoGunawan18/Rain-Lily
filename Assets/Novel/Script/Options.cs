using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]
    public Button OptionsShow;
    [SerializeField]
    public Button OptionsClose;
    [SerializeField]
    public GameObject OptionsPanel;

    void Start()
    {
        OptionsShow.onClick.AddListener(OptionsOpening);
        OptionsClose.onClick.AddListener(OptionsClosing);
    }

    // Update is called once per frame
    void OptionsOpening()
    {
        OptionsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void OptionsClosing()
    {
        OptionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
