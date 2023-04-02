using System;
using UnityEngine;

public class FindQuestOld : QuestBase
{
    private Transform[] objTransforms;
    private Transform OobjTransforms;
    private float objRadius;
    private LayerMask objLayer;
    private Collider2D[] objCollider;
    
    // public FindQuestOld(GameObject playerObj, QuestData questData, QuestEventHandler questEvent, 
    //     Transform[] enemy, float radius, LayerMask mask ) : base(playerObj, questData, questEvent)
    // {
    //     this.objTransforms = enemy;
    //     this.objRadius = radius;
    //     this.objLayer = mask;
    // }

    // protected override void OnEnable()
    // {
    //     base.OnEnable();
    // }
    //
    // protected override void OnDisable()
    // {
    //     base.OnDisable();
    // }

    public override void QuestActivated()
    {
        objCollider = Physics2D.OverlapCircleAll(OobjTransforms.position, objRadius, objLayer);
        int objCount = 0;
        
        foreach (var obj in objCollider)
        {
            for (int i = 0; i < objCollider.Length; i++)
            {
                if (objCollider[i] == objCollider[i])
                {
                    objCount++;
                    // if (objCount == objCollider.Length)
                    // {
                    //     QuestCompleted();
                    // }
                }
            }
        }
    }

    public override void QuestCompleted()
    {
        // Do something when quest completed
    }
}