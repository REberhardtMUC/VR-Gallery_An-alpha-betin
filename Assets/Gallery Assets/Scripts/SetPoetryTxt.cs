using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VR_gallery;

namespace VR_gallery
{

    public class SetPoetryTxt : MonoBehaviour
    {
        [Header("Set slam poetry snipplet for video")]
        //Text from poetry slam that the video is translating into a story
        public GameObject txtPoetrySnipplet;
        [SerializeField] string txt_currentVideo;
        [SerializeField] GameObject iconHasMoreInfo;

        [Header("Set Text for more Information on video")]

        //Further information about the slam poetry snipplet
        public GameObject txtMoreInfo;
        [SerializeField] string txt_currentUIinfo;
        [SerializeField] bool hasMoreInfo;
        //public bool HasMoreInfo {get { return hasMoreInfo; } }

        [Header("Set canvas for stopping video when leaving")]
        [SerializeField] GameObject btnPlay;
        [SerializeField] GameObject leinwand;
        private Button buttonComponentPlay;

        private void Start()
        {
            buttonComponentPlay = btnPlay.GetComponent<Button>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (hasMoreInfo)
            {
                iconHasMoreInfo.SetActive(true);
            }
            else
            {
                iconHasMoreInfo.SetActive(false);
            }

            txtPoetrySnipplet.GetComponent<TextMeshProUGUI>().text = txt_currentVideo;
            txtMoreInfo.GetComponent<TextMeshProUGUI>().text = txt_currentUIinfo;
        }

        private void OnTriggerExit(Collider other)
        {
            leinwand.GetComponent<PlayVideo>().Stop();
            //buttonComponentPlay.Toggle
        }
    }
}
