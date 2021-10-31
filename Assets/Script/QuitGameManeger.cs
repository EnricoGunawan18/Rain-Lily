using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameManeger : MonoBehaviour
{
    [SerializeField]
    private QuitCheckPopup quitCheckPouUpPrefab;
    public Transform canvasTran;

    private QuitCheckPopup quitCheckPouUp;

    void Awake()
    {
        // このスクリプトをアタッチしているゲームオブジェクトがシーン遷移しても破棄されないようにする
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitCheckPouUp == null)
            {
                // 終了確認用のポップアップを生成する。そのポップアップの中で終了確認を行う
                quitCheckPouUp = Instantiate(quitCheckPouUpPrefab, canvasTran, false);

                // ゲーム内時間の流れを停止
                Time.timeScale = 0;
            }
        }
    }

    /// <summary>
    /// ゲームの終了処理
    /// </summary>
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}