using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnitController;

public class StdUnitMage : StdUnit
{
    
    public GameObject magicBall;
    public GameObject rock;

    private int _attackType;

    public override void Update()
    {   
        base.Update();
        animator.SetFloat("MoveAnimSpeed" , rb.velocity.magnitude);
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

    
    public override void CustomAttack(int attack)
    {
        _attackType = attack;
        DoAttack();
    }

    //Animation Callbacks
    public void FootR(){

    }

    public void FootL(){

    }

    public void Hit(){
        if(_attackType == 0){
            var rb = Instantiate(magicBall, Vector3.zero , Quaternion.identity).GetComponent<Rigidbody>();
            rb.transform.position = transform.position + transform.forward + Vector3.up;
            rb.AddForce(transform.forward * 50, ForceMode.Impulse);        
            Destroy(rb.gameObject, 3);
        }
        else if(_attackType == 1){
            var rb = Instantiate(rock, Vector3.zero , Quaternion.identity).GetComponent<Rigidbody>();
            rb.transform.position = transform.position + transform.forward * 3 + Vector3.up * 0.1f;
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);        
        }else if(_attackType == 2){

            RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5,transform.forward,5); 
            foreach(RaycastHit h in hits){
                if(h.rigidbody != null && h.rigidbody != rb){
                    h.rigidbody.AddForce(transform.forward * 30 , ForceMode.Impulse);
                }
            }
        }
        
    }

}
