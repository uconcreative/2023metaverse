using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    float mRotateX = 0;//90;
    float mRotateY = 0;//270;
    float mRotateZ = -0;
    float mZoom = 1.0f;
    bool bMove = false;


    Vector3 TouchDownVector = new Vector3();
    //  public Camera mCamera = null;
    // Use this for initialization
    void Start()
    {

        mZoom = 40.0f;
        Camera.main.fieldOfView = mZoom;
        //      mRotateX = transform.rotation.x;
        //      mRotateY = transform.rotation.y;
        //      mRotateZ = transform.rotation.z;
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            bMove = true;
            TouchDownVector = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(1))
        {
            bMove = false;

        }

        if (bMove)
        {
            Vector3 MovedVector = TouchDownVector - Input.mousePosition;
            MovedVector *= 0.01f;
            transform.rotation = Quaternion.Euler(mRotateY, mRotateX, mRotateZ);
            mRotateX += MovedVector.x;
            //mRotateY += MovedVector.y;
            //mRotateZ += MovedVector.z;

        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            //          Vector3 vec = transform.position;
            //          if(transform.position.z < 30.0f)
            //              vec.z += 1.0f;
            //          transform.position = vec;
            mZoom += 1.0f;
            if (mZoom > 120.0f)
                mZoom = 120.0f;
            Camera.main.fieldOfView = mZoom;//Mathf.Lerp(camera.fieldOfView,zoom,Time.deltaTime*smooth);

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            //          Vector3 vec = transform.position;
            //          if(transform.position.z > -5.0f)
            //              vec.z -= 1.0f;
            //          transform.position = vec;
            mZoom -= 1.0f;
            if (mZoom < 10.0f)
                mZoom = 10.0f;
            Camera.main.fieldOfView = mZoom;


        }

        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax );
    }
}
