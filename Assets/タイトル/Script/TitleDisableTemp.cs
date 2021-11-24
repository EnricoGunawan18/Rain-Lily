using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDisableTemp : MonoBehaviour
{
    [SerializeField]
    Button Chapter;
    [SerializeField]
    Button CG;
    // Start is called before the first frame update
    void Awake()
    {
        Chapter.interactable = false;
        CG.interactable = false;
    }
}
