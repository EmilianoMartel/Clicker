using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUIManager : MonoBehaviour
{
    [SerializeField] private ClickCounter _counter;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameManager _manager;
    [SerializeField] private TMPro.TMP_Text _actualClicksText;
    [SerializeField] private TMPro.TMP_Text _currentTimeText;
    [SerializeField] private List<TMPro.TMP_Text> _bestText;

    private void OnEnable()
    {
        _counter.actualCount += HandleClickAmount;
        _timer.actualTime += UpdateTimerText;
        _manager.maxClicks += HandleMaxClick;
    }

    private void OnDisable()
    {
        _counter.actualCount -= HandleClickAmount;
        _timer.actualTime -= UpdateTimerText;
        _manager.maxClicks -= HandleMaxClick;
    }

    private void Awake()
    {
        Validate();
    }

    private void HandleClickAmount(int count)
    {
        _actualClicksText.text = count.ToString() + " Clicks";
    }

    private void UpdateTimerText(float currentTime)
    {
        int seconds = Mathf.FloorToInt(currentTime);
        int miliSeconds = Mathf.FloorToInt((currentTime - seconds) * 1000);
        _currentTimeText.text = string.Format("{0:00}:{1:000}", seconds, miliSeconds);
    }

    private void HandleMaxClick(int max)
    {
        for (int i = 0; i < _bestText.Count; i++)
        {
            _bestText[i].text = string.Format("{0:000}", max);
        }
    }

    private void Validate()
    {
        if (!_counter)
        {
            Debug.LogError($"{name}: Counter is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_timer)
        {
            Debug.LogError($"{name}: Timer is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_manager)
        {
            Debug.LogError($"{name}: GameManager is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_actualClicksText)
        {
            Debug.LogError($"{name}: ClickText is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (!_currentTimeText)
        {
            Debug.LogError($"{name}: CurrentTimeText is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
        if (_bestText.Count == 0)
        {
            Debug.LogError($"{name}: BestText is null.\nCheck and assigned one.\nDisabling component.");
            enabled = false;
            return;
        }
    }
}