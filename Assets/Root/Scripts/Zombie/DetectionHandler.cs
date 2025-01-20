using UnityEngine;

namespace Root
{
    public class DetectionHandler : MonoBehaviour
    {
        public Collider DetectAround(float radius, Vector3 position, int layerMask)
        {
            var colliders = new Collider[1];
            
            Physics.OverlapCapsuleNonAlloc(position - Vector3.up, position + Vector3.up, radius, colliders, layerMask);

            return colliders[0];;
        }
    }
}