using SciptableObjects;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Handle the collisions of stones, configure spread angel and set velocity (spread angel and speed configurable in General Settings)
/// </summary>
public class StoneMover : MonoBehaviour
{

    private float _speed, _angle;
    [SerializeField]
    private GeneralSettings _settings;

    private void Awake()
    {
        _speed = _settings.StoneMovementSpeed;
        _angle = _settings.StoneSpreadAngle;
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = -Vector2FromAngle(Random.Range(-_angle, _angle)) * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet") || other.IsTouchingLayers())
        {
            gameObject.SetActive(false);
        }
    }

    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
