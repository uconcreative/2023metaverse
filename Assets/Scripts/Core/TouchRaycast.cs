using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchRaycast : MonoBehaviour
{
    [SerializeField] private Transform viewPoint = null;
    [SerializeField] private GameObject ViewPicture = null;
    [SerializeField] private GameObject ViewVideo = null;
    [SerializeField] private GameObject ViewFull = null;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private VideoClip[] videos;

    [SerializeField] private VideoPlayer player;
    [SerializeField] private List<string> QuizText = new List<string>();

    private GameObject picture = null;
    private GameObject video = null;

    int layermask = 1;

    private void Awake()
    {
        layermask = LayerMask.GetMask("Building");
    }

    // Update is called once per frame
    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);

                    Ray ray = Camera.main.ScreenPointToRay(mouse);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100, layermask))
                    {
                        if(picture == null)
                        {
                            switch(hit.collider.tag)
                            {
                                case "Trigger_1":
                                    CreatePicture(0);
                                    break;
                                case "Trigger_2":
                                    CreatePicture(1);
                                    break;
                                case "Trigger_3":
                                    CreatePicture(2);
                                    break;
                                case "Trigger_4":
                                    CreatePicture(3);
                                    break;
                                case "Trigger_5":
                                    CreatePicture(4);
                                    break;
                                case "Trigger_6":
                                    CreatePicture(5);
                                    break;
                                case "Trigger_7":
                                    CreatePicture(6);
                                    break;
                                case "Trigger_8":
                                    CreatePicture(7);
                                    break;
                                case "Trigger_9":
                                    CreatePicture(8);
                                    break;
                                case "Trigger_10":
                                    CreatePicture(9);
                                    break;
                                case "Trigger_11":
                                    CreatePicture(10);
                                    break;
                                case "Trigger_12":
                                    CreatePicture(11);
                                    break;
                                case "Trigger_13":
                                    CreatePicture(12);
                                    break;
                                case "Trigger_14":
                                    CreatePicture(13);
                                    break;
                                case "Trigger_15":
                                    CreatePicture(14);
                                    break;
                                case "Trigger_16":
                                    CreatePicture(15);
                                    break;
                                case "Trigger_17":
                                    CreatePicture(16);
                                    break;
                                case "Trigger_18":
                                    CreatePicture(17);
                                    break;
                                case "Trigger_19":
                                    CreatePicture(18);
                                    break;
                                case "Trigger_20":
                                    CreatePicture(19);
                                    break;
                                case "Trigger_21":
                                    CreatePicture(20);
                                    break;
                                case "Trigger_22":
                                    CreatePicture(21);
                                    break;
                                case "Trigger_23":
                                    CreatePicture(22);
                                    break;
                                case "Trigger_24":
                                    CreatePicture(23);
                                    break;
                                case "Trigger_25":
                                    CreatePicture(24);
                                    break;
                                case "Trigger_26":
                                    CreatePicture(25);
                                    break;
                                case "Trigger_27":
                                    CreatePicture(26);
                                    break;
                                case "Trigger_28":
                                    CreatePicture(27);
                                    break;
                                case "Trigger_29":
                                    CreatePicture(28);
                                    break;
                                case "Trigger_30":
                                    CreatePicture(29);
                                    break;
                            }                            
                        }
                        else if(picture != null)
                        {
                            switch (hit.collider.tag)
                            {
                                case "Picture":
                                    ViewFull.transform.GetChild(0).gameObject.SetActive(true);
                                    break;
                            }
                        }

                        if(video == null)
                        {
                            switch(hit.collider.tag)
                            {
                                case "Trigger_31":
                                    CreateVideo(0);
                                    break;
                                case "Trigger_32":
                                    CreateVideo(1);
                                    break;
                            }
                        }
                        else if (video != null)
                        {
                            switch (hit.collider.tag)
                            {
                                case "Video":
                                    ViewFull.transform.GetChild(1).gameObject.SetActive(true);
                                    break;
                            }
                        }
                    }
                }

                if(Input.GetMouseButtonUp(1))
                {
                    if(picture != null)
                    {
                        Destroy(picture);
                    }

                    if (video != null)
                    {
                        player.Stop();
                        RenderTexture.active = player.targetTexture;
                        GL.Clear(true, true, Color.black);
                        RenderTexture.active = null;

                        Destroy(video);
                    }
                }
            }           
        }
    }

    private void ShowQuiz(string text, bool correct_answer, QuizPopup.RewardType reward_type, Sprite sprite, VideoClip video_clip)
    {
		QuizPopup.Show(text, correct_answer, reward_type, sprite, video_clip);
	}

    private void CreatePicture(int index)
    {
        //임시로 데이터를 넣어두었습니다. "울산 태화강은 2019년 7월 국가 정원으로 지정되었다."
        ShowQuiz(QuizText[index], true, QuizPopup.RewardType.Picture, sprites[index], null);

        //picture = Instantiate(ViewPicture, viewPoint.position, viewPoint.rotation);
        //picture.GetComponentInChildren<Image>().sprite = sprites[index];
        //ViewFull.transform.GetChild(0).GetComponent<Image>().sprite = sprites[index];
    }

    private void CreateVideo(int index)
    {
        ShowQuiz(QuizText[index], true, QuizPopup.RewardType.Video, null, videos[index]);
        
        //video = Instantiate(ViewVideo, viewPoint.position, viewPoint.rotation);
        //player.clip = videos[index];
        //player.Play();
        //player.SetDirectAudioVolume(0, 0.25f);
    }
}
