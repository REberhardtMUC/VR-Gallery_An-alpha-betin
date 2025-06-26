using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VR_gallery
{
    public class BindingControllerInput : MonoBehaviour
    {
        public InputActionReference showNextSlideAction;
        [SerializeField] public GameObject[] introSlides;
        private GameObject currentSlide;

        [Space(20)]

        //public GameObject img_HelpMenue;
        public InputActionReference showMenueAction;

        [Space(20)]

        //public GameObject menuPanel;
        public GameObject img_poetry;
        public InputActionReference showPoetryAction;


        [Space(20)]
        public GameObject img_moreInfo;
        public InputActionReference showInfoAction;

        private int nr_slide;

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
            }
        
            if (nr_slide == 8)
            {
                SceneManager.LoadScene(1);
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
            if (SetPoetryTxt.videoHasMoreInfo)
                img_moreInfo.SetActive(!img_moreInfo.activeSelf);
        }
    }
}
