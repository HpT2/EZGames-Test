using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button itemMenuBtn;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private Slider pointSlider;
    [SerializeField] private GameObject pointSpawnPrefab;
    [SerializeField] private GameObject pointSpawnPosition;
    [SerializeField] private Button shopMenuBtn;
    // Start is called before the first frame update
    void Start()
    {
        settingBtn.onClick.AddListener(() =>
        {
            UIManager.instance.PopupSetting();
        });

        itemMenuBtn.onClick.AddListener(() =>
        {
            UIManager.instance.PopupItemMenu();
        });

        shopMenuBtn.onClick.AddListener(() =>
        {
            UIManager.instance.PopupShopMenu();
        });
    }

    public void UpdatePoint(float curPoint, int maxPoint)
    {
        pointText.text = curPoint + "/" + maxPoint;
        pointSlider.maxValue = maxPoint;
        pointSlider.value = curPoint;
    }

    public void SpawnPoint(float point, Vector2 position)
    {
        GameObject pointObj = GameObject.Instantiate(pointSpawnPrefab);
        pointObj.transform.SetParent(pointSpawnPosition.transform);
        pointObj.transform.Find("Label").gameObject.GetComponent<TextMeshProUGUI>().text = point.ToString();
        if (position == Vector2.zero)
        {
            pointObj.transform.localPosition = Vector2.zero;
            pointObj.transform.DOLocalMoveY(100, 1);
            GameObject.Destroy(pointObj, 1.2f);
        }
        else
        {
            pointObj.transform.position = position;
            pointObj.transform.DOMoveY(position.y + 100, 1);
            GameObject.Destroy(pointObj, 1.2f);
        }
    }
}
