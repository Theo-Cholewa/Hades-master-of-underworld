using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class CameraMovement : MonoBehaviour
{
    public Camera gameCamera;
    public float cameraMovementSpeed;
    [SerializeField] private Slider _slider;
    private void Start()
    {
        gameCamera = GetComponent<Camera>();
        this.LoadFromJson();
        _slider.value = this.cameraMovementSpeed;
    }

    public void MoveCamera(Vector3 inputVector)
    {
        var movementVector = Quaternion.Euler(0,30,0) * inputVector;
        gameCamera.transform.position += movementVector * Time.deltaTime * cameraMovementSpeed;
    }

    
    public void SetCameraSpeed()
    {
        this.cameraMovementSpeed = _slider.value;
        Debug.Log("Vitesse défilement caméra : " + this.cameraMovementSpeed);
        this.SaveToJson();
    }
    
    public void SaveToJson()
    {
        OptionData data = new OptionData();
        data.cameraSpeed = this.cameraMovementSpeed;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/optionDataFile.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/optionDataFile.json");
        OptionData optionData = JsonUtility.FromJson<OptionData>(json);
        if(optionData != null){
            this.cameraMovementSpeed = optionData.cameraSpeed; 
        }
        else
            this.cameraMovementSpeed = 5f;
    }
}
