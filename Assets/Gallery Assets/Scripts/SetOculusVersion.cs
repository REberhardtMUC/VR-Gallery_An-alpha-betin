using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SetOculusVersion : MonoBehaviour
{
    public static int oculusVersion;
    [SerializeField] private TMP_Text txt_oculusVersion;

    [Header("Left Controller")]
    [SerializeField] GameObject leftHandObject;
    [SerializeField] Transform leftHandControllerModell;

    public void GetDropdownValue()
    {
        int pickedValueIndex = this.GetComponent<TMP_Dropdown>().value;
        oculusVersion = pickedValueIndex + 1;

        switch (pickedValueIndex)
        {
            case 0: 
                txt_oculusVersion.text = "1";
                break;
            case 1: txt_oculusVersion.text = "2"; break;
            case 2: txt_oculusVersion.text = "3"; break;
        }
        //SetController(pickedValueIndex);
    }
    public void SetController(int pickedValueIndex)
    {
        leftHandObject.GetComponent<XRController>().modelPrefab = leftHandControllerModell;
    }

}
