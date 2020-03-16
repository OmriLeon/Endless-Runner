using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
   
    [SerializeField, Range(0f, 10f)] private float _speed;
    [SerializeField] private float _maxZ = 30f;

    private ObjectPool _bulletPool;
    private Transform PlayerPos;

    public void BindToPool(ObjectPool pool)
    {
        _bulletPool = pool;
    }

    private void Awake()
    {
        PlayerPos = GameObject.Find("player").transform;
        transform.position = PlayerPos.position;
    }

    void Update()
    {
        if (gameObject.activeSelf == false)
        {
            transform.position = PlayerPos.position;
        }
        var position = transform.position;
        position.z += _speed * Time.deltaTime;
        if (position.z >= _maxZ)
        {
            _bulletPool.ReturnToPool(gameObject);
            return;
        }
        transform.position = position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        _bulletPool.ReturnToPool(gameObject);

    }
}