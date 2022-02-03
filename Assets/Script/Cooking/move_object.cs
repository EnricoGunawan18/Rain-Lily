using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_object : MonoBehaviour
{
    private new Camera camera;
    private GameObject Instant;
    private Vector3 objectPointInScreen;

    private void Start()
    {
        camera = Camera.main;
		if (this.transform.root.gameObject)
        {
            Instant = this.transform.root.gameObject;
        }
    }

    void OnMouseDown()
	{
        objectPointInScreen
            = camera.WorldToScreenPoint(this.transform.position);
    }

    void OnMouseDrag()
    {
        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = camera.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.z = this.transform.position.z;
        this.transform.position = mousePointInWorld;
        Instant.transform.position = mousePointInWorld;
    }
}
