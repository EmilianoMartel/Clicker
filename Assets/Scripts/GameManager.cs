using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ClickCounter _clicker;
    [SerializeField] private GameObject _finalPanel;

    private SaveData _saveData = new();

    public event Action startAd;
    public event Action<int> maxClicks;

    private void OnEnable()
    {
        _clicker.finalCount += HandleFinalScore;
    }

    private void OnDisable()
    {
        _clicker.finalCount -= HandleFinalScore;
    }

    private void Awake()
    {
        Validate();

        _saveData.Start();
    }

    private void Start()
    {
        maxClicks.Invoke(_saveData.maxClicks);
    }

    private void HandleFinalScore(int score)
    {
        if (_saveData.NewRecordCheck(score))
        {
            _finalPanel.SetActive(true);
            maxClicks.Invoke(_saveData.maxClicks);
            return;
        }

        startAd?.Invoke();
    }

    private void Validate()
    {
        if (!_clicker)
        {
            Debug.LogError($"{name}: Clicker is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_finalPanel)
        {
            Debug.LogError($"{name}: FinalPanel is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }
}