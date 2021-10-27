using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToMenu : MonoBehaviour
{
    [SerializeField]
    Button AffectionReturn;
    [SerializeField]
    Button ItemsReturn;

    [SerializeField]
    GameObject Menu;
    [SerializeField]
    GameObject AffectionScreen;
    [SerializeField]
    GameObject ItemsScreen;

    // Start is called before the first frame update
    void Start()
    {
        AffectionReturn.onClick.AddListener(Return);
        ItemsReturn.onClick.AddListener(Return);
    }

    // Update is called once per frame
    void Return()
    {
        Menu.SetActive(true);
        AffectionScreen.SetActive(false);
        ItemsScreen.SetActive(false);
    }
}
