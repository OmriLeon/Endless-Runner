using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _preheatAmount = 10;
    private List<GameObject> _gameObjectPool = new List<GameObject>();
    public Transform[] lanes;

    private void Awake()
    {
        PreheatPool();
    }

    private void PreheatPool()
    {
        for (var objectIndex = 0; objectIndex <= _preheatAmount; objectIndex++)
        {
            AddToPool();
        }
    }


    public GameObject GetFromPool()
    {
        if (_gameObjectPool == null)
        {
            _gameObjectPool = new List<GameObject>();
        }

        if(_gameObjectPool.Count <= 0)
        {
            AddToPool();
        }
            var objectToGet = _gameObjectPool[0];
            _gameObjectPool.Remove(objectToGet);
             objectToGet.SetActive(true);
            Randomize();
            return objectToGet;

        
    }

    public void ReturnToPool (GameObject objectToReturnToPool)
    {
        var recycledObject = Recycle(objectToReturnToPool);
        recycledObject.SetActive(false);
        _gameObjectPool.Add(objectToReturnToPool);
    }

    private GameObject Recycle (GameObject objectToRecycle)
    {
        objectToRecycle.transform.position = Vector3.zero;
        return objectToRecycle;
    }

    private void AddToPool()
    {
        if (_gameObjectPool == null)
        {
            _gameObjectPool = new List<GameObject>();
        }
        var _instantiatedObject = Instantiate(_prefab);
        _gameObjectPool.Add(_instantiatedObject);
        _instantiatedObject.SetActive(false);
    }

    private void Randomize()
    {
        // here will a randimization of rotation, scale and lane (position)
        Transform SelectdLane = lanes[Random.Range(0, lanes.Length)];

        transform.position = SelectdLane.position;
    }
}
