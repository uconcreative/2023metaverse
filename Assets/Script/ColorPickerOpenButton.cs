using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerOpenButton : MonoBehaviour
{
    public GameObject colorPicker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenColorPicker()
    {
        colorPicker.SetActive(!colorPicker.activeSelf);
    }
}
