using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation Packs:")]
    public List<string> GEO_AnimationPack;
    public List<string> NONE_AnimationPack;
    public List<string> PYRO_AnimationPack;
    public List<string> HYDRO_AnimationPack;
    public List<string> ELECTRO_AnimationPack;
    
    // Private variables
    private List<string> CurrentAnimationPack;
    private PlayerMovement PlayerMovementReference;
    private Animator Animator;
    

    private void Awake()
    {
        // Getting references
        PlayerMovementReference = GetComponent<PlayerMovement>();
        Animator = GetComponent<Animator>();

        // Setting the animation packs
        GEO_AnimationPack = new List<string>{ };
        NONE_AnimationPack = new List<string>{
            "Left_Animation",
            "Right_Animation",
            "Up_Animation",
            "Down_Animation",
            "LeftIdle_Animation",
            "RightIdle_Animation",
            "UpIdle_Animation",
            "DownIdle_Animation",
            "NONE_Animation"
        };
        PYRO_AnimationPack = new List<string>{ };
        HYDRO_AnimationPack = new List<string>{ };
        ELECTRO_AnimationPack = new List<string>{ };

        // Starting the first animation pack
        CurrentAnimationPack = NONE_AnimationPack;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (PlayerMovementReference.GetCurrentDirection())
        {
            case Direction.LEFT:
                Animator.Play(CurrentAnimationPack[0]);
                break;
            case Direction.RIGHT:
                Animator.Play(CurrentAnimationPack[1]);
                break;
            case Direction.UP:
                Animator.Play(CurrentAnimationPack[2]);
                break;
            case Direction.DOWN:
                Animator.Play(CurrentAnimationPack[3]);
                break;
            case Direction.LEFT_IDLE:
                Animator.Play(CurrentAnimationPack[4]);
                break;
            case Direction.RIGHT_IDLE:
                Animator.Play(CurrentAnimationPack[5]);
                break;
            case Direction.UP_IDLE:
                Animator.Play(CurrentAnimationPack[6]);
                break;
            case Direction.DOWN_IDLE:
                Animator.Play(CurrentAnimationPack[7]);
                break;
            case Direction.NONE:
                Animator.Play(CurrentAnimationPack[8]);
                break;
            default:
                Animator.Play(CurrentAnimationPack[8]);
                break;
        }
    }

    private void SelectAnimationPack(Element currentElement)
    {
        switch (currentElement)
        {
            case Element.GEO:
                CurrentAnimationPack = GEO_AnimationPack;
                break;
            case Element.NONE:
                CurrentAnimationPack = NONE_AnimationPack;
                break;
            case Element.PYRO:
                CurrentAnimationPack = PYRO_AnimationPack;
                break;
            case Element.HYDRO:
                CurrentAnimationPack = HYDRO_AnimationPack;
                break;
            case Element.ELECTRO:
                CurrentAnimationPack = ELECTRO_AnimationPack;
                break;
            default:
                break;
        }
    }
}
