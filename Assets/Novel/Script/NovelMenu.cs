using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject affectionScreen;

    [SerializeField]
    Button openMenu;
    [SerializeField]
    Button closeMenu;
    [SerializeField]
    Button affection;

    // Start is called before the first frame update
    void Start()
    {
        openMenu.onClick.AddListener(Open);
        closeMenu.onClick.AddListener(Close);
        affection.onClick.AddListener(Affection);
    }

    // Update is called once per frame
    void Open()
    {
        menu.SetActive(true);
    }
    void Close()
    {
        menu.SetActive(false);
    }
    void Affection()
    {
        affectionScreen.SetActive(true);
    }
}
