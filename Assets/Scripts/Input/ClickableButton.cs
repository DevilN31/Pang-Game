using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nati.Input
{
    public class ClickableButton : TouchInputController, IPointerDownHandler
    {
        [SerializeField]
        ClickableButtonType _ClickableButtonType;
        public void OnPointerDown(PointerEventData eventData)
        {
            TouchInputController.OnPressed?.Invoke(_ClickableButtonType);
        }
        
    }
}
