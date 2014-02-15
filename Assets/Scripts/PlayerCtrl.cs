// ======================================================================================
// File         : PlayerCtrl.cs
// Author       : Wu Jie 
// Last Change  : 12/21/2013 | 17:40:53 PM | Saturday,December
// Description  : 
// ======================================================================================

///////////////////////////////////////////////////////////////////////////////
// usings
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

///////////////////////////////////////////////////////////////////////////////
// \class CameraCtrl
// 
// \brief 
// 
///////////////////////////////////////////////////////////////////////////////

public class PlayerCtrl : MonoBehaviour {

    public enum ClassType {
        Worrior,
        Magic,
    }

    public Transform weaponAttachPoint = null;
    public Transform weapon = null;

    public AnimationClip magic;
    public AnimationClip attack;
    public ClassType classType;


    Animator animator;

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

    void Awake () {
        animator = GetComponentInChildren<Animator>();
        weapon.parent = weaponAttachPoint;

        //
        if ( classType == ClassType.Magic ) {
            AnimatorOverrideController overrideController = new AnimatorOverrideController();
            overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
            overrideController["magic"] = magic;
            animator.runtimeAnimatorController = overrideController;
        }
        else if ( classType == ClassType.Worrior ) {
            AnimatorOverrideController overrideController = new AnimatorOverrideController();
            overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
            overrideController["magic"] = attack;
            animator.runtimeAnimatorController = overrideController;
        }
    }

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

	void Start () {
	}
	
    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

	void Update () {
        HandleInput();

        if ( animator ) {
            if ( animator.IsInTransition(0) ) {
                AnimatorTransitionInfo currentTransition = animator.GetAnimatorTransitionInfo(0);        
                float currentExitTime = currentTransition.normalizedTime;
                if ( currentTransition.IsUserName("FinishAttack") ) {
                    animator.SetInteger("skillID", -1);
                    animator.SetBool("castSkill", false);
                }
            }

            // DEBUG { 
            if ( Input.GetKeyDown(KeyCode.Space) ) {
                animator.SetBool("dead", true);
            }

            //
            if ( Input.GetKeyDown(KeyCode.R) ) {
                animator.SetBool("running", true);
            }

            //
            if ( Input.GetKeyDown(KeyCode.W) ) {
                animator.SetBool("running", false);
            }

            //
            if ( Input.GetKeyDown(KeyCode.Return) ) {
                AnimatorStateInfo stateInfo;
                if ( animator.IsInTransition(0) ) {
                    stateInfo = animator.GetNextAnimatorStateInfo(0);        
                }
                else {
                    stateInfo = animator.GetCurrentAnimatorStateInfo(0);        
                }

                if ( stateInfo.IsName("combo1") ) {
                    animator.SetInteger("skillID", 2);
                }
                else if ( stateInfo.IsName("combo2") ) {
                    animator.SetInteger("skillID", 3);
                }
                else {
                    animator.SetInteger("skillID", 1);
                }
                animator.SetBool("castSkill", true);
            }

            if ( Input.GetKeyDown(KeyCode.M) ) {
                animator.SetInteger("skillID", 5);
                animator.SetBool("castSkill", true);
            }
            // } DEBUG end 
        }
	}

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

    void HandleInput () {
    }
}

