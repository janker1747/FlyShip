using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    private void Awake()
    {
        Close();
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}