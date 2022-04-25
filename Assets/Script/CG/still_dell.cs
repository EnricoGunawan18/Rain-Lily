using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class still_dell : MonoBehaviour
{
    [SerializeField]
    private Button button_s;

    // Start is called before the first frame update
    void Start()
    {
        button_s.onClick.AddListener(() => this_dell());
    }

    private void this_dell()
	{
        Destroy(this.gameObject);
	}
}
