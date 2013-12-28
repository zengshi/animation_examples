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

    public Transform weaponAttachPoint = null;
    public Transform weapon = null;

    Animator animator;

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

    void Awake () {
        animator = GetComponentInChildren<Animator>();
        weapon.parent = weaponAttachPoint;
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
                    animator.SetInteger("attackID", 0);
                    animator.SetInteger("magicID", 0);
                }
            }

            // DEBUG { 
            if ( Input.GetKeyDown(KeyCode.Space) ) {
                animator.SetBool("dead", true);
            }
            if ( Input.GetKeyDown(KeyCode.R) ) {
                animator.SetBool("running", true);
            }
            if ( Input.GetKeyDown(KeyCode.W) ) {
                animator.SetBool("running", false);
            }
            if ( Input.GetKeyDown(KeyCode.Return) ) {
                int val = animator.GetInteger("attackID");
                animator.SetInteger("attackID", val+1);
            }
            if ( Input.GetKeyDown(KeyCode.M) ) {
                int val = animator.GetInteger("magicID");
                animator.SetInteger("magicID", val+1);
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

