using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _camera;
    public float cameraSensitivity = 200.0f;
    public float cameraAcceleration = 5.0f;
    [SerializeField] Light Light;
    private float rotation_x_Axis;
    private float rotation_y_Axis;

    public Transform hand;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotation_y_Axis += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotation_x_Axis -= Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime; 
        rotation_x_Axis = Mathf.Clamp(rotation_x_Axis, -90.0f, 90.0f);


        hand.localRotation = Quaternion.Euler(rotation_x_Axis, rotation_y_Axis, 0);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, rotation_y_Axis, 0), cameraAcceleration * Time.deltaTime);

        _camera.localRotation = Quaternion.Lerp(_camera.localRotation, Quaternion.Euler(rotation_x_Axis, 0, 0), cameraAcceleration * Time.deltaTime);

        PlayLight();
    }
    private void PlayLight()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Light.enabled = false;
        }
    }
}