using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnitController;
using static Attack;

public class StdUnitMage : StdUnit
{
    public Transform magicSpawnPoint;

    private Attack _doAttackType;

    public override void Update()
    {   
        base.Update();
        if(unitController.GetUnitControllerType() == UnitControllerType.PLAYER_CONTROLLER){
            animator.SetFloat("MoveAnimSpeed" , rb.velocity.magnitude);
        }else{
            animator.SetFloat("MoveAnimSpeed" , agent.velocity.magnitude);
        }

        animator.SetBool("Falling" , !isGrounded);
    }
    

    public override void OnControllerChanged(UnitController unitController)
    {
        UnitControllerType type = unitController.GetUnitControllerType(); 
        switch (type)
        {
            case UnitControllerType.PLAYER_CONTROLLER: {
                Debug.Log("Unit " + GetHashCode() + " Is Now Controlled By Player Controller");
            }
            break;

            case UnitControllerType.AI_CONTROLLER: {
                Debug.Log("Unit " + GetHashCode() + " Is Now Controlled By AI Controller");
            }
            break;
        }
    }

    public override UnitType GetUnitType()
    {
        return UnitType.MAGE;
    }

    public override void DoAttack()
    {
        animator.SetTrigger("Attack");
    }

    public override void Attack(Attack attack)
    {
        _doAttackType = attack;
        DoAttack();
    }

    //Animation Callbacks
    public void FootR(){

    }

    public void FootL(){

    }

    public void Hit(){
        if(_doAttackType.attackType == Type.PROJECTILE){
            AttackSpawner.Instance.SpawnProjectile(magicSpawnPoint.position, transform.forward, _doAttackType);
        }
    }

}
