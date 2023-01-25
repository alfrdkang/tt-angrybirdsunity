using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject launcher;
    public float rotationMultiplier;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.RotateAround(launcher.transform.position, Vector3.up, Input.GetAxis("Mouse X") * rotationMultiplier);
        transform.RotateAround(launcher.transform.position, transform.right, Input.GetAxis("Mouse Y") * rotationMultiplier);

        launcher.transform.Rotate(0, Input.GetAxis("Mouse X") * rotationMultiplier, 0);

        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
