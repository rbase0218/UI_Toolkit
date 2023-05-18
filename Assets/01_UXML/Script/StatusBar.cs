using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatusBar : VisualElement
{
    // UxmlFactory : ~으로 부터 받은 것을 Instance하는 역할 ? ? 
    // 해당 요소를 정의하면 UXML에서 <StatusBar>의 사용이 가능하다.

    string m_Status;
    public string status { get; set; }

    public StatusBar()
    {
        m_Status = string.Empty;
    }
}