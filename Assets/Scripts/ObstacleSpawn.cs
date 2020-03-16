using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclePool;
    [SerializeField, Range(0f, 5f)] private float _timer = 0f;
    [SerializeField] public Transform[] lanes;
    void ComeAtMeBruh()
    {
        var obstacle = _obstaclePool.GetFromPool();
        var obstacleManagment = obstacle.GetComponent<ObstacleManagment>();
        obstacleManagment.BindToPool(_obstaclePool);
        _timer = 0;
        
    }
   
    void Start()
    {
        Transform selectedLane = lanes[Random.Range(0, lanes.Length)];
        transform.position = selectedLane.position;
    }

    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 3f)
        {
            ComeAtMeBruh();
            _timer = 0f;
        }
        
    }
}
