using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaR_cuisine : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dishs;     //—¿—‚ÌM
    [SerializeField]
    private Image finishedImage;    //Š®¬}‚ğo‚·êŠ
    [SerializeField]
    private Button comp_bn;         //Š®¬ƒ{ƒ^ƒ“
    [SerializeField]
    private Transform dishTran;     //M‚ğo‚·êŠ

    private ScoreHome home = new ScoreHome();
    private GameManage game = new GameManage();
    private Finished_dish finDish;
    private GameObject instantObject;
    private bool frag;

    public void CuisineStart()
    {
        comp_bn.onClick.AddListener(SendCuisine);

        InstantiateDishs();
    }

	public void CuisineUpdate()
	{
		if (game.GetGameStop()&&!frag)
		{
            DesCal();
        }
	}

	private void SendCuisine()
    {
        if (!frag)
        {
            DesCal();
        }

        if (frag)
        {
            InstantiateDishs();
        }
    }

    private void InstantiateDishs()
    {
        int Rnum = Random.Range(0, dishs.Length);
        instantObject = Instantiate(dishs[Rnum], dishTran.position, Quaternion.identity);
        finDish = instantObject.GetComponent<Finished_dish>();
        finDish.Send_num(finishedImage);
        finDish.OutIngredient();
        frag = false;
    }

    public void DesCal()
    {
        home.GetCookScore += finDish.Finished_order();

        finDish.DishDestroy();
        Destroy(instantObject);

        frag = true;
    }
}
