using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : UnitController
{
    public Transform player;

    public override UnitControllerType GetUnitControllerType()
    {
        return UnitControllerType.AI_CONTROLLER;
    }

    public override void OnUnitChanged(Unit u)
    {
        
    }

    public override void Tick()
    {
        if(Vector3.Distance(player.position, controlledUnit.transform.position) > 5){
            controlledUnit.MoveTo(player.position);
        }
        if(Random.Range(1,10) < 2){
            controlledUnit.Attack(new Attack(Attack.Type.PROJECTILE, Attack.DamageType.MAGIC,0,15,100,0.2f,0,false));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
