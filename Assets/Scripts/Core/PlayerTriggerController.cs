using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerController : MonoBehaviour
{
    public PlayerController controller = null;
    public LevelChanger changer = null;

    void Start()
    {
        GameObject obj = GameObject.Find("ExitButtonCanvas");
        if(obj != null)
        {
            obj.GetComponent<ExitButtonCanvas>().SetButtonListener(ClickExitButton);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "HallPortal")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("HomeTex");
        }
        else if(other.name == "FishingPointPortal")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("FishingPoint_ulsan");
        }
        else if(other.name == "RestaurantPortal")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("RestaurantPopup");
        }
        else if(other.name == "HotelPortal")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("HotelPopup");
        }
        else if(other.name == "FishBookPortal")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("FishBook");
        }
        else if(other.name == "Return Portal")
        {
            if (controller != null)
                controller.EnterPortal();
            if (changer != null)
                changer.FadeToPreviousLevel();
        }
        else if (other.name == "ORyukDo Portal")
        {
            if (controller != null)
                controller.EnterPortal();
            if (changer != null)
                changer.FadeToLevel("ORyukDo");

            OutSourcingGlobals.ENABLE_SHOWING_HOW_TO_CONTROL = true;
        }
        else if (other.name == "KwangAn Portal")
        {
            if (controller != null)
                controller.EnterPortal();
            if (changer != null)
                changer.FadeToLevel("KwangAn");

            OutSourcingGlobals.ENABLE_SHOWING_HOW_TO_CONTROL = true;
        }
        else if (other.name == "IGiDae Portal")
        {
            if (controller != null)
                controller.EnterPortal();
            if (changer != null)
                changer.FadeToLevel("IGiDae");

            OutSourcingGlobals.ENABLE_SHOWING_HOW_TO_CONTROL = true;
        }

        else if(other.name == "Sea")
        {
            if (controller != null)
                controller.EnterWater();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Sea")
        {
            if (controller != null)
                controller.ExitWater();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(ray, out hitInfo, 50.0f);
            if (hit == true)
            {
                Debug.Log("hit");
                OnClickPortal(hitInfo.collider);
            }
        }
    }

    private void OnClickPortal(Collider other)
    {
        if(other.name == "GwangAn_Paddleboard_LOGO")
        {
            if(controller != null)
                controller.EnterPortal();
            if(changer != null)
                changer.FadeToLevel("SurfingPoint");
        }
       
        URLArchive url_archive = other.GetComponent<URLArchive>();
        if(url_archive != null)
        {
            Application.OpenURL(url_archive.url);
		}
    }

    public void ClickExitButton()
    {
        if (controller != null)
            controller.EnterPortal();
        if (changer != null)
            changer.FadeToPreviousLevel();
    }

}
