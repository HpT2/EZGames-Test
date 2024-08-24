using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBtn
{
    public Button btn;
    public ExtraItems extraItem;
 
    public ShopItemBtn(GameObject parent, ExtraItems config, GameObject menu, Data data)
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
            if(!config.isUnlock) 
            {
                obj.transform.Find("UnlockText").gameObject.SetActive(false);
                config.isUnlock = true;
                data.curPoint -= config.unlockPoint;
                GameManager.instance.data.extraItemUnlocked.Add(config.index);
            }
        });

        if (config.isUnlock)
        {
            obj.transform.Find("UnlockText").gameObject.SetActive(false);
            btn.interactable = true;
        }
        this.extraItem = config;
    }
}
