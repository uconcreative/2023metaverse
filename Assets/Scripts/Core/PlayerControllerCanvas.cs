using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerCanvas : MonoBehaviour
{
    [SerializeField] GameObject pose_button_list;
    [SerializeField] GameObject minimap;

    [SerializeField] Button[] buttons;

    public void DeActiveOtherButtons(int index)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if(i != index)
            {
                buttons[i].interactable = !buttons[i].interactable;
            }
        }
    }

    public void TurnPoseList()
    {
        pose_button_list.SetActive(!pose_button_list.activeSelf);
    }

    public void ClickPoseGreeting()
    {
        PlayerController.MY_AVATAR_CONTROLLER.SetPose(PlayerController.AnimationIndex.Greeting);

        OutSourcingGlobals.PlayClick();
    }
    public void ClickPoseJump()
    {
        PlayerController.MY_AVATAR_CONTROLLER.SetPose(PlayerController.AnimationIndex.Jump);

        OutSourcingGlobals.PlayClick();
    }
    public void ClickPoseSitDown()
    {
        PlayerController.MY_AVATAR_CONTROLLER.SetPose(PlayerController.AnimationIndex.SitDown);

        OutSourcingGlobals.PlayClick();
    }
    public void ClickPoseFishing()
    {
        if(SceneManager.GetActiveScene().name != "FishingPoint_ulsan")//SceneManager.GetActiveScene().name != "FishingPoint" || 
        {
            SimpleMessage.Show("낚시는 낚시터에서만 할 수 있습니다.");
            return;
        }
    
        PlayerController.MY_AVATAR_CONTROLLER.SetPose(PlayerController.AnimationIndex.Fishing_Throw);

        OutSourcingGlobals.PlayClick();
    }

    public void MiniMap()
    {
        minimap.SetActive(!minimap.activeSelf);

        OutSourcingGlobals.PlayClick();
    }

}
