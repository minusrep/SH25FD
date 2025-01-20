using System;
using UnityEngine;

namespace Root
{
    public class ProjectileHandler : MonoBehaviour
    {
        private const string ProjectileLayer = "Projectile";

        private const string Head = "head";
        
        public event Action<HitType> OnHit;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(ProjectileLayer))
            {
                var hit = gameObject.name == Head ? HitType.Head : HitType.Default;
                
                OnHit?.Invoke(hit);
            }
        }
    }
}