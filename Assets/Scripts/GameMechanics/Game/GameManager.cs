using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit testUnit;
    public PlayerUnitController playerUnitController;
    // Start is called before the first frame update
    void Start()
    {
        playerUnitController = new PlayerUnitController(0);
        playerUnitController.controlledUnit = testUnit;
    }

    // Update is called once per frame
    void Update()
    {
        playerUnitController.Tick();
    }
}
