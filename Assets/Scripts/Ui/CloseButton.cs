using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class CloseButton : MonoBehaviour
{
    [SerializeField]
    GameObject _UiElementToShow;

    Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(HideCurrentPanel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HideCurrentPanel);

    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    void HideCurrentPanel()
    {
        if (_UiElementToShow != null)
        {
            _UiElementToShow.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            GameEvents.UnFreezeGame?.Invoke();
        }
    }
}
