using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyStartScript : MonoBehaviour
{
    public static bool GameOpen = false;
    [SerializeField]
    public GameObject Ready;
    [SerializeField]
    public GameObject Starting;

    public float timeReadyStart = 0;

    void Start()
    {
        timeReadyStart = Time.realtimeSinceStartup;
    }

    void Update()
    {
        float starter = Time.realtimeSinceStartup - timeReadyStart;

        if (starter <= 2)
        {
            ReadyUp();
        }

        else if(starter >= 2.2 && starter <= 3.2)
        {
            StartUp();
        }
        else
        {
            GameStart();
        }
        
    }
    public void ReadyUp()
    {
        Ready.SetActive(true);
        Time.timeScale = 0f;
        Starting.SetActive(false);
    }
    public void StartUp()
    {
        Starting.SetActive(true);
        Time.timeScale = 0f;
        Ready.SetActive(false);
    }

    public void GameStart()
    {
        Ready.SetActive(false);
        Starting.SetActive(false);
        Time.timeScale = 1f;
    }

}
