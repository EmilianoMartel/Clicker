using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _panel;
    [Tooltip("If the button open the panel this value is true, otherwise the value is false")]
    [SerializeField] private bool _isOpener;

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void HandleClick()
    {
        _panel.SetActive(_isOpener);
    }
}
