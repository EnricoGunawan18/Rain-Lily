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
        // ���̃X�N���v�g���A�^�b�`���Ă���Q�[���I�u�W�F�N�g���V�[���J�ڂ��Ă��j������Ȃ��悤�ɂ���
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitCheckPouUp == null)
            {
                // �I���m�F�p�̃|�b�v�A�b�v�𐶐�����B���̃|�b�v�A�b�v�̒��ŏI���m�F���s��
                quitCheckPouUp = Instantiate(quitCheckPouUpPrefab, canvasTran, false);

                // �Q�[�������Ԃ̗�����~
                Time.timeScale = 0;
            }
        }
    }

    /// <summary>
    /// �Q�[���̏I������
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