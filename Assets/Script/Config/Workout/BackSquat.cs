using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackSquat", menuName = "Config/BackSquatConfig")]
public class BackSquat : ItemConfig
{
    public override void Load(GameObject obj, Data data)
    {
        obj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animator/BackSquat") as RuntimeAnimatorController;
        base.Load(obj, data);
    }
}
