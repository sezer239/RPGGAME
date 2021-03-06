﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : UnitController
{
    public static float JUMP_INTERVAL = 1;

    public int controlSchema{
        get{
            return _controlSchema;
        }
        set{
            _controlSchema = value;
        }
    }
    private int _controlSchema;

    private float _lastJumpCommand = 0;
    
    override public void OnUnitChanged(Unit u){
            
    }

    public PlayerUnitController(int ctrlSchema){
        this.controlSchema = ctrlSchema;
    }

    override public UnitControllerType GetUnitControllerType(){
        return UnitControllerType.PLAYER_CONTROLLER;
    }

    public override void Tick()
    {
        if(controlSchema==0){
            Vector3 dir = new Vector3( Input.GetAxis("Horizontal")  ,0, Input.GetAxis("Vertical")); 

            if(dir.magnitude != 0)
                controlledUnit.Move(dir);
            else
                controlledUnit.DoStop();

            if(Input.GetAxis("Jump") > 0 && Time.time - _lastJumpCommand > JUMP_INTERVAL){
                _lastJumpCommand = Time.time;
                controlledUnit.Jump();
            }

            if(Input.GetKeyDown(KeyCode.R)){
                controlledUnit.Attack( new Attack(Attack.Type.PROJECTILE, Attack.DamageType.MAGIC | Attack.DamageType.PIERCE,0,15,100,0.1f,0,false) );
            }
            if(Input.GetKeyDown(KeyCode.F)){

            }
            if(Input.GetKeyDown(KeyCode.V)){

            }
        }
    }
}
