using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator = null;
    [SerializeField] private Transform spwonPoint = null;
    [SerializeField] private CinemachineFreeLook freeLook = null;
    [SerializeField] private string levelToLoad = "";
    private static string previousLevel = "";

    private void OnEnable()
    {
        if(spwonPoint != null && freeLook != null)
        {
            OutSourcingGlobals.ShowHowToControl();
            OutSourcingGlobals.PlayBGM("BGM/U_META_TRAVEL3");
        }
    }

    public void FadeToLevel()
    {
        previousLevel = SceneManager.GetActiveScene().name;
        if(animator != null)
        {
            animator.SetTrigger("FadeOut");
        }
        else
        {
            OnFadeComplete();
        }
    }

    public void FadeToLevel(string level)
    {
        previousLevel = SceneManager.GetActiveScene().name;
        levelToLoad = level;
        if(animator != null)
        {
            animator.SetTrigger("FadeOut");
        }
        else
        {
            OnFadeComplete();
        }
    }

    public void FadeToPreviousLevel()
    {
        Debug.Log("FadeToPreviousLevel" + previousLevel.ToString());
        FadeToLevel(previousLevel);
    }

    public void OnFadeComplete()
    {
        if(levelToLoad == "SelectPlace")
        {
            SceneManager.LoadSceneAsync(levelToLoad);
        }
        else
        {
            BusanMetaPUN.GET.EnterField(levelToLoad);
        }
        

        
    }
}
