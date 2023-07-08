using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custumizing : MonoBehaviour
{
    enum AppearanceDetail{
        HAIR_MODEL,
        BREAD_MODEL,
        TUSK_MODEL,
        HAIR_COLOR,
        SKIN_COLOR,
    }

    [SerializeField] private GameObject[] hairModels;

    [SerializeField] private Transform headAnchor;

    GameObject activeHair;

    int hairIndex=0;

    public void HairModelUp()
    {
        
        if(hairIndex<hairModels.Length-1)
        {
            hairIndex++;
        }
        else
        {
            hairIndex=0;
        }
        
        Debug.Log("HairModelUp");
        ApplyModification(AppearanceDetail.HAIR_MODEL,hairIndex);
    }
    public void HairModelDown(){

    }
    


    void ApplyModification(AppearanceDetail detail, int id)
    {
        Debug.Log(detail.ToString());
        switch(detail)
        {
            case AppearanceDetail.HAIR_MODEL:
            {
                if(activeHair!=null)
                {
                    GameObject.Destroy(activeHair);
                }
                
                activeHair=GameObject.Instantiate(hairModels[id]);
                activeHair.transform.SetParent(headAnchor);
                activeHair.transform.ResetTransform();
                activeHair.gameObject.SetActive(true);
                Debug.Log("ApplyModification");
                break;
            }
                
        }
    }
}
