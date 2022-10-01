using UnityEngine;

namespace Player
{
    public class PlayerGrowthCalculator : MonoBehaviour
    {
        public int GrowthFactor { private set; get; }

        private void Start()
        {
            GrowthFactor = 1;
        }
    }
}
