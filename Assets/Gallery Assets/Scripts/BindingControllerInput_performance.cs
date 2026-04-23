using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BindingControllerInput_performance : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource audio_OneShot;


    [Header("Panel zu Hilfemenü")]
    public InputActionReference showNextSlideAction;
    [SerializeField] public GameObject[] introSlides;
    private GameObject currentSlide;
    public InputActionReference showMenueAction;

    [Header("Zurück zu Hauptmenü")]
    public InputActionReference showMainMenuAction;

    private int nr_slide;

    private void Awake()
    {
        showNextSlideAction.action.Enable();
        showNextSlideAction.action.performed += ShowNextSlide;

        showMenueAction.action.Enable();
        showMenueAction.action.performed += ToggleHelpMenu;
    
        showMainMenuAction.action.Enable();
        showMainMenuAction.action.performed += BackToMainMenu;

    }
    private void Start()
    {
        currentSlide = introSlides[0];
        nr_slide = 1;
    }
    private void ShowNextSlide(InputAction.CallbackContext context)
    {
        // nur wenn das Menü offen ist, soll mit dem linken Trigger die nächste Folie angezeigt werden
        //if (currentSlide.activeSelf)
        //{
        //    if (nr_slide == 1)
        //    {
        //        currentSlide = introSlides[1];
        //        currentSlide.SetActive(true);
        //        introSlides[0].SetActive(false);
        //    }
        //    else if (nr_slide == 2) 
        //    {
        //        //currentSlide = introSlides[2];
        //        introSlides[1].SetActive(false);
        //        audio_OneShot.Play();
        //    }
        //    nr_slide++
        //    }
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
            }

            if (nr_slide == 4)
            {
                introSlides[3].SetActive(false);
                audio_OneShot.Play();
                nr_slide = 0;
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

    private void BackToMainMenu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
    private void OnDestroy()
    {
        showNextSlideAction.action.Disable();
        showNextSlideAction.action.performed -= ShowNextSlide;

        showMenueAction.action.Disable();
        showMenueAction.action.performed -= ToggleHelpMenu;

        showMainMenuAction.action.Disable();
        showMainMenuAction.action.performed -= BackToMainMenu;

    }
}
