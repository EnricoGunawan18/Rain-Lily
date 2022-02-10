using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverFlipAllScript : MonoBehaviour
{
	[SerializeField]
	public Button[] Number;
	[SerializeField]
	public Image[] outline;

	public float timeToCover;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < 10; i++)
		{
			Number[i].transform.Rotate(new Vector3(0, 180, 0));
		}
		timeToCover = Time.time;

	}

	// Update is called once per frame
	void Update()
	{
		float coverTime = Time.time - timeToCover;

		if (coverTime >= 2 && coverTime <= 3)
		{
			for (int i = 0; i < 10; i++){
				outline[i].color = new Color(0, 0, 0, 0);
				Number[i].transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
			}
		}
		else
		{
			for (int i = 0; i < 10; i++)
			{
				outline[i].color = new Color(255, 255, 255, 255);
			}
		}
	}

}

