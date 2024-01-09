using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public static class UIEvent
{
    public static void SetEvent(this GameObject gameObject, UI_EVENT_TYPE uiEventType, Action<PointerEventData> action)
    {
        UIEventHandler handler = Utility.GetAddComponent<UIEventHandler>(gameObject);
        handler.BindEvent(uiEventType, action);
    }

}
