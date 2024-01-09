using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler :MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private readonly Dictionary<UI_EVENT_TYPE, Action<PointerEventData>> _eventHandlers = new();

    private void InvokeEventAction(UI_EVENT_TYPE uiEventType, PointerEventData eventData)
    {
        if (_eventHandlers.TryGetValue(uiEventType, out var action)) action?.Invoke(eventData);
    }

    public void BindEvent(UI_EVENT_TYPE uiEventType, Action<PointerEventData> action)
    {
        _eventHandlers[uiEventType] = action;
    }

    public void UnbindEvent(UI_EVENT_TYPE uiEventType)
    {
        if (_eventHandlers.ContainsKey(uiEventType))
        {
            _eventHandlers.Remove(uiEventType);
        }
    }

    public void OnPointerClick(PointerEventData eventData) => InvokeEventAction(UI_EVENT_TYPE.Click, eventData);
    public void OnPointerEnter(PointerEventData eventData) => InvokeEventAction(UI_EVENT_TYPE.PointerEnter, eventData);
    public void OnPointerExit(PointerEventData eventData) => InvokeEventAction(UI_EVENT_TYPE.PointerExit, eventData);

    private void OnDestroy()
    {
        _eventHandlers.Clear();
    }
}
