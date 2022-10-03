using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaR_cuisine : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dishs;
    [SerializeField]
    private GameObject[] dishsList;
    [SerializeField]
    private Image finishedImage;
    [SerializeField]
    private Button comp_bn;
    [SerializeField]
    private Transform canvasTran;

    private ScoreHome home = new ScoreHome();
    private PazzleCookMAnager game = new PazzleCookMAnager();
    private Finished_dish finDish;
    private GameObject instantObject;
    private bool frag;

    void Start()
    {
        comp_bn.onClick.AddListener(Send_cuisine);

        int Rnum = Random.Range(0, dishs.Length);
        instantObject = Instantiate(dishs[Rnum], canvasTran.position, Quaternion.identity);
        finDish = instantObject.GetComponent<Finished_dish>();
        finDish.Send_num(finishedImage);
        foreach (var item in dishsList)
        {
            if (item.gameObject.tag == instantObject.tag)
            {
                item.gameObject.SetActive(true);
			}
			else
            {
                item.gameObject.SetActive(false);
            }
        }
        frag = false;
    }

	private void Update()
	{
		if (game.GetGameStop())
		{
            foreach (var item in dishsList)
            {
                item.gameObject.SetActive(false);
            }

            Destroy(instantObject);
        }
	}

	private void Send_cuisine()
    {
        if (!frag)
        {
            home.GetCookScore += finDish.Finished_order();

            foreach (var item in dishsList)
            {
                item.gameObject.SetActive(false);
            }

            Destroy(instantObject);
            frag = true;
        }

        if (frag)
        {
            int Rnum = Random.Range(0, dishs.Length);
            instantObject = Instantiate(dishs[Rnum], canvasTran.position, Quaternion.identity);
            finDish = instantObject.GetComponent<Finished_dish>();
            finDish.Send_num(finishedImage);
			foreach (var item in dishsList)
			{
				if (item.gameObject.tag==instantObject.tag)
				{
                    item.gameObject.SetActive(true);
                    break;
				}
			}
            frag = false;
        }
    }
}
