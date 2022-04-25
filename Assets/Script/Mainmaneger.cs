using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmaneger : MonoBehaviour
{
    [SerializeField]
    private Button interruption;
    [SerializeField]
    private Button restart;

    [SerializeField]
    private int num = 1;
    [SerializeField]
    private bool Through=true;

    void Start()
    {
        interruption.onClick.AddListener(() => MoveScene(num));
        if(Through)
        {
            restart.onClick.AddListener(() => RestartGame());
        }
    }

    void MoveScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    private void RestartGame() {
        Time.timeScale = 1.0f;
        Destroy(this.gameObject);
    }
}
