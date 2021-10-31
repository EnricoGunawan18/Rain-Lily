using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitCheckPopup : MonoBehaviour
{
    public Button btnQuitGame;        // �Q�[���I���{�^��
    public Button btnClosePopup;      // �|�b�v�A�b�v����ăQ�[���ɖ߂�{�^��

    void Start()
    {

        btnClosePopup.onClick.AddListener(OnClickClosePopUp);
        btnQuitGame.onClick.AddListener(QuitGameManeger.QuitGame);

    }

    /// <summary>
    /// �|�b�v�A�b�v����ăQ�[���ɖ߂�
    /// </summary>
    private void OnClickClosePopUp()
    {
        // �Q�[�������Ԃ̗�����ĊJ����
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}