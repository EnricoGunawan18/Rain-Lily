using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryScript : MonoBehaviour
{
    [SerializeField]
    public Button GlossaryShow;
    [SerializeField]
    public Button GlossaryClose;
    [SerializeField]
    public GameObject GlossaryPanel;

    void Start()
    {
        GlossaryShow.onClick.AddListener(GlossaryOpening);
        GlossaryClose.onClick.AddListener(GlossaryClosing);
    }

    // Update is called once per frame
    void GlossaryOpening()
    {
        GlossaryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void GlossaryClosing()
    {
        GlossaryPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
