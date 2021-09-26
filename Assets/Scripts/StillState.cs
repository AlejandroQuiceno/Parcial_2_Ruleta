using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillState : State
{
    public StillState(SpinController spinController) : base(spinController)
    {
    }
    public override void Execute()
    {
        RandomSpin();
    }
}
