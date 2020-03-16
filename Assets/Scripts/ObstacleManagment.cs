using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManagment : MonoBehaviour
{
    public int[] lanes = { -3, 0, 3 };
    public int[] hight = { 0, 3 };
    [SerializeField, Range(0f, 10f)] private float _speed;
    [SerializeField] private float MaxZ = 30f;


    
    private ObjectPool _obstaclePool;

    private void Awake()
    {
        var x = lanes[Random.Range(0, lanes.Length)];
        var y = hight[Random.Range(0, hight.Length)];
        transform.position = transform.position + new Vector3(x, y, 0);

        RotationRandom();
        ScaleRandom();
    }

    void Update()
    {
        var position = transform.position;
        position.z -= _speed * Time.deltaTime;
        if (position.z <= MaxZ)
        {
            _obstaclePool.ReturnToPool(gameObject);
            return;
        }
        transform.position = position;
    }

    public void BindToPool (ObjectPool pool)
    {
        _obstaclePool = pool;
    }
   
    void RotationRandom()
    {
        Vector3 euler = transform.eulerAngles;
        euler.x = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
    }

    void ScaleRandom()
    {
        Vector3 scale = transform.localScale;
        scale.x = Random.Range(0.5f, 2f);
        scale.y = Random.Range(0.5f, 2f);
        scale.z = Random.Range(0.5f, 2f);
        transform.localScale = scale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _obstaclePool.ReturnToPool(gameObject);
        return;
    }
}
