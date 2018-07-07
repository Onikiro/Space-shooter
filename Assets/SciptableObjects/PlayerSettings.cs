using UnityEngine;

[CreateAssetMenu(fileName = "New player settings", menuName = "Settings/Player settings")]
public class PlayerSettings : ScriptableObject {

    public float ShipMovementSpeed;
    public float FireRate;
}
