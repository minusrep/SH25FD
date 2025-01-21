using UnityEngine;

namespace Root
{
    public class Hint : MonoBehaviour
    {
        public string Description => _description;
        
        [SerializeField] private string _description;
    }
}