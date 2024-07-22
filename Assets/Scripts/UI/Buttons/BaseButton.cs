using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    protected abstract void ClickButton();
    
}
