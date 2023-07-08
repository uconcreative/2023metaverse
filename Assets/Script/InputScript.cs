using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InputScript : MonoBehaviour
{
    public bool width = false;
    public bool height = false;
    public bool depth = false;
    public GameObject CrainObject;
    InputField theInputField;
    // Start is called before the first frame update
    void Start()
    {
        theInputField = GetComponent<InputField>();
        //theInputField.onEndEdit.AddListener(delegate { MyOnEndEdit(theInputField); });
        var scaleScript = CrainObject.GetComponent<ScaleScript>();
        if (true == width)
        {
            theInputField.text = scaleScript._width.ToString();
        }
        if (true == height)
        {
            theInputField.text = scaleScript._height.ToString();
        }
        if (true == depth)
        {
            theInputField.text = scaleScript._depth.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCraneSize()
    {
        theInputField = GetComponent<InputField>();
        string text = theInputField.text;
        float outputNumber = 0;
        if (true == float.TryParse(text, out outputNumber))
        {
            var scaleScript = CrainObject.GetComponent<ScaleScript>();
            if(null != scaleScript)
            {
                if(true == width)
                {
                    scaleScript.SetWidth(outputNumber);
                }
                if (true == height)
                {
                    scaleScript.SetHeight(outputNumber);
                }
                if (true == depth)
                {
                    scaleScript.SetDepth(outputNumber);
                }
            }
        }

    }

    //void MyOnEndEdit(InputField _inputFieldWeCareAbout)
    //{
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        //here we re activate the field, so the caret will be still visible after pressing enter
    //        _inputFieldWeCareAbout.ActivateInputField();
    //        //do something with the current _inputFieldWeCareAbout.text here, like sending it to the chat server
    //        string text = _inputFieldWeCareAbout.text;
    //        int outputNumber = 0;
    //        if(true == int.TryParse(text, out outputNumber))
    //        {
    //            var scaleScript = CrainObject.GetComponent<ScaleScript>();
    //            if(null != scaleScript)
    //            {
    //                if(true == width)
    //                {
    //                    scaleScript.SetWidth(outputNumber);
    //                }
    //                if (true == height)
    //                {
    //                    scaleScript.SetHeight(outputNumber);
    //                }
    //                if (true == depth)
    //                {
    //                    scaleScript.SetDepth(outputNumber);
    //                }
    //            }
    //        }
    //    }
    //}


}
