using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AirSquat", menuName = "Config/AirSquatConfig")]
public class AirSquat : ItemConfig
{
    public override void Load(GameObject obj, Data data)
    {
        obj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animator/AirSquat") as RuntimeAnimatorController;
        obj.GetComponent<Animator>().applyRootMotion = true ;
        base.Load(obj, data);
    }
}
