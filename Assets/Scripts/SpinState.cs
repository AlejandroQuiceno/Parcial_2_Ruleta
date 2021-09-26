using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpinState : State
{
    bool StopSpinning;
    GameObject fondo;
    SpinController spinController;
    float timer;
    public SpinState(SpinController spinController) : base(spinController)
    {
        StopSpinning = false;
    }
    public override void Execute()
    {
        fondo = GameObject.FindGameObjectWithTag("Fondo");
        spinController = fondo.GetComponent<SpinController>();
        Spinning();
        StopSpinning = false;
    }
    public void Spinning()
    {
        timer += Time.deltaTime;
        var rotationVector = fondo.transform.rotation.eulerAngles;
        rotationVector.z += Mathf.Lerp(rotationVector.z, 1, 5);
        //rotationVector.z += (1000*animation.Evaluate(timer)*(Mathf.PI/180);
        Debug.Log("Timer: " + timer);
        fondo.transform.rotation = Quaternion.Euler(rotationVector);
        if (timer >= spinController.spinTime)
        {
            RandomSpin();
            //cuando paso del state 1 al 0, lanzo un evento, para decir que ya paro de girar
            spinController.InvokeOnStopMoving();
            timer = 0;
            
            if (spinController.score.aScore >= 50)
            {
                WinState newState = new WinState(spinController);
                spinController.SetState(newState);
            }
            else
            {
                StillState stillState = new StillState(spinController);
                spinController.SetState(stillState);
            }//state de tipo still)
            StopSpinning = true;
        }
    }
}
