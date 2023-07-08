using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject WidthBox;
    public GameObject HeightBox;
    public GameObject DepthBox;
    public GameObject DropBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton()
    {
        InputScript script = WidthBox.GetComponent<InputScript>();
        script.ChangeCraneSize();

        script = HeightBox.GetComponent<InputScript>();
        script.ChangeCraneSize();

        script = DepthBox.GetComponent<InputScript>();
        script.ChangeCraneSize();
    }
}
