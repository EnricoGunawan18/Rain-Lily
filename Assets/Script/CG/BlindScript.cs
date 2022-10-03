using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindScript : MonoBehaviour
{
    [SerializeField]
    private Button blindButton;
    [SerializeField]
    private GameObject blindStill;
    [SerializeField]
    private Transform CanvasTran;

    // Start is called before the first frame update
    void Start()
    {
        blindButton.onClick.AddListener(() => Blinded());
    }

    // Update is called once per frame
    private void Blinded()
    {
        Instantiate(blindStill, CanvasTran);
    }
}
