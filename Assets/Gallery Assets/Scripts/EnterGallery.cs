using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGallery : MonoBehaviour
{
    public int actualLevel;
    public void OnTriggerEnter()
    {
        LoadScene(actualLevel);//Level[x] = inde[x+1]
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
