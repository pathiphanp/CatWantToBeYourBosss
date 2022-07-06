using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cam;
    public Transform Player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = Player.transform.position + offset;
        Vector3 cameraPos = Vector3.Lerp(cam.transform.position, desiredPosition, 3 * Time.deltaTime);
        cam.transform.position = cameraPos;
    }
}
