using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextPath : MonoBehaviour
{

    public GameObject nextPath;
    public List<GameObject> paths;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var path in paths)
        {
            if (path.gameObject == nextPath)
            {
                path.SetActive(true);
            }
            else
            {
                path.SetActive(false);
            }
        }
    }
}
