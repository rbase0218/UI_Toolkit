using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;

public class CharacterListController
{
    private VisualTreeAsset ListEntryTemplate;

    private ListView CharacterList;
    private Label CharClassLabel;
    private Label CharNameLabel;
    private VisualElement CharPortrait;

    private List<CharacterData> AllCharacters;

    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        EnumerateAllCharacters();

        ListEntryTemplate = listElementTemplate;

        CharacterList = root.Q<ListView>("character-list");
        CharClassLabel = root.Q<Label>("character-class");
        CharNameLabel = root.Q<Label>("character-name");
        CharPortrait = root.Q<VisualElement>("character-portrait");

        FIllCharacterList();

        CharacterList.onSelectionChange += OnCharacterSelected;
    }

    private void EnumerateAllCharacters()
    {
        AllCharacters = new List<CharacterData>();
        AllCharacters.AddRange(Resources.LoadAll<CharacterData>("Characters"));
    }

    private void FIllCharacterList()
    {
        CharacterList.makeItem = () =>
        {
            var newListEntry = ListEntryTemplate.Instantiate();
            var newListEntryLogic = new CharacterListEntryController();

            newListEntry.userData = newListEntryLogic;
            
            newListEntryLogic.SetVisualElement(newListEntry);

            return newListEntry;
        };
        
        CharacterList.bindItem = (item, index) =>
        {
            (item.userData as CharacterListEntryController)?.SetCharacterData(AllCharacters[index]);
        };
        
        CharacterList.fixedItemHeight = 45;
        CharacterList.itemsSource = AllCharacters;
    }

    private void OnCharacterSelected(IEnumerable<object> selectedItems)
    {
        var selectedCharacter = CharacterList.selectedItem as CharacterData;

        if (selectedCharacter is null)
        {
            CharClassLabel.text = "";
            CharNameLabel.text = "";
            CharPortrait.style.backgroundImage = null;

            return;
        }

        CharClassLabel.text = selectedCharacter.Class.ToString();
        CharNameLabel.text = selectedCharacter.CharacterName;
        CharPortrait.style.backgroundImage = new StyleBackground(selectedCharacter.PortraitImage);
    }
}