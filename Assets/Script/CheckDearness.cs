using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDearness : MonoBehaviour
{
    public enum Characters
    {
        klein,
        lied
    }

    [SerializeField,Range(0,100)]
    private int intimacy;
    [SerializeField]
    private Sprite[] numbers;
    [SerializeField]
    private Image digit1;       //�ꌅ��
    [SerializeField]
    private Image digit2;       //�񌅖�
    [SerializeField]
    private Image digit3;       //�O����

    public Characters character = Characters.klein; //�Q�Ƃ���L�����N�^�[��I��

    private void Start() {
        int overIntimacy = 0;

        if (character == 0)
        {
            //�N���C���̐e���x��intimacy�ɑ������ 
            Debug.Log("�N���C��");
        }
        else
        {
            //���[�g�̐e���x��intimacy�ɑ������
            Debug.Log("���[�g");
        }

        if (intimacy<10)            //0�`9���������炱��
        {
            digit1.sprite = numbers[intimacy];
            digit2.gameObject.SetActive(false);
            digit3.gameObject.SetActive(false);
        }
        else if(intimacy<100)       //10�`99���������炱��
        {
            var digit2Num = intimacy / 10;
            var digit1Num = intimacy - (digit2Num * 10);

            digit1.sprite = numbers[digit1Num];
            digit2.sprite = numbers[digit2Num];
            digit3.gameObject.SetActive(false);
        }
        else if(intimacy == 100)    //100���������炱��
        {
            var digit3Num = intimacy / 100;
            var digit2Num = (intimacy - digit3Num * 100) / 10;
            var digit1Num = (intimacy - digit3Num * 100) - (digit2Num * 10);

            digit1.sprite = numbers[digit1Num];
            digit2.sprite = numbers[digit2Num];
            digit3.sprite = numbers[digit3Num];
        }
        else                        //0�`100�ȊO�̐������������炱���ɍs��
        {
            digit1.sprite = numbers[overIntimacy];
            digit2.sprite = numbers[overIntimacy];
            digit3.sprite = numbers[overIntimacy];
        }
    }
}
