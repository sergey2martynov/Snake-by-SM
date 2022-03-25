using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    [SerializeField] private GameObject _scoreResult;

    [SerializeField] private Text _scoreResultText;

    [SerializeField] private Button _buttonRestart;


    public void SetGameOVerScreenActive(bool isActive)
    {
        _panel.SetActive(isActive);
        _scoreResult.SetActive(isActive);
        _scoreResultText.gameObject.SetActive(isActive);
        _buttonRestart.gameObject.SetActive(isActive);
    }
}
