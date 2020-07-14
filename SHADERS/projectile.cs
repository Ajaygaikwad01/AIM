using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class projectile : MonoBehaviour
{
    

    [SerializeField]
    float speed;
    [SerializeField]
    float timetolive;

    [SerializeField]
    float damage;

   // [SerializeField]
   // Transform BulletHoleEnemy;

    public GameObject impactEffectEnemy;
    public GameObject impacteffectWood;
    public GameObject impacteffectWall;
    public GameObject impacteffectMetal;
    public GameObject impacteffectSoftbody;
    



    public float impactforces = 30f;

    Vector3 destination;

    bool enemy;
    void Start()
    {
        Destroy(gameObject, timetolive);
    }
    void Update()
    {

        if (isDestinationReached())
        {
            Destroy(gameObject );
            return;

        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (destination != Vector3.zero)
            return;

        RaycastHit hit ;
        if (Physics.Raycast(transform.position,transform.forward, out hit, 5f))
        {
            CheckDistructable(hit);

          target target = hit .transform .GetComponent <target >();
            if(target !=null )
            {
          target.TakeDamage(damage);
            }
        }
        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactforces);
        }
    }

    void CheckDistructable(RaycastHit   hitInfo)
    {
        var Destructable = hitInfo.transform.GetComponent<Destructable>();

        destination = hitInfo.point + hitInfo.normal * .0015f;



        if(hitInfo .collider.tag  =="wood")
        {
           // Transform hole = (Transform)Instantiate(BulletHoleEnemy, destination, Quaternion.LookRotation(hitInfo.normal) * Quaternion.Euler(0, 100f, 0));
             // hole.SetParent(hitInfo.transform);
            GameObject impactgo = Instantiate(impacteffectWood, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
               Destroy(impactgo ,2f);
        }
        if (hitInfo.collider.tag == "enemy")
        {

            //Transform hole = (Transform)Instantiate(BulletHoleEnemy, destination, Quaternion.LookRotation(hitInfo.normal) * Quaternion.Euler(0, 100f, 0));
           // hole.SetParent(hitInfo.transform);
            GameObject impactgo1 = Instantiate(impactEffectEnemy, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactgo1, 2f);
        }
        if (hitInfo.collider.tag == "metal")
        {
            GameObject impactgo = Instantiate(impacteffectMetal, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactgo, 2f);
        }

        if (hitInfo.collider.tag == "wall")
        {
            GameObject impactgo1 = Instantiate(impacteffectWall, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactgo1, 2f);
        }
        if (hitInfo.collider.tag == "softbody")
        {
            GameObject impactgo1 = Instantiate(impacteffectSoftbody, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactgo1, 2f);
        }


        if (Destructable == null)
            return;

        Destructable.Takedamage(damage);
    }
    bool isDestinationReached()
    {
        if (destination == Vector3.zero)
            return false;

        Vector3 directionToDestination = destination - transform.position;
        float dot = Vector3.Dot(directionToDestination ,transform .forward );

        if (dot < 0)
            return true;

        return false;
    }
}
