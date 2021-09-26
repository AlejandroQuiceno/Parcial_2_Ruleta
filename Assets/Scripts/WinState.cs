using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    private SpinController _spinController;
    public WinState(SpinController spinController) : base(spinController)
    {
    }
    public override void Execute()
    {
        _spinController = FindObjectOfType<SpinController>();
        _spinController.winPanel.SetActive(true);
    }
}
