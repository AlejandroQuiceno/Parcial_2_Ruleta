using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    int state = 0; // state 0 cuando la ruleta esta quieta, state 1 cuando esta girando, state 2 cuando se gana
    float timer = 0;
    [SerializeField] float SpinTime;
    [SerializeField] AnimationCurve animation;
    private void Start()
    {
        SpinTime= Random.Range(3.4f, 5);
    }
    void Update()
    {
        if (state == 1) OnSpinPushed(); 
    }
    public void OnSpinPushed()
    {
        state = 1;
        timer += Time.deltaTime;
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z+= Mathf.Lerp(rotationVector.z, 1, 1);
        //rotationVector.z += (1000*animation.Evaluate(timer)*(Mathf.PI/180);
        transform.rotation = Quaternion.Euler(rotationVector);
        if(timer >= SpinTime)
        {
            state = 0; timer = 0;
            SpinTime = Random.Range(3.4f, 5);
        }
    }
}
