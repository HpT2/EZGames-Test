using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Run", menuName = "Config/RunConfig")]
public class Run : ItemConfig
{
    
    public override void Load(GameObject obj, Data data)
    {
        obj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animator/Run") as RuntimeAnimatorController;
        obj.GetComponent<Animator>().applyRootMotion = false;
        GameObject itemPrefab = Resources.Load("Item/treadmill") as GameObject;
        item = GameObject.Instantiate(itemPrefab);
        GameManager.instance.SetPosition(item, basePosition, new Vector3(0, 45, 0));
        base.Load(obj, data);
    }
}
