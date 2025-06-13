using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TogglePlayPauseImg : MonoBehaviour
{
    [SerializeField] GameObject Leinwand;
    VideoPlayer vPlayer;
    public Sprite img_PauseButton;
    public Sprite img_PlayButton;
    public Button button;
    private int initial = 0;

    private void Start()
    {
        vPlayer = Leinwand.GetComponent<VideoPlayer>();
    }

    public void ChangeButtonImage()
    {
        if (vPlayer.isPlaying || initial == 0)
        {
            button.image.sprite = img_PauseButton;
            initial++;
        }
        else
        {
            button.image.sprite = img_PlayButton;
        }
    }
}