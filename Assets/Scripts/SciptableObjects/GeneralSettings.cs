using UnityEngine;

namespace SciptableObjects
{
    /// <inheritdoc />
    /// <summary>
    /// General settings scriptableObject
    /// </summary>
    [CreateAssetMenu(fileName = "New general settings", menuName = "Settings/General settings")]
    public class GeneralSettings : ScriptableObject {

        [Header("Настройки камней")]
        public float StoneMovementSpeed;
        public float StoneSpawnRate;
        public float StoneSpreadAngle;
        public int PoolSize;
        [Header("Настройки очков")]
        [Tooltip("Количество очков, выдаваемых за уничтожение камня.")]
        public int PointsPerStone;
        [Tooltip("Период выдачи очков за время.")]
        public float ScorePeriod;
        [Tooltip("Количество очков, выдаваемых за указанный период времени.")]
        public int PointsPerPeriod;
    }
}
