using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finished_dish : MonoBehaviour
{
	[SerializeField]
	private Sprite finished_image;
	[SerializeField]
	private Collider2D outer;
	[SerializeField]
	private Collider2D inner;
	[SerializeField]
	private int outerScore = 0;
	[SerializeField]
	private int innerScore=10;

	private int score;
	private CountObject outerCount;
	private CountObjectInner innerCount;

	void Start()
	{
		outerCount = outer.gameObject.GetComponent<CountObject>();
		innerCount = inner.gameObject.GetComponent<CountObjectInner>();
		score = 0;
	}

	public int Finished_order()
	{
		StartCoroutine(StayCollider());
		score = outerCount.Calculation() * outerScore + innerCount.Calculation() * innerScore;
		Debug.Log(score);
		return score;
	}

	public void Send_num(Image image)
	{
		image.sprite = finished_image;
	}

	private IEnumerator StayCollider()
	{
		for (int i = 0; i < 60; i++)
		{
			yield return null;
		}
	}
}