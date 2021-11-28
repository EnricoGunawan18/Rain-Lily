using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class character_select : MonoBehaviour
{
    [SerializeField]
    private Button reit_bm;         //���[�g�̑I���{�^��
    [SerializeField]
    private Button cryin_bm;        //�N���C���̑I���{�^��
    [SerializeField]
    private GameObject Panel_r;     //���[�g�̃X�`��
    [SerializeField]
    private GameObject Panel_c;     //�N���C���̃X�`��
    [SerializeField]
    private GameObject cover;

    void Start()
    {
        reit_bm.onClick.AddListener(() => Change_character(Panel_c, Panel_r));
        cryin_bm.onClick.AddListener(() => Change_character(Panel_r, Panel_c));
        //Change_character(Panel_r, Panel_c);
    }

    private void Change_character(GameObject panel_a,GameObject panel_b)
	{
        Debug.Log("�o��");
        cover.SetActive(true);
        panel_a.GetComponent<RectTransform>()
            .DOMoveX(940f, 5.0f)
            .SetEase(Ease.OutExpo)
            .OnComplete(() => Debug.Log("��������"));      //�������߂�

        panel_b.GetComponent<RectTransform>()
            .DOMoveX(-763f, 5.0f)
            .SetEase(Ease.OutExpo)
            .OnComplete(() => Debug.Log("�o��"));             //�����o��
        cover.SetActive(false);
	}
}
