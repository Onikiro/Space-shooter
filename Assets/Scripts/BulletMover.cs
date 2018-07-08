using SciptableObjects;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Handle the collisions of bullets and set velocity (speed configurable in Player Settings)
/// </summary>
public class BulletMover : MonoBehaviour
{

    private float _speed;
    private GameProcessHandler _gameProcess;
    private int _points;
    [SerializeField]
    private GeneralSettings _generalSettings;
    [SerializeField]
    private PlayerSettings _playerSettings;


    private void Awake()
    {
        _gameProcess = GameObject.Find("GameProcess").GetComponent<GameProcessHandler>();

        _points = _generalSettings.PointsPerStone;
        _speed = _playerSettings.BulletSpeed;
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stone"))
        {
            _gameProcess.Score += _points;
            gameObject.SetActive(false);
        }
        else if (other.IsTouchingLayers())
        {
            gameObject.SetActive(false);
        }
    }
}
