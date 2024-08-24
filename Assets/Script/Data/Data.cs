using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.XR;

public class Data
{
    public float curPoint = 0;
    public int nextLevelPoint = 50;
    public float speed = 1;
    public int lastItem = 0;
    public int curLevel = 1;
    public float clickPointGain = 2;
    public List<int> extraItemUnlocked = new List<int>();
    public List<int> itemUnlocked = new List<int>();
    public bool gender = true;
    public Data()
    {
        itemUnlocked.Add(0);
    }

    public void UpdateCurPoint(float basePointGain, float x = 0, float y = 0)
    {
        float baseScale = 1;
        foreach(var item in GameManager.instance.extraItems)
        {
            if(item.isUnlock) baseScale *= item.pointScale;
        }
        curPoint += basePointGain * baseScale;
        UIManager.instance.SpawnPoint(basePointGain * baseScale, x, y);
    }

    public void Save()
    {
        //PlayerPrefs.SetInt("Saved", 1);
        //PlayerPrefs.SetFloat("Cur Point", curPoint);
        //PlayerPrefs.SetFloat("Speed", speed);
        //PlayerPrefs.SetInt("Last Item", lastItem);
        //PlayerPrefs.SetInt("Next Level Point", nextLevelPoint);
        //PlayerPrefs.SetInt("Cur Level", curLevel);
        
        //apply sorting algorithm to list if neccessary

        var json = JsonUtility.ToJson(this);
        var dataPath = Application.persistentDataPath;
        Debug.Log(dataPath);
        File.WriteAllText(dataPath + "/save.json", json);
    }
}
