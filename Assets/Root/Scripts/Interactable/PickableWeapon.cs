using UnityEngine;

namespace Root
{
    public class PickableWeapon : Interactable
    {
        public int WeaponID => _weaponID;
        
        [SerializeField] private int _weaponID;
        
        public override void Interact()
        {
            Destroy(gameObject);
        }
    }
}