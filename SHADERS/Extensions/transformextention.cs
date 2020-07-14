using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SHADERS.Extensions
{

	public static class transformextention
	{
        public static bool IsLineOfSight(this Transform origin, Vector3 target, float fieldview,LayerMask collisionMask, Vector3 Offset)
       {

           Vector3 derection = target - origin.position;

           if (Vector3.Angle(origin.forward, derection.normalized) < fieldview / 2)
           {
               float distancetotarget = Vector3.Distance(origin.position, target);


               if (Physics.Raycast(origin.position + Offset + origin.forward * 0.3f, derection.normalized, distancetotarget, collisionMask))
               {

                   return false;

               }

               return true;

           }
           return false;
       }

	}
}
