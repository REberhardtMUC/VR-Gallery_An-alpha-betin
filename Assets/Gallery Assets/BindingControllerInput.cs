using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BindingControllerInput : MonoBehaviour
{
    public GameObject menuPanel;
    public InputActionReference showMenuAction;

    private void Awake()
    {
        showMenuAction.action.Enable();
        showMenuAction.action.performed += ToggleMenu;
    }
    private void OnDestroy()
    {
        showMenuAction.action.Disable();
        showMenuAction.action.performed -= ToggleMenu;
    }
    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }
}
