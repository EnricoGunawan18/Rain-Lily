using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsRaycastSet : MonoBehaviour
{
    void OnEnable()
    {
        this.GetComponent<GraphicRaycaster>().enabled = true;
    }
    void OnDisable()
    {
        this.GetComponent<GraphicRaycaster>().enabled = false;
    }}
