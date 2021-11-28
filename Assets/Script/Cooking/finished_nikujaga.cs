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
	MaterialTag[] m_tag;
	[SerializeField]
	private int[] order;
	[SerializeField]
	private GameObject[] sprites;
	[SerializeField]
	private bool debug_on=true;
	[SerializeField]
	private Text debugText;

	private GameObject[] foodstuff = new GameObject[15];
	private int num = 0;
	private int stuffnum = 0;
	private int stuck = 0;
	[SerializeField]
	private Transform canvasTran;
	private Vector3 _position = new Vector3();

	void Start()
	{
		_position = canvasTran.position;
		_position.z -= 10.0f;
	}

	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if (debug_on)
		{
			debugText.text = "";
			D_Text();
		}

		Debug.Log(num);
        if (foodstuff[0]!=null)
        {
			Debug.Log("NotNull");
			stuck = 0;
			foreach (var item in foodstuff)
			{
				Debug.Log("stuck:" + stuck);
				if (item==null)
				{
					break;
				}
				else if (col.gameObject.tag == foodstuff[stuck].tag)
				{
					Debug.Log("Through1");
					return;
				}
				stuck++;
			}
        }

        foreach (var item in sprites)
		{
			if (col.gameObject.tag == item.tag)
			{
				Instantiate(item, _position, Quaternion.identity);
				foodstuff[num] = item;
				Debug.Log(foodstuff[num] + ":" + num);
				Destroy(col.gameObject);
				break;
			}else
			{

			}
		}

        if (foodstuff[num]==null)
        {
			return;
        }
		
		num++;
    }

	public void Finished_order()
	{
		int temp = order[stuffnum];
		foreach (GameObject _stuff in foodstuff) 
		{
			if(_stuff.tag==m_tag[stuffnum].ToString()
                && temp == order[stuffnum])
            {

            }
			else if (_stuff.tag == m_tag[stuffnum].ToString()
				&& temp != order[stuffnum])
            {

            }
            else if (_stuff.tag != m_tag[stuffnum].ToString()
				&& temp == order[stuffnum])
			{

            }
            else
            {

            }
			temp = order[stuffnum];
			stuffnum++;
		}

		foodstuff = new GameObject[] { };
	}

	public void Send_num(Image image)
    {
		image.sprite = finished_image;
    }

	private void D_Text()
    {
		for (int i = 0; i < foodstuff.Length; i++)
		{
			debugText.text += i + ":" + foodstuff[i] + "\n";
		}
	}
}
