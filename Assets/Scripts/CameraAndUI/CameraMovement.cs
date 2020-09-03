using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform player;
    public float minZoom = 5;
    public float maxZoom = 10;
    public float zoomRate;
    private Camera cam;

    void Start()
    {

        cam = GetComponent<Camera>();
        cam.orthographicSize = minZoom;

    }

    void Update()
    {
        
        transform.position = new Vector3(player.position.x, player.position.y, -1f);

        if (Input.GetKey(KeyCode.Minus) && cam.orthographicSize < maxZoom)
        {

            cam.orthographicSize += zoomRate;

        }
        else if (Input.GetKey(KeyCode.Equals) && cam.orthographicSize > minZoom)
        {

            cam.orthographicSize -= zoomRate;

        }

    }
}
