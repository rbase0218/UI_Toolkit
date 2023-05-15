using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainView : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset ListEntryTemplate;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        var characterListController = new CharacterListController();
        characterListController.InitializeCharacterList(uiDocument.rootVisualElement, ListEntryTemplate);
    }
}
