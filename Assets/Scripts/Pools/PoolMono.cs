using System;
using System.Collections.Generic;
using UnityEngine;


public class PoolMono : MonoBehaviour
{
    public GameObject Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    private List<GameObject> _pool;
    private List<string> listSprits = new List<string>() {"ashdsj", "askls"};
    private int countPrefabType = 5;

    public PoolMono(GameObject prefab, int count)
    {
        Prefab = prefab;
        Container = null;

        CreatePool(count);
    }

    public PoolMono(GameObject prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private GameObject CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out GameObject element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;
        if (AutoExpand)
            return CreateObject(true);

        throw new Exception($"There is no free elements in pool of type {typeof(GameObject)}");
    }

    public void HideAllObjectsToPool()
    {
        foreach (var element in this._pool)
        {
            element.gameObject.SetActive(false);
        }
    }

    public void ShowAllObjectsToPool()
    {
        foreach (var element in this._pool)
        {
            element.gameObject.SetActive(true);
        }
    }
}