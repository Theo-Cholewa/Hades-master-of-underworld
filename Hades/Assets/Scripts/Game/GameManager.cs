using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public InputManager inputManager;
    public UIController uiController;
    private void Start()
    {
        uiController.OnButtonFile += FileHandler;
        uiController.OnButtonOption += OptionHandler;
        uiController.OnButtonHelp += HelpHandler;
        
    }

    private void Update()
    {
        cameraMovement.MoveCamera(new Vector3(inputManager.CameraMovementVector.x,0, inputManager.CameraMovementVector.y));
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

    private void FileHandler()
    {
        ClearInputActions();
    }

    private void OptionHandler()
    {
        ClearInputActions();
    }

    private void HelpHandler()
    {
        ClearInputActions();
    }

    private void ClearInputActions()
    {
        inputManager.OnMouseClick = null;
        inputManager.OnMouseHold = null;
        inputManager.OnMouseUp = null;
    }
}
