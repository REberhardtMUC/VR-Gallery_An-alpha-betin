using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextPath : MonoBehaviour
{

    public GameObject nextPath;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //nextPath.SetActive(true);
        nextPath.SetActive(false);
        // TO DO Alle anderen Pfade ausblenden
    }
}
