using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public static int DEFAULT_UNIT_HEALT = 100;

    public static float MAX_GROUND_CHECK_DISTANCE = 1;
    public enum UnitType
    {
        MAGE
    }

    public event OnUnitControllerChanged unitControllerChanged;

    protected Animator animator;

    protected Rigidbody rb;

    public int healt;

    public float moveSpeed;

    public float maxMoveSpeed;

    public float jumpSpeed;

    public bool doGroundCheck;

    public bool limitGroundSpeed;

    public bool isGrounded{
        get{
            return _isGrounded;
        }
        private set{
            _isGrounded = value;
        }
    }
    private bool _isGrounded;

    private Transform _groundCheckBegin;
    private Transform _groundCheckEnd;

    private int _layerMask;
    public UnitController unitController{
        get{
            return _unitController;
        }
        set{
            _unitController = value;
            if(_unitController.controlledUnit != this){
                _unitController.controlledUnit = this;
            }
            OnControllerChanged(_unitController);
            if(unitControllerChanged != null)
                unitControllerChanged.Invoke(_unitController);
        }
    }
    private UnitController _unitController;

    public virtual void Awake()
    {   
        healt = DEFAULT_UNIT_HEALT;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _groundCheckBegin = transform.Find( "GroundCheckBegin" );
        isGrounded = true;
        if(_groundCheckBegin == null){
            Debug.LogError( "Unit " +  GetHashCode() + " has no GroundCheckBegin Child GameObject Setting the isGrounded = false");
            isGrounded = false;
        }

        _groundCheckEnd = transform.Find( "GroundCheckEnd" );
        if(_groundCheckEnd == null){
            Debug.LogError( "Unit " +  GetHashCode() + " has no GroundCheckEnd Child GameObject Setting the isGrounded = false");
            isGrounded = false;
        }

        if(isGrounded){

            doGroundCheck = Vector3.Distance(_groundCheckBegin.position , _groundCheckEnd.position) < MAX_GROUND_CHECK_DISTANCE;
            limitGroundSpeed = doGroundCheck;

            if(!doGroundCheck){
                Debug.LogWarning("Unit " + GetHashCode() + " Has To Long Ground Check Child Game Objects Setting the doGroundCheck = false");
            }
        }

        _layerMask = LayerMask.NameToLayer("Walkable");
    }

    public virtual void Update(){  
        if(!doGroundCheck) return;
        //TODO: LAYER MASK DOES NOT WORK
        isGrounded = Physics.Linecast(_groundCheckBegin.position, _groundCheckEnd.position); 
    }

    public abstract void DoStop();
    public abstract void MoveTo(Vector3 pos);
    public abstract void Move(Vector3 dir);
    public abstract void Jump();

    public abstract void DoAttack();

    public abstract void CustomAttack(int attack);

    public abstract UnitType GetUnitType();
    public abstract void OnControllerChanged(UnitController unitController);

    public delegate void OnUnitControllerChanged(UnitController unitController);
}
