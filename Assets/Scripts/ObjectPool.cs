using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    GameObject Prefab;
    private int size;
    [HideInInspector]
    public List<GameObject> pool = new List<GameObject>();
    [SerializeField]
    private GeneralSettings settings;

    void Start()
    {
        size = settings.PoolSize;

        for (int i = 0; i < size; i++)
        {
            var newObject = Instantiate(Prefab);
            newObject.transform.rotation = Quaternion.identity;
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    public GameObject GetObject()
    {
        if(pool.Count < 1)
        {
            AddObject();
        }

        var lastObject = pool[pool.Count - 1];
        pool.Remove(lastObject);
        lastObject.SetActive(true);
        return lastObject;
    }

    public void PutObject(GameObject newObject)
    {
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(false);
        pool.Add(newObject);
    }

    void AddObject()
    {
        var newObject = Instantiate(Prefab);
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(false);
        pool.Add(newObject);
    }
}
