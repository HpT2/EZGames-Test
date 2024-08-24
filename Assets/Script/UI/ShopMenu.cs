using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private GameObject menu;
    private List<ShopItemBtn> itemBtns = new List<ShopItemBtn>();
    // Start is called before the first frame update
    void Start()
    {
        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        foreach(var extraItem in GameManager.instance.extraItems)
        {
            var item = new ShopItemBtn(menu, extraItem, gameObject, GameManager.instance.data);
            itemBtns.Add(item);
        }
    }

    private void FixedUpdate()
    {
        foreach(var itemBtn in itemBtns)
        {
            if (GameManager.instance.data.curPoint >= itemBtn.extraItem.unlockPoint && !itemBtn.extraItem.isUnlock) itemBtn.btn.interactable = true; 
        }
    }
}
