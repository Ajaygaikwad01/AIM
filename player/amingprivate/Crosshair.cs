using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField]
    float speed;
  

    public Transform Reticle;
    Transform crosstop;
    Transform crossbottom;
    Transform crossleft;
    Transform crossright;

    float reticleStartPoint;

	void Start () {
        crosstop = Reticle.Find("cross/top").transform;
        crossbottom = Reticle.Find("cross/bottom").transform;
        crossleft = Reticle.Find("cross/left").transform;
        crossright = Reticle.Find("cross/right").transform;

        reticleStartPoint = crosstop.localPosition.y;
	}

	void Update () {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Reticle.transform.position = Vector3.Lerp(Reticle .transform .position , screenPosition ,speed * Time .deltaTime );

	}
    public void ApplyScale(float scale)
    {
        crosstop.localPosition = new Vector3(0, reticleStartPoint + scale , 0);
        crossbottom.localPosition = new Vector3(0, -reticleStartPoint - scale, 0);
        crossleft.localPosition = new Vector3( -reticleStartPoint - scale,0, 0);
        crossright.localPosition = new Vector3(reticleStartPoint + scale,0, 0);
    }
}
