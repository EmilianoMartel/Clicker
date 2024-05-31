using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _maxTime = 10;
    [SerializeField] private ClickCounter _counter;

    private float _currentTime = 60f;

    public event Action<float> actualTime;

    private void OnEnable()
    {
        _counter.startEvent += HandleStart;
    }

    private void OnDisable()
    {
        _counter.startEvent -= HandleStart;
    }

    [ContextMenu("Start")]
    private void HandleStart()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        _currentTime = _maxTime;
        while (_currentTime > 0)
        {
            actualTime?.Invoke(_currentTime);
            _currentTime -= Time.deltaTime;
            yield return null;
        }
        _currentTime = 0;
        actualTime?.Invoke(_currentTime);
    }
}
