using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [System .Serializable ]
    public class CameraRig
    {
        public Vector3 CameraOfset;
        public float Damping;
        public float crouchHeight;

    }

    [SerializeField]
    CameraRig DefaultCmera;

    [SerializeField]
    CameraRig AimCamera;

 

    Transform cameralooktarget;


    private player Localplayer;
	void Awake () {

       GameManager.Instance.OnLocalPlayerJoined += HandelOnPlayerJoined; ;
	}
    void HandelOnPlayerJoined(player Player)

    {
        Localplayer = Player;
        cameralooktarget = Localplayer.transform.Find("amingprivate");

        if (cameralooktarget == null)
            cameralooktarget = Localplayer.transform;

    }
	

	void LateUpdate () {

        if (Localplayer == null)
            return;

        CameraRig CameraRig = DefaultCmera;

        if (Localplayer.PlayerState.weaponstate == PlayerState.EWeponstate.AIMING || Localplayer.PlayerState.weaponstate == PlayerState.EWeponstate.AIMEDFIRING)
            CameraRig = AimCamera;


        float TargetHeight = CameraRig.CameraOfset.y + (Localplayer.PlayerState.movestate == PlayerState.Emovestste.CROUCHING ? CameraRig.crouchHeight : 0);
        Vector3 targetposition = cameralooktarget.position + Localplayer.transform.forward * CameraRig.CameraOfset.z +
            Localplayer.transform.up * TargetHeight +
            Localplayer.transform.right * CameraRig.CameraOfset.x;

        Vector3 collutionDestination = cameralooktarget.position + Localplayer.transform.up * TargetHeight - Localplayer .transform .forward * 0.5f;
       // Debug.DrawLine(targetposition, collutionDestination, Color.blue);
        HandleCameraColution(collutionDestination,ref targetposition );

      

        transform.position = Vector3.Lerp(transform.position, targetposition, CameraRig.Damping  * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameralooktarget.rotation, CameraRig.Damping * Time.deltaTime);
}
    private void HandleCameraColution(Vector3 totarget, ref Vector3 frontargrt)
    {
        RaycastHit hit;
        if (Physics.Linecast(totarget, frontargrt, out hit))
        {
           Vector3 hitpoint = new Vector3(hit.point.x + hit.normal.x * 0.2f, hit.point.y, hit.point.z + hit.normal.z * .2f);
         frontargrt = new Vector3(hitpoint.x, frontargrt.y, hitpoint.z);

        }

    }
}
