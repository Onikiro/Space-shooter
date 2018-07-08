using UnityEngine;

namespace SciptableObjects
{
    /// <inheritdoc />
    /// <summary>
    /// Player settings scriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "New player settings", menuName = "Settings/Player settings")]
    public class PlayerSettings : ScriptableObject {

        public float ShipMovementSpeed;
        public float FireRate;
        public float BulletSpeed;
    }
}
