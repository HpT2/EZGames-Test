using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject malePrefab;
    [SerializeField] private GameObject femalePrefab;
    public GameObject character;
    public List<ItemConfig> configs;
    public List<ExtraItems> extraItems;
    public ItemConfig curConfig;
    public Data data;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 45;
        instance = this;
       
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            var dataPath = Application.persistentDataPath;
            var json = File.ReadAllText(dataPath + "/save.json");
            data = JsonUtility.FromJson<Data>(json);
        }
        else
        {
            data = new Data();
        }

        if(data.gender) character = GameObject.Instantiate(malePrefab);
        else character = GameObject.Instantiate(femalePrefab);
        SetUpConfigs();
        SetUpExtraItems();
    }

    void SetUpConfigs()
    {
        //apply searching algorithm later if neccessay
        foreach(var config in configs)
        {
            config.isUnlock = false;
            foreach (var index in data.itemUnlocked)
            {
                if (index == config.index)
                {
                    config.isUnlock = true;
                    break;
                }  
            }
        }
        curConfig = configs[data.lastItem];
        curConfig.Load(character, data);
    }

    void SetUpExtraItems()
    {
        foreach (var config in extraItems)
        {
            config.isUnlock = false;
            foreach (var index in data.extraItemUnlocked)
            {
                if (index == config.index) config.isUnlock = true;
            }
        }
    }

    public void ChangeGender(bool gender)
    {
        data.gender = gender;
        GameObject.Destroy(character);
        if(gender)
        {
            character = GameObject.Instantiate(malePrefab);
        }
        else
        {
            character = GameObject.Instantiate(femalePrefab); 
        }
        curConfig.UnLoad();
        curConfig.Load(character, data);
    }

    public void SetPosition(GameObject obj, Vector3 position, Vector3 rotation)
    {
        obj.transform.position = position;
        obj.transform.Rotate(rotation);
    }

    public void ChangeItem(ItemConfig config)
    {
        data.lastItem = config.index; 
        SetPosition(character, character.transform.position, new Vector3(0, -45, 0));
        curConfig.UnLoad();
        curConfig = config;
        curConfig.Load(character, data);
    }

    // Update is called once per frame
    void Update()
    {
        curConfig.Update();
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (UIManager.instance.TouchOnIgnoredField(touch)) return;

                data.UpdateCurPoint(data.clickPointGain, touch.position.x, touch.position.y);
            }
        }
    }

    private void OnApplicationQuit()
    {
        data.Save();
    }
}
