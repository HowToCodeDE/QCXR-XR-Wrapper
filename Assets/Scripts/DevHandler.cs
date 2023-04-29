using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevHandler : MonoBehaviour
{
    public Toggle DevToggle;
    public Toggle ADBToggle;
    public Toggle RAMSetterToggle;
    public GameObject RAMSetterField;

    void Start()
    {
        DevToggle.onValueChanged.AddListener(delegate
        {
            DevModsToggleChanged(DevToggle);
        });
        
        RAMSetterToggle.onValueChanged.AddListener(delegate
        {
            RAMSetterToggleChanged(RAMSetterToggle);
        });
        
        ADBToggle.onValueChanged.AddListener(delegate
        {
            ADBToggleChanged(ADBToggle);
        });
    }
    
    void DevModsToggleChanged(Toggle change)
    {
        if (DevToggle.isOn)
        {
            JNIStorage.apiClass.SetStatic<bool>("developerMods", true);
            JNIStorage.UpdateInstances();
        }
        else
        {
            JNIStorage.apiClass.SetStatic<bool>("developerMods", false);
            JNIStorage.UpdateInstances();
        }
    }    
    
    void RAMSetterToggleChanged(Toggle change)
    {
        if (RAMSetterToggle.isOn)
        {
            JNIStorage.apiClass.SetStatic<bool>("customRAMValue", true);
            RAMSetterField.SetActive(true);
        }
        else
        {
            JNIStorage.apiClass.SetStatic<bool>("customRAMValue", false);
            RAMSetterField.SetActive(false);
        }
    }    
    
    void ADBToggleChanged(Toggle change)
    {
        if (ADBToggle.isOn)
        {
            JNIStorage.apiClass.SetStatic<bool>("advancedDebugger", true);
        }
        else
        {
            JNIStorage.apiClass.SetStatic<bool>("advancedDebugger", false);
        }
    }

}
