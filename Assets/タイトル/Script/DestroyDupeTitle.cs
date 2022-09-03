using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDupeTitle : MonoBehaviour
{
    static GameObject title;

    void Awake() 
    {
        if(title == null)
        {
            title = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
