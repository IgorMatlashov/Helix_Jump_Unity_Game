using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 centerm, float radius)
    {
        if(TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, centerm, radius);
        }
    }
}
