using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // boutons principaux
    public Action OnButtonFile, OnButtonOption, OnButtonHelp;
    public Button fileButton, optionButton, helpButton
    ;
    // boutons du menu file
    public Button fileButtonMenu, fileButtonQuit;


    public List<Button> buttonList;
    public List<GameObject> menuList = new List<GameObject>();

    private void Start()
    {
        buttonList = new List<Button> { fileButton, optionButton, helpButton, fileButtonMenu, fileButtonQuit};

        fileButton.onClick.AddListener(() =>
        {
            Debug.Log("File Button Clicked");
            OpenMenu(menuList[0]);
            OnButtonFile?.Invoke();

        });
        optionButton.onClick.AddListener(() =>
        {
            Debug.Log("Option Button Clicked");
            OpenMenu(menuList[1]);
            OnButtonOption?.Invoke();
        });
        helpButton.onClick.AddListener(() =>
        {
            Debug.Log("Help Button Clicked");
            OnButtonHelp?.Invoke();
        });

        fileButtonMenu.onClick.AddListener(() =>
        {
            //SceneManager.LoadScene("GeneralMenu");
            SceneLoader.Load(SceneLoader.Scene.GeneralMenu);
            Debug.Log("File Button Menu Clicked");
            OnButtonFile?.Invoke();
        });

        fileButtonQuit.onClick.AddListener(() =>
        {
            Debug.Log("File Button Quit Clicked");
            Application.Quit();
        });
    }

    private void OpenMenu(GameObject menu)
    {
        foreach(GameObject menuX in menuList)
        {
            if(menuX != menu)
            {
                menuX.SetActive(false);
            }
            else
            {
                Debug.Log(menu.name + " Button Clicked");
                if(menu != null)
                {
                    bool active = menu.activeSelf;
                    menu.SetActive(!active);

                }
            }
            
        }
    }
}
