using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Screen;
using UnityScreenNavigator.Runtime.Core.Shared;

using Screen = UnityScreenNavigator.Runtime.Core.Screen.Screen;

public class HomeScreen : Screen
{
    [SerializeField] private Button _saveButton, _loadButton;
    [SerializeField] private Button _shopButton, _inventoryButton;
    [SerializeField] private Button _collectAllButton;
    [SerializeField] private Button _plantButton;
    private FarmGamePresenter _farmGamePresenter;

    public override async UniTask Initialize()
    {
        _saveButton.onClick.AddListener(OnSaveButtonClicked);
        _loadButton.onClick.AddListener(OnLoadButtonClicked);
        _shopButton.onClick.AddListener(OnShopButtonClicked);
        _inventoryButton.onClick.AddListener(OnInventoryButtonClicked);
        _collectAllButton.onClick.AddListener(OnCollectAllButtonClicked);
        _plantButton.onClick.AddListener(OnPlantButtonClicked);

        // Simulate loading time.
        await UniTask.Delay(TimeSpan.FromSeconds(1));
    }

    public override void DidPushEnter()
    {
        _farmGamePresenter = transform.gameObject.GetComponent<FarmGameView>().FarmGamePresenter;
    }

    public override UniTask Cleanup()
    {
        _saveButton.onClick.RemoveListener(OnSaveButtonClicked);
        _loadButton.onClick.RemoveListener(OnLoadButtonClicked);
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
        _inventoryButton.onClick.RemoveListener(OnInventoryButtonClicked);
        _collectAllButton.onClick.RemoveListener(OnCollectAllButtonClicked);
        _plantButton.onClick.RemoveListener(OnPlantButtonClicked);
        return UniTask.CompletedTask;
    }

    private void OnCollectAllButtonClicked()
    {
        throw new NotImplementedException();
    }

    private void OnLoadButtonClicked()
    {
        throw new NotImplementedException();
    }

    private void OnSaveButtonClicked()
    {
        throw new NotImplementedException();
    }

    private void OnInventoryButtonClicked()
    {
        var option = new WindowOption("prefab_page_inventory", true);
        ScreenContainer.Of(transform).Push(option);
    }

    private void OnShopButtonClicked()
    {
        var option = new WindowOption("prefab_page_shop", true);
        ScreenContainer.Of(transform).Push(option);
    }

    private async void OnPlantButtonClicked()
    {
        var modalContainer = ModalContainer.Find("Modal_Container");
        var pushOption = new WindowOption("prefab_modal_seed_menu", true);
        modalContainer.Push(pushOption);

        var modal = await pushOption.WindowCreated.WaitAsync();
        var seedMenuModal = (SeedMenuModal)modal;
        seedMenuModal.Setup(_farmGamePresenter);
    }
}