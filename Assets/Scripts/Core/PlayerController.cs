using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerController : MonoBehaviour, IPunObservable
{

    public enum AnimationIndex
    {
        Stand,
        Walk,
        Run,
        Greeting,
        Jump,
        SitDown,
        Fishing_Throw,
        Fishing_Wait,
        Fishing_Catch,
        Surfing
	}



    public Animator animator;
    [SerializeField] GameObject fishing_rod;
    [SerializeField] GameObject board;
    [SerializeField] GameObject paddle;

    public bool isCanControl = true;

    public Transform LookAtPoint = null;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float gravityValue = -9.81f;

    private PlayerInput playerInput;
    private Transform cameraTransform;

    float fising_wait_timer;
    bool enabled_catch;

    bool above_water = false;

    Vector3 prev_velocity;

    PhotonView photonView;

    AnimationIndex animation_index;
    
    

    public static PlayerController MY_AVATAR_CONTROLLER;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        photonView = GetComponent<PhotonView>();
        cameraTransform = Camera.main.transform;
        animation_index = AnimationIndex.Stand;

        SetMyAvatar();
    }

    void Update()
    {
        if(this != MY_AVATAR_CONTROLLER)
        {
            return;
        }


        if(animation_index == AnimationIndex.Fishing_Throw)
        {
            fising_wait_timer += Time.deltaTime;
            if(fising_wait_timer > 5.0f)
            {
                EnableCatch();
		    }
		}
        
        

        if(isCanControl)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
            Vector3 move = new Vector3(input.x, 0, input.y);
            

            move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
            move.y = 0;

            controller.Move(move * Time.deltaTime * playerSpeed);

            float prev_speed_sqr = prev_velocity.sqrMagnitude;
            float speed_sqr = move.sqrMagnitude;
            
            if (speed_sqr > 0.25)
            {
                gameObject.transform.forward = move;
                
                if(above_water == false)
                {
                    PlayAnimation(AnimationIndex.Run);
                }
                else
                {
                    PlayAnimation(AnimationIndex.Surfing);
                }
                
            }
            else if(speed_sqr > 0.0)
            {
                gameObject.transform.forward = move;
                
                
                if(above_water == false)
                {
                    PlayAnimation(AnimationIndex.Walk);
                }
                else
                {
                    PlayAnimation(AnimationIndex.Surfing);
                }
            }

            if(prev_speed_sqr != 0.0f)
            {
                if(speed_sqr == 0.0f)
                {
                    
                    if(above_water == false)
                    {
                        PlayAnimation(AnimationIndex.Stand);
                    }
                    else
                    {
                        PlayAnimation(AnimationIndex.Surfing);
                    }
				}
			}
            
            prev_velocity = move;

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if (input != Vector2.zero)
            {
                float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cameraTransform.position.z;
                Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
            }
        }
        //else if(!isCanControl)
        //{
        //    PlayAnimation(AnimationIndex.Stand);
        //}
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(animation_index);
        }
        else
        {
            AnimationIndex received_index = (AnimationIndex)stream.ReceiveNext();
            if(animation_index != received_index)
            {
                PlayAnimation(received_index);    
                
			}
            
        }
    }

    void SetMyAvatar()
    {
        if (!photonView.AmOwner /*|| !controllable*/)
        {
            return;
        }

        // we don't want the master client to apply input to remote ships while the remote player is inactive
        if (this.photonView.CreatorActorNr != PhotonNetwork.LocalPlayer.ActorNumber)
        {
            return;
        }

        MY_AVATAR_CONTROLLER = this;
    }

    string AnimationIndexToName(AnimationIndex index)
    {
        return index.ToString();
    }

    public void SetPose(AnimationIndex animation_index)
    {
        if(isCanControl == false)
        {
            return;
		}
        PlayAnimation(animation_index);    
    }

    void EnableCatch()
    {
        if(enabled_catch == false)
        {
            enabled_catch = true;
            FishingCatchSign.Show(CatchFish);
		}
	}

    public void CatchFish()
    {
        PlayAnimation(AnimationIndex.Fishing_Catch);
        Handheld.Vibrate();
    }

    public void EndFishing()
    {
        fishing_rod.SetActive(false);
        isCanControl = true;
        enabled_catch = false;
	}

    public void EnterPortal()
    {
        if(above_water == false)
        {
            PlayAnimation(AnimationIndex.Stand);
        }
        else
        {
            PlayAnimation(AnimationIndex.Surfing);
        }
        isCanControl = false;
    }

    void PlayAnimation(AnimationIndex animation_index)
    {
        
        switch(animation_index)
        {
            case AnimationIndex.Fishing_Throw: 
                fishing_rod.SetActive(true);
                isCanControl = false;
                fising_wait_timer = 0.0f;
                break;
            case AnimationIndex.Surfing:
                fishing_rod.SetActive(false);
                break;
            case AnimationIndex.Stand:
            case AnimationIndex.Walk:
            case AnimationIndex.Run: 
                fishing_rod.SetActive(false); 
                break;
		}
        Debug.Log("animation_index " + animation_index.ToString());
        this.animation_index = animation_index;
        animator.Play(AnimationIndexToName(animation_index));
	}


    public void EnterWater()
    {   
        Debug.Log("EnterWater");
        above_water = true;
        PlayAnimation(AnimationIndex.Surfing);
        paddle.SetActive(true);
        board.SetActive(true);
    }
    public void ExitWater()
    {
        Debug.Log("ExitWater");
        above_water = false;
        paddle.SetActive(false);
        board.SetActive(false);
    }
}