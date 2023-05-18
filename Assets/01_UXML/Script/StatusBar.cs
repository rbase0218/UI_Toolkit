using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatusBar : VisualElement
{
    // UxmlFactory : ~���� ���� ���� ���� Instance�ϴ� ���� ? ? 
    // �ش� ��Ҹ� �����ϸ� UXML���� <StatusBar>�� ����� �����ϴ�.

    string m_Status;
    public string status { get; set; }

    public StatusBar()
    {
        m_Status = string.Empty;
    }
}