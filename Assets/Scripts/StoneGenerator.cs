using SciptableObjects;
using System.Collections;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Generates the stones from pool with some spawnRate (configurable in the General Settings)
/// </summary>
public class StoneGenerator : MonoBehaviour
{

    private float _spawnRate;
    private ObjectPool _stones;
    private CameraBorders _cameraBorders;
    private float _stoneSize;
    [SerializeField]
    private GeneralSettings _settings;

    private void Start()
    {
        _stones = GetComponent<ObjectPool>();
        _cameraBorders = Camera.main.GetComponent<CameraBorders>();
        _stoneSize = transform.lossyScale.x;

        _spawnRate = _settings.StoneSpawnRate;

        StartCoroutine(GenerateStones());
    }

    private IEnumerator GenerateStones()
    {
        yield return null;
        if (_spawnRate < 0.01f) yield break;
        SpawnStone();
        yield return new WaitForSeconds(1 / _spawnRate);
        yield return GenerateStones();
    }

    /// <summary>
    /// Gets the stone from pool and configure position
    /// </summary>
    private void SpawnStone()
    {
        var stone = _stones.GetObject();
        stone.transform.position = new Vector2(_cameraBorders.MaxX + _stoneSize, Random.Range(_cameraBorders.MinY, _cameraBorders.MaxY));
    }
}
