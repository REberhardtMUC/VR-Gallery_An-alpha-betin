using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NextSlide : MonoBehaviour
{
    public Sprite img_SlideRightController;
    public Sprite img_SlideLeftController;
    public GameObject introPanel;
    public GameObject img_Paper;

    private Image img_BGintroPanel;
    private int introSlide = 0;



    private void Start()
    {
        img_BGintroPanel = introPanel.GetComponent<Image>();
    }

    public void ChangeButtonImage()
    {
        if (introSlide == 0)
        {
            img_BGintroPanel.sprite = img_SlideRightController;
        }
        else if (introSlide == 1)
        {
            img_BGintroPanel.sprite = img_SlideLeftController;
        }
        else
        {   
            introPanel.SetActive(false);
            img_Paper.SetActive(true);
        }
        introSlide++;
    }
}
