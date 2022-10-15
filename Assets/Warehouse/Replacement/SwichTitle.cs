using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichTitle : MonoBehaviour
{
    [SerializeField]
    private GameObject mainManu;
    [SerializeField]
    private Button startButton;

    void Start()
    {
        mainManu.SetActive(false);

        startButton.onClick.AddListener(ActiveMainManu);
    }

    private void ActiveMainManu()
    {
        mainManu.SetActive(true);

        startButton.gameObject.SetActive(false);
    }
}
