using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    public class RagdollHandler : MonoBehaviour
    {
        public IReadOnlyList<ProjectileHandler> ProjectileHandlers => _projectileHandlers;
        
        private List<Rigidbody> _rigidbodies;

        private List<ProjectileHandler> _projectileHandlers;
        
        public void Init()
        {
            _rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
            
            _projectileHandlers = new List<ProjectileHandler>();

            _rigidbodies.ForEach(rigidbody => _projectileHandlers.Add(rigidbody.gameObject.AddComponent<ProjectileHandler>()));
            
            Disable();
        }

        public void Enable() 
            => _rigidbodies.ForEach(rigidbody => rigidbody.isKinematic = false);
        
        public void Disable() 
            => _rigidbodies.ForEach(rigidbody => rigidbody.isKinematic = true);
    }
}