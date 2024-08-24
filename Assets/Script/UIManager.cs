using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject itemMenu;
    [SerializeField] private GameObject shopMenu;
    private void Awake()
    {
        instance = this;
    }

    public void PopupSetting()
    {
        setting.SetActive(true);
    }

    public void PopupItemMenu()
    {
        itemMenu.SetActive(true);
    }

    public void PopupShopMenu()
    {
        shopMenu.SetActive(true);
    }

    public void UpdatePoint(float curPoint, int maxPoint)
    {
        main.GetComponent<Main>().UpdatePoint(curPoint, maxPoint);
    }

    public void SpawnPoint(float point, float x = 0, float y = 0)
    {
        main.GetComponent<Main>().SpawnPoint(point, new Vector2(x, y));
    }

    public bool TouchOnIgnoredField(Touch touch)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = touch.position
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.layer == LayerMask.NameToLayer("UI")) return true;
        }

        return false;
    }
}
