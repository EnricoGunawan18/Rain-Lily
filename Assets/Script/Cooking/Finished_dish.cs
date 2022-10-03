using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finished_dish : MonoBehaviour
{
	[SerializeField]
	private Sprite finishedImage;			//完成図
	[SerializeField]
	private GameObject[] ingredients;		//食材
	[SerializeField]
	private CountObject outerCount;			//皿の外周
	[SerializeField]
	private CountObjectInner innerCount;	//皿の内周
	[SerializeField]
	private int outerScore = 0;				//外周のスコアの上がり幅
	[SerializeField]
	private int innerScore=10;				//内周のスコアの上がり幅
	[SerializeField]
	private RectTransform storage;			//食材を出す場所

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
			//Storageのｘの範囲でランダムに
			float y = Random.Range(storage.offsetMin.y, storage.offsetMax.y);
			//Storageのｙの範囲でランダムに
			Vector3 pos = new Vector3(x, y, 20);
			//ｚが20～30だと皿や他のに干渉しにくい
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