using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BindingControllerInput : MonoBehaviour
{
    public GameObject menuPanel;
    public InputActionReference showMenuAction;

    public GameObject infoPanel;
    public InputActionReference showInfoAction;

    private void Awake()
    {
        showMenuAction.action.Enable();
        showMenuAction.action.performed += ToggleMenu;

        showInfoAction.action.Enable();
        showInfoAction.action.performed += ToggleInfo;
    }
    private void OnDestroy()
    {
        showMenuAction.action.Disable();
        showMenuAction.action.performed -= ToggleMenu;

        showInfoAction.action.Disable();
        showInfoAction.action.performed -= ToggleInfo;
    }
    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }
    private void ToggleInfo(InputAction.CallbackContext context)
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}
