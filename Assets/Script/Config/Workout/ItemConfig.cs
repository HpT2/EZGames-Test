using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Config/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    private float time = 0;
    private Animator animator;
    public GameObject item;
    private Data data;
    public Vector3 basePosition;
    [SerializeField] private float pointGain;
    private float animationLength;
    public Texture texture;
    public int unlockPoint;
    public bool isUnlock = false;
    public int index;
    public virtual void Load(GameObject character, Data data)
    {
        GameManager.instance.SetPosition(character, basePosition, new Vector3(0, 45, 0));
        animator = character.GetComponent<Animator>();
        animationLength = animator.runtimeAnimatorController.animationClips[0].length / data.speed;
        this.data = data;
        animator.SetFloat("speed", data.speed);
    }

    public virtual void Update()
    {
        UIManager.instance.UpdatePoint(data.curPoint, data.nextLevelPoint);
        if (data.curPoint >= data.nextLevelPoint) LevelUp();
        if (time >= animationLength)
        {
            time = 0;
            data.UpdateCurPoint(pointGain);
        }
        else time += Time.deltaTime;
    }

    public virtual void LevelUp()
    {
        data.curLevel += 1;
        data.speed += 0.25f;
        data.nextLevelPoint = (int)Mathf.Pow(50, (data.curLevel + 1) / 2.0f);
        animator.SetFloat("speed", data.speed);
        animationLength = animator.runtimeAnimatorController.animationClips[0].length / data.speed;
    }

    public virtual void UnLoad()
    {
        GameObject.Destroy(item);
    }
}
