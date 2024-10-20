using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField]
    private float mouseSentivity = 5f;
    void Update()
    {
        Vector2 mousePos = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        RotateCamera(mousePos);
    }

    private void RotateCamera(Vector2 mousePos)
    {
        transform.RotateAround(transform.position, transform.right, mousePos.y * mouseSentivity);
        transform.parent.RotateAround(transform.position, Vector3.up, mousePos.x * mouseSentivity);
    }
}

