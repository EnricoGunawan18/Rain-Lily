using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDupe : MonoBehaviour
{
    static GameObject instance;

    void Awake() 
    {
        if(instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
