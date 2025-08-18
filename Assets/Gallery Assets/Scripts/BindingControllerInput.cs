using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VR_gallery
{
    public class BindingControllerInput : MonoBehaviour
    {        

        [Header("Panel zu Hilfemenü")]
        public InputActionReference showNextSlideAction;
        [SerializeField] public GameObject[] introSlides;
        private GameObject currentSlide;
        public InputActionReference showMenueAction;


        [Header("Panel zu Poetry Snipplets")]
        public GameObject img_poetry;
        public InputActionReference showPoetryAction;


        [Header("Panel zu weiteren Informationen")]
        public GameObject img_moreInfo;
        public GameObject icon_Y_moreInfo;
        public InputActionReference showInfoAction;

        [Header("Zurück zu Hauptmenü")]
        public InputActionReference showMainMenuAction;

        private int nr_slide;
        private string txt_moreInfo;

        private void Awake()
        {
            showNextSlideAction.action.Enable();
            showNextSlideAction.action.performed += ShowNextSlide;

            showMenueAction.action.Enable();
            showMenueAction.action.performed += ToggleHelpMenu;

            showPoetryAction.action.Enable();
            showPoetryAction.action.performed += TogglePoetryPanel;

            showInfoAction.action.Enable();
            showInfoAction.action.performed += ToggleInfo;

            showMainMenuAction.action.Enable();
            showMainMenuAction.action.performed += BackToMainMenu;

        }


        private void Start()
        {
            currentSlide = introSlides[0];
            nr_slide = 1;
        }
        private void OnDestroy()
        {
            showNextSlideAction.action.Disable();
            showNextSlideAction.action.performed -= ShowNextSlide;

            showMenueAction.action.Disable();
            showMenueAction.action.performed -= ToggleHelpMenu;

            showPoetryAction.action.Disable();
            showPoetryAction.action.performed -= TogglePoetryPanel;

            showInfoAction.action.Disable();
            showInfoAction.action.performed -= ToggleInfo;
        }
        private void ShowNextSlide(InputAction.CallbackContext context)
        {
            // nur wenn das Menü offen ist, soll mit dem linken Trigger die nächste Folie angezeigt werden
            if (currentSlide.activeSelf)
            {
                switch (nr_slide)
                {
                    case 1:
                        currentSlide = introSlides[1];
                        break;
                    case 2:
                        currentSlide = introSlides[2];
                        break;
                    case 3:
                        currentSlide = introSlides[3];
                        break;
                    case 4:
                        currentSlide = introSlides[4];
                        break;
                    case 5:
                        currentSlide = introSlides[5];
                        break;
                    case 6:
                        currentSlide = introSlides[6];
                        break;
                    case 7:
                        currentSlide = introSlides[7];
                        break;
                    case 8:
                        currentSlide = introSlides[8];
                        break;
                }

                if (nr_slide == 9)
                {
                    SceneManager.LoadScene(3);// Wechsel in die Galerie
                }
                else
                {
                    foreach (var slide in introSlides)
                    {
                        if (slide == currentSlide)
                        {
                            slide.SetActive(true);
                        }
                        else
                        {
                            slide.SetActive(false);
                        }
                    }
                }
                nr_slide++;

            }
            
        }

        private void ToggleHelpMenu(InputAction.CallbackContext context)
        {
            currentSlide.SetActive(!currentSlide.activeSelf);
        }
        private void TogglePoetryPanel(InputAction.CallbackContext context)
        {
            img_poetry.SetActive(!img_poetry.activeSelf);
        }
        private void ToggleInfo(InputAction.CallbackContext context)
        {
            //txt_moreInfo = img_moreInfo.GetComponentInChildren<TextMeshProUGUI>().ToString();

            //if (SetPoetryTxt.HasMore)
            if (icon_Y_moreInfo.activeSelf)
                img_moreInfo.SetActive(!img_moreInfo.activeSelf);

            //if (String.IsNullOrEmpty(txt_moreInfo))

        }
        private void BackToMainMenu(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene(0);
        }
    }
}
