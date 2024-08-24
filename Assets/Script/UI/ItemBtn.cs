using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn 
{
    public Button btn;
    public ItemConfig config;
    public ItemBtn(GameObject parent, ItemConfig config, GameObject menu, Data data)
    {
        GameObject prefabs = Resources.Load("UI/ItemMenuBtn") as GameObject;
        GameObject obj = GameObject.Instantiate(prefabs);
        obj.transform.Find("UnlockText").gameObject.GetComponent<TextMeshProUGUI>().text = config.unlockPoint + " points";
        obj.transform.SetParent(parent.transform);
        obj.transform.Find("ItemImg").gameObject.GetComponent<RawImage>().texture = config.texture;
        btn = obj.GetComponent<Button>();
        btn.interactable = false;
        btn.onClick.AddListener(() =>
        {
            if(config.isUnlock)
            {
                GameManager.instance.ChangeItem(config);
                menu.SetActive(false);
                btn.interactable = false;
                menu.GetComponent<ItemMenu>().EnableBtnExcept(btn);
            }
            else
            {
                obj.transform.Find("UnlockText").gameObject.SetActive(false);
                config.isUnlock = true;
                GameManager.instance.data.itemUnlocked.Add(config.index);
                GameManager.instance.data.curPoint -= config.unlockPoint;
            }
        });

        if (config.isUnlock)
        {
            obj.transform.Find("UnlockText").gameObject.SetActive(false);
            if (config == GameManager.instance.curConfig) btn.interactable = false;
            else btn.interactable = true;
        }
        this.config = config;
    }
}
