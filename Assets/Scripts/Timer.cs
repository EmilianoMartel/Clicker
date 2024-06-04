using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _maxTime = 10;
    [SerializeField] private int _timeToAdd = 5;
    [SerializeField] private ClickCounter _counter;
    [SerializeField] private AdsManager _adsManager;

    private float _currentTime = 60f;

    public event Action<float> actualTime;
    public event Action endTime;

    private void OnEnable()
    {
        _counter.startEvent += HandleStart;
        _adsManager.rewardEvent += HandleReward;
    }

    private void OnDisable()
    {
        _counter.startEvent -= HandleStart;
        _adsManager.rewardEvent -= HandleReward;
    }

    private void Awake()
    {
        Validate();
        _currentTime = _maxTime;
    }

    private void Start()
    {
        actualTime?.Invoke(_currentTime);
    }

    [ContextMenu("Start")]
    private void HandleStart()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_currentTime > 0)
        {
            actualTime?.Invoke(_currentTime);
            _currentTime -= Time.deltaTime;
            yield return null;
        }
        _currentTime = 0;
        actualTime?.Invoke(_currentTime);
        endTime?.Invoke();
        _currentTime = _maxTime;
        actualTime?.Invoke(_currentTime);
    }

    private void HandleReward()
    {
        _currentTime += _timeToAdd;
        actualTime?.Invoke(_currentTime);
    }

    private void Validate()
    {
        if (!_counter)
        {
            Debug.LogError($"{name}: Counter is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_adsManager)
        {
            Debug.LogError($"{name}: AdsManager is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }
}
