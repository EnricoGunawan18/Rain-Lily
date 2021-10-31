using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitCheckPopup : MonoBehaviour
{
    public Button btnQuitGame;        // ゲーム終了ボタン
    public Button btnClosePopup;      // ポップアップを閉じてゲームに戻るボタン

    void Start()
    {

        btnClosePopup.onClick.AddListener(OnClickClosePopUp);
        btnQuitGame.onClick.AddListener(QuitGameManeger.QuitGame);

    }

    /// <summary>
    /// ポップアップを閉じてゲームに戻る
    /// </summary>
    private void OnClickClosePopUp()
    {
        // ゲーム内時間の流れを再開する
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}