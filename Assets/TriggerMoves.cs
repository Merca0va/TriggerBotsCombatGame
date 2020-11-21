using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoves : MonoBehaviour
{

    public WRobotTrigger Trigger;
    public WRobotTrigger.MoveSet moveSet;



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WhiteRobot")
        {
            Trigger.moveSet = moveSet;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "WhiteRobot")
        {
            Trigger.moveSet = WRobotTrigger.MoveSet.none;
        }
    }
}
