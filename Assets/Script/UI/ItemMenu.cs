using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private GameObject menu;
    private List<ItemBtn> itemBtns = new List<ItemBtn>();
    private void Start()
    {
        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        foreach(var config in GameManager.instance.configs)
        {
            ItemBtn item = new ItemBtn(menu, config, gameObject, GameManager.instance.data);
            itemBtns.Add(item);
        }

    }

    public void EnableBtnExcept(Button btn)
    {
        foreach (var item in itemBtns)
        {
            if (item.btn != btn && item.config.isUnlock) item.btn.interactable = true;
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in itemBtns)
        {
            if (item.config.unlockPoint <= GameManager.instance.data.curPoint && item.config != GameManager.instance.curConfig) item.btn.interactable = true;
        }
    }

}
