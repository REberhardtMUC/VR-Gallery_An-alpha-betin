using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BindingControllerInput_performance : MonoBehaviour
{
    [Header("Panel zu Hilfemenü")]
    [SerializeField] GameObject currentSlide;
    public InputActionReference showMenueAction;

    [Header("Zurück zu Hauptmenü")]
    public InputActionReference showMainMenuAction;

    private void Awake()
    {

        showMenueAction.action.Enable();
        showMenueAction.action.performed += ToggleHelpMenu;

    
        showMainMenuAction.action.Enable();
        showMainMenuAction.action.performed += BackToMainMenu;

    }

    private void ToggleHelpMenu(InputAction.CallbackContext context)
    {
        currentSlide.SetActive(!currentSlide.activeSelf);
    }

    private void BackToMainMenu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
}
