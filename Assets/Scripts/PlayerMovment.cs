using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] int moveTime = 3;
    [SerializeField] float Timer = 1f;
    public Transform[] lanes;

    private int _CurrentLane;
    private int _TargetLane;
    void Start()
    {
        _CurrentLane = 1;
        _TargetLane = _CurrentLane;
        transform.position = lanes[_CurrentLane].position;
        Timer = 0f;
    }


    void Update()
    {
        InputCheck();
        _PlayerMovement();

    }

    private void _PlayerMovement()
    {
        if (_CurrentLane == _TargetLane)
        {
            return;
        }
        Timer += Time.deltaTime;

        if (Timer / moveTime > 0.7f)
        {
            Timer -= Time.deltaTime / 3;
        }
        transform.position = Vector3.Slerp(lanes[_CurrentLane].position, lanes[_TargetLane].position, Timer / moveTime);

        if (Vector3.Distance (transform.position, lanes[_TargetLane].position) < 0.2f)
        {
            _CurrentLane = _TargetLane;
            Timer = 0;
        }
    }

    private void InputCheck()
    {
        if (_CurrentLane != _TargetLane)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A) && _CurrentLane != 3)
        {
            if (_CurrentLane > 0)
            {
                _TargetLane = _CurrentLane - 1;
                Timer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && _TargetLane != 2)
        {
            if (_CurrentLane < lanes.Length - 1)
            {
                _TargetLane = _CurrentLane + 1;
                Timer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && _CurrentLane <= 2)
            {
            _TargetLane = _CurrentLane + 3;
            }
        if (Input.GetKeyDown(KeyCode.S) && _CurrentLane >=3)
        {
            _TargetLane = _CurrentLane - 3;
        }
    }
}

