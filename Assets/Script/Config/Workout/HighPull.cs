using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighPull", menuName = "Config/HighPullConfig")]
public class HighPull : ItemConfig
{
    [SerializeField] private GameObject kettelBellPos;
    public override void Load(GameObject obj, Data data)
    {
        obj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animator/HighPull") as RuntimeAnimatorController;
        obj.GetComponent<Animator>().applyRootMotion = true;
        GameObject itemPrefab = Resources.Load("Item/kettlebell") as GameObject;
        item = GameObject.Instantiate(itemPrefab);
        kettelBellPos = obj.transform.Find("Armature/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm/RightHand/KettleBellPos").gameObject;
        item.transform.SetParent(kettelBellPos.transform);
        item.transform.localPosition = Vector3.zero;
        base.Load(obj, data);
    }
}
