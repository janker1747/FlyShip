using UnityEngine;
using UnityEngine.UI;
using System;

public class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _windowGroup.alpha = 1f;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _actionButton.interactable = false;
        gameObject.SetActive(false);
    }
}
