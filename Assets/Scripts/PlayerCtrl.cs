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

    Animator animator;

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

    void Awake () {
        animator = GetComponentInChildren<Animator>();
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
            if ( Input.GetKey(KeyCode.Space) ) {
                animator.SetBool("dead", true);
            }
        }
	}

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

    void HandleInput () {
    }
}

