using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BindingControllerInput : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject introPanel;
    private Image img_introPanel;
    public InputActionReference showMenuAction;

    public Sprite img_nextSlide;

    public GameObject infoPanel;
    public Text txt_moreInfo;
    public InputActionReference showInfoAction;

    private int nr_slide = 1;

    private void Awake()
    {
        showMenuAction.action.Enable();
        showMenuAction.action.performed += ToggleMenu;

        showInfoAction.action.Enable();
        showInfoAction.action.performed += ToggleInfo;

        img_introPanel = introPanel.GetComponent<Image>();
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
        if (nr_slide == 1)
        {
            // nächstes Slide
            img_introPanel.sprite = img_nextSlide;
        }
        else if (nr_slide == 2)
        {
            introPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
        nr_slide++;
    }
    private void ToggleInfo(InputAction.CallbackContext context)
    {
            infoPanel.SetActive(!infoPanel.activeSelf);
    }
}
