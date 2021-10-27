using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogOpenScript : MonoBehaviour
{
    [SerializeField]
    public Button LogShow;
    [SerializeField]
    public Button LogClose;
    [SerializeField]
    public GameObject Logs;
    [SerializeField]
    Scrollbar ScrollNormalize;
    [SerializeField]
    ScrollRect scrollrect;

    void Start()
    {
        LogShow.onClick.AddListener(LogOpening);
        LogClose.onClick.AddListener(LogClosing);
    }

    // Update is called once per frame
    void LogOpening()
    {
        Time.timeScale = 0f;
        Logs.SetActive(true);
        //ScrollNormalize.value = 0;
        scrollrect.normalizedPosition = new Vector2(0,0);
    }

    void LogClosing()
    {
        Time.timeScale = 1f;
        Logs.SetActive(false);
    }
}
