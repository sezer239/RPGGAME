using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitController
{
    public enum  UnitControllerType
    {
        PLAYER_CONTROLLER,
        AI_CONTROLLER
    }

    public event ControlledUnitChanged controlledUnitChanged;

    public Unit controlledUnit{
        get{
            return _controlledUnit;
        }
        set {
            _controlledUnit = value;
            if(_controlledUnit.unitController != this)
                _controlledUnit.unitController = this;
            
            OnUnitChanged(_controlledUnit);
            if(controlledUnitChanged != null)
                controlledUnitChanged.Invoke(_controlledUnit);
        }
    }
    private Unit _controlledUnit;

    public abstract void Tick();

    public abstract void OnUnitChanged(Unit u);

    public abstract UnitControllerType GetUnitControllerType();

    public delegate void ControlledUnitChanged(Unit u);
}
