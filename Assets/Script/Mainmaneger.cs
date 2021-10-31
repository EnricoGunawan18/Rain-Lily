using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmaneger : MonoBehaviour
{
    [SerializeField]
    private Button btn1;
    [SerializeField]
    private Button btn2 = null;

    [SerializeField]
    private int num = 1;
    [SerializeField]
    private int num2 = 2;

    void Start()
    {
        btn1.onClick.AddListener(() => MoveScene(num));
        btn2.onClick.AddListener(() => MoveScene(num2));
    }

    void MoveScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
