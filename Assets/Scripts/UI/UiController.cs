using Scripts.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private UiElement _startScreen;
        [SerializeField] private UiElement _gameplayUi;
        [SerializeField] private UiElement _victoryScreen;
        [SerializeField] private UiElement _defeatScreen;

        private HashSet<UiElement> _allUiElements = new();
        private UiElement _currentElement;

        private void Awake()
        {
            _allUiElements = GetComponentsInChildren<UiElement>().ToHashSet();
        }

        private void OnEnable()
        {
            GameManager.OnAfterStateChanged += OnAfterStateChanged;

            HideAllUiElements();
        }

        private void OnDisable()
        {
            GameManager.OnAfterStateChanged -= OnAfterStateChanged;
        }

        private void OnAfterStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.StartScreen:
                    _currentElement = _startScreen;
                    _currentElement.Show();
                    break;

                case GameState.Gameplay:
                    SwitchElementTo(_gameplayUi);
                    break;

                case GameState.Victory:
                    SwitchElementTo(_victoryScreen);
                    break;

                case GameState.Defeat:
                    SwitchElementTo(_defeatScreen);
                    break;
            }
        }

        private void SwitchElementTo(UiElement element)
        {
            _currentElement.Hide();
            _currentElement = element;
            _currentElement.Show();
        }

        private void HideAllUiElements()
        {
            foreach (var uiElement in _allUiElements)
                uiElement.Hide();
        }
    }
}