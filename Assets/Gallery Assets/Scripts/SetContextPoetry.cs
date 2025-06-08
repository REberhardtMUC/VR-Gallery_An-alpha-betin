using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetContextPoetry : MonoBehaviour
{
    public GameObject txtPanel;
    [SerializeField] string txt_currentRoom;

    private void OnTriggerEnter(Collider other)
    {
        txtPanel.GetComponent<TextMeshProUGUI>().text = txt_currentRoom;
    }
}
