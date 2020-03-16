using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControll : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    private Transform PlayerPos;
    
    public void Shoot()
    {

        var bullet = _bulletPool.GetFromPool();
        var bulletController = bullet.GetComponent<projectileControl>();
        if (bulletController == null)
        {
           
            return;
        }
        bulletController.BindToPool(_bulletPool);


    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}