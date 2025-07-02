using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using VR_gallery;

namespace VR_gallery
{

    public class SetPoetryTxt : MonoBehaviour
    {
        //Text from poetry slam that the video is translating into a story
        public GameObject txtPoetrySnipplet;
        [SerializeField] string txt_currentVideo;
        [SerializeField] GameObject iconHasMoreInfo;

        [Space(20)]

        //Further information about the slam poetry snipplet
        public GameObject txtMoreInfo;
        [SerializeField] string txt_currentUIinfo;
        [SerializeField] bool hasMoreInfo;
        //public bool HasMoreInfo {get { return hasMoreInfo; } }


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
    }
}
