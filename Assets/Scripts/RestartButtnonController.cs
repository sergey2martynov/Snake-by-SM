using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtnonController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event Action Clicked;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Clicked?.Invoke();
    }
}
