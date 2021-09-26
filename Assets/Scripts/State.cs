using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State :MonoBehaviour
{
    protected SpinController spinController;
    public  State(SpinController _spinController)
    {
        spinController = _spinController;
        Execute();
    }
    public virtual void RandomSpin ()
    {
         spinController.spinTime =  Random.Range(spinController.spinTimeStart, spinController.spinTimeEnd);
    }
    public virtual void Execute()
    {
        
    }
}
