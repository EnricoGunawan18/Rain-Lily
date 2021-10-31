using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MaterialTag
{
	egg,
	potato,
	broccoli,
	carrot,
	tomato,
	lettuce,
	mushroom,
	bacon,
	meat,
	strawberry,
	onion,
	salmon,
	beef,
	raspberry,
	waffle,
	Sayaendo,
	Red_onion,
	ice,
	blueberry,
	parsley,
	crouton,
	cheese,
	dressing,
	sauce,
	oil,
	pepper,
	suger,
	very_sauce,
	rosemary,
	mint,
	lemon,
}

public class finished_nikujaga : MonoBehaviour
{
	[SerializeField]
	private Sprite finished_image;
	[SerializeField]
	private GameObject dish;
	[SerializeField]
	private Image m_Image;
	[SerializeField]
	MaterialTag[] m_tag;
	[SerializeField]
	private int[] order;
	[SerializeField]
	private Sprite[] sprites ;

	private List<GameObject> foodstuff = new List<GameObject>();
	private int num=0;
	private int stuffnum = 0;

	void Awake()
	{
		m_Image.sprite = finished_image;
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
    {
		foodstuff.Add(col.gameObject);
		num++;
		Debug.Log(num);
		Debug.Log(col);
    }

	public void Finished_order()
	{
		int temp = order[stuffnum];
		foreach (GameObject _stuff in foodstuff) 
		{
			if(_stuff.gameObject.tag==m_tag[stuffnum].ToString()
                && temp == order[stuffnum])
            {

            }else if(_stuff.gameObject.tag == m_tag[stuffnum].ToString()
				&& temp != order[stuffnum])
            {

            }
            else
            {

            }
			temp = order[stuffnum];
			stuffnum++;
		}

		foodstuff.Clear();
	}
}
