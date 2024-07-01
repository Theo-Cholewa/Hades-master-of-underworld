using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraMovement : MonoBehaviour
{
    public Camera gameCamera;
    public float cameraMovementSpeed = 5;

    private void Start()
    {
        gameCamera = GetComponent<Camera>();
    }
    public void MoveCamera(Vector3 inputVector)
    {
        var movementVector = Quaternion.Euler(0,30,0) * inputVector;
        gameCamera.transform.position += movementVector * Time.deltaTime * cameraMovementSpeed;
    }

    [SerializeField] private Slider _slider;
    public void SetCameraSpeed()
    {
        float volume = _slider.value;
        this.cameraMovementSpeed = volume;
        Debug.Log("Volume: " + volume);
    }
}
