// ======================================================================================
// File         : CameraCtrl.cs
// Author       : Wu Jie 
// Last Change  : 12/21/2013 | 17:22:42 PM | Saturday,December
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

public class CameraCtrl : MonoBehaviour {

    public Transform lookAtTarget;
    public float height = 30.0f;
    public float distance = 30.0f;

    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

	void Start () {
        camera.transform.position 
            = new Vector3 ( camera.transform.position.x,
                            lookAtTarget.position.y + height,
                            camera.transform.position.z );
        camera.transform.LookAt(lookAtTarget); 

        Vector3 camForward = camera.transform.forward;
        camForward.y = 0.0f;
        camForward.Normalize();

        Vector3 hPos = lookAtTarget.position - camForward * distance;
        camera.transform.position = new Vector3 ( hPos.x, 
                                                  camera.transform.position.y,
                                                  hPos.z );
	}
	
    // ------------------------------------------------------------------ 
    // Desc: 
    // ------------------------------------------------------------------ 

	void Update () {
        camera.transform.LookAt(lookAtTarget); 
	}
}
