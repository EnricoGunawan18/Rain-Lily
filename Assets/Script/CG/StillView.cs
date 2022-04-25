using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StillView : MonoBehaviour
{
    [SerializeField]
    private Button[] stillButtons;
    [SerializeField]
    private StillSceneView stillItem;

    void Start()
    {
        for (int i = 0; i < stillButtons.Length; i++)
        {
            if (i == stillButtons.Length - 1)
            {
                stillButtons[i].onClick.AddListener(() => ThisDell());
                Debug.Log("ÅŒã:" + stillButtons[i]);
            }
            else
            {
                var tmp = stillButtons[i];
                var nextBtn = stillButtons[i + 1];

                stillButtons[i].onClick.AddListener(() => NextDell(tmp, nextBtn));
                Debug.Log(i + "–‡–Ú:" + stillButtons[i]);
            }
        }

        if (stillButtons.Length != 1)
        {
            for (int i = 1; i < stillButtons.Length; i++)
            {
                stillButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void NextDell(Button first,Button next)
    {
        if (stillItem.GetSetBlind())
        {
            first.gameObject.SetActive(false);
            next.gameObject.SetActive(true);
        }
        else
        {
            stillItem.ShowUI();
        }
    }

    private void ThisDell()
	{
        if (stillItem.GetSetBlind())
        {
            Destroy(this.gameObject);
        }
        else
        {
            stillItem.ShowUI();
        }
    }
}
