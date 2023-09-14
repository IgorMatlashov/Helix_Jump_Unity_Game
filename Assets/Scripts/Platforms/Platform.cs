using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();
        
        foreach (PlatformSegment segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
            StartCoroutine(DeletePlatform(segment));
        }
    }

    IEnumerator DeletePlatform(PlatformSegment segment)
    {
        yield return new WaitForSeconds(5f);
        if (segment != null) Destroy(segment.gameObject);
    }
}
