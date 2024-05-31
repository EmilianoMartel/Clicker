using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private Button _clickButton;

    private bool _isPlaying = false;
    private int _count = 0;

    public event Action<int> actualCount;
    public event Action startEvent;

    private void OnEnable()
    {
        _clickButton.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        _clickButton.onClick.RemoveAllListeners();   
    }

    private void Awake()
    {
        if (!_clickButton)
        {
            Debug.LogError($"{name}: Click button is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }

    private void HandleClick()
    {
        if (!_isPlaying)
        {
            _isPlaying = true;
            startEvent?.Invoke();
            return;
        }
        _count++;
        actualCount?.Invoke(_count);
    }
}