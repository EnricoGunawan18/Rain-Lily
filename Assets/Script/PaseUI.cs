using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaseUI : MonoBehaviour
{
    [SerializeField]
    private Button Pause;               //ポーズ画面を呼び出すボタン
    [SerializeField]
    private GameObject pauseObject;     //プレハブ化したポーズ画面
    [SerializeField]
    private GameObject canvas;          //InstantiateするCanvas

    private GameObject _pause;
    private Transform canvasTran;

    void Awake()
    {
        Pause.onClick.AddListener(PauseSW);
    }

    void PauseSW()
    {
        if (_pause == null)
        {
            _pause= Instantiate(pauseObject, canvasTran, false);
            _pause.transform.SetParent(canvas.transform, false);

            Time.timeScale = 0;
        }
    }
}
