using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TogglePlayPauseImg : MonoBehaviour
{
    [SerializeField] GameObject Leinwand;
    //[SerializeField] GameObject mouseOverPLAY;
    VideoPlayer vPlayer;
    public Sprite img_PauseButton;
    public Sprite img_PlayButton;
    public Button button;
    public static int initial = 0;

    private void Start()
    {
        vPlayer = Leinwand.GetComponent<VideoPlayer>();
    } 

    public void OnPointerEnter()
    {
        //mouseOverPLAY.SetActive(true);
    }



    public void OnMouseOver()
    {
        //mouseOverPLAY.SetActive(true);
    }

    public void ChangeButtonImage()
    {
        if (vPlayer.isPlaying || initial == 0)
        {
            button.image.sprite = img_PauseButton;
            initial++;
        }
        else if (vPlayer.isPlaying == false)
        {
            button.image.sprite = img_PlayButton;
        }
    }
    private void Update()
    {
        if (vPlayer.isPlaying == false)
        {
            button.image.sprite = img_PlayButton;
        }
    }
}