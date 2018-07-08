using SciptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Stores objects and get/put them in scene with SetActive
/// </summary>
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private int _size;
    [HideInInspector]
    public List<GameObject> Pool = new List<GameObject>();
    [SerializeField]
    private GeneralSettings _settings;

    private void Start()
    {
        _size = _settings.PoolSize;

        for (var i = 0; i < _size; i++)
        {
            AddObject();
        }
    }

    /// <summary>
    /// Gets first deactivated object from pool and activate them in scene
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        if (Pool.Count < 1)
        {
            AddObject();
        }

        var lastObject = Pool.FirstOrDefault(x => !x.activeInHierarchy);
        if (lastObject == null)
        {
            AddObject();
            return GetObject();
        }

        lastObject.SetActive(true);
        return lastObject;
    }

    /// <summary>
    /// Instantiate object in pool and deactivate them in scene
    /// </summary>
    private void AddObject()
    {
        var newObject = Instantiate(_prefab);
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(false);
        Pool.Add(newObject);
    }
}
