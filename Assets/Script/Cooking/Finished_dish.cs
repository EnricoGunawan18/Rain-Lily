using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finished_dish : MonoBehaviour
{
	[SerializeField]
	private Sprite finishedImage;			//�����}
	[SerializeField]
	private GameObject[] ingredients;		//�H��
	[SerializeField]
	private CountObject outerCount;			//�M�̊O��
	[SerializeField]
	private CountObjectInner innerCount;	//�M�̓���
	[SerializeField]
	private int outerScore = 0;				//�O���̃X�R�A�̏オ�蕝
	[SerializeField]
	private int innerScore=10;				//�����̃X�R�A�̏オ�蕝
	[SerializeField]
	private RectTransform storage;			//�H�ނ��o���ꏊ

	private int score ;
	private GameObject[] pantry = new GameObject[5];

	public int Finished_order()
	{
		score = 0;

		StartCoroutine(StayCollider());
		score = outerCount.Calculation() * outerScore + innerCount.Calculation() * innerScore;
		Debug.Log(score);
		return score;
	}

	public void Send_num(Image image)
	{
		image.sprite = finishedImage;
	}

	public void OutIngredient()
    {
		int i = 0;
		foreach (var item in ingredients)
		{
			float x = Random.Range(storage.offsetMin.x, storage.offsetMax.x);
			//Storage�̂��͈̔͂Ń����_����
			float y = Random.Range(storage.offsetMin.y, storage.offsetMax.y);
			//Storage�̂��͈̔͂Ń����_����
			Vector3 pos = new Vector3(x, y, 20);
			//����20�`30���ƎM�⑼�̂Ɋ����ɂ���
			pantry[i] = Instantiate(item, pos, Quaternion.identity);
			i++;
		}
    }

    public void DishDestroy()
    {
		foreach (var item in pantry)
		{
			Destroy(item);
		}
    }

	private IEnumerator StayCollider()
	{
		for (int i = 0; i < 60; i++)
		{
			yield return null;
		}
	}
}