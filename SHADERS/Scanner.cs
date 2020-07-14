using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SHADERS.Extensions;

[RequireComponent (typeof (SphereCollider ))]
public class Scanner : MonoBehaviour {

    [SerializeField]
    float scanspeed;
    [SerializeField]
    [Range (0,360)]
    float fieldview;

    [SerializeField]
   public LayerMask mask;
  SphereCollider rangeTrigger;

  public float ScanRange
  {
     get
      {
if(rangeTrigger ==null )
    rangeTrigger =GetComponent <SphereCollider >();
return rangeTrigger.radius ;
      }
  }
    public event System .Action OnScanReady;

    void PrepareScan()
    {
        GameManager.Instance.Timer.Add(() =>{

            if (OnScanReady != null)
                OnScanReady();
        }, scanspeed);

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + getviewangle(fieldview / 2) * GetComponent<SphereCollider>().radius);
        Gizmos.DrawLine(transform.position, transform.position + getviewangle(-fieldview / 2) * GetComponent<SphereCollider>().radius);
    }

    Vector3 getviewangle(float angle)
    {

        float radian = (angle + transform .eulerAngles .y) * Mathf.Deg2Rad;
        return new Vector3(Mathf .Sin (radian ), 0 , Mathf .Cos(radian ));
    }
  public List<T> ScanForTargets <T>()
    {
      //  print("scantarget");
        List<T> target = new List<T>();

        Collider[] results = Physics.OverlapSphere(transform .position ,ScanRange );

                for (int i = 0; i < results.Length; i++)
                {
                    var player = results [i].transform .GetComponent <T >();

                    if (player == null)
                        continue;
           

                    if (!transform.IsLineOfSight(results[i].transform.position, fieldview, mask, Vector3.up))
                        continue;
                    target.Add(player );
                }
             
        PrepareScan();
        return target;

    }
    bool IsLineOfSight(Vector3 eyeheight, Vector3 targetposition)
    {
  return transform .IsLineOfSight (targetposition ,fieldview ,mask ,eyeheight );

    }
	void Update () {
       
	}
}
