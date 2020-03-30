using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit testUnit;
    public Unit testEnemy;
    public PlayerUnitController playerUnitController;
    public AIController aIController;
    // Start is called before the first frame update
    void Start()
    {
        playerUnitController = new PlayerUnitController(0);
        playerUnitController.controlledUnit = testUnit;

        aIController = new AIController();
        aIController.player = testUnit.transform;
        aIController.controlledUnit = testEnemy; 
    }

    // Update is called once per frame
    void Update()
    {
        playerUnitController.Tick();
        aIController.Tick();
    }
}
