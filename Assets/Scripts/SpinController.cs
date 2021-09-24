using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpinController : MonoBehaviour
{
    int state = 0; // state 0 cuando la ruleta esta quieta, state 1 cuando esta girando, state 2 cuando se gana
    float timer = 0;
    private canvasController score;
    public GameObject winPanel;
    [SerializeField] float SpinTime;
    [SerializeField] AnimationCurve animation;
    public event UnityAction OnStopSpining;
    private void Awake()
    {
        score = FindObjectOfType<canvasController>();
    }
    private void Start()
    {
        SpinTime= Random.Range(3.4f, 5);
    }
    void Update()
    {
        if (state == 1)
        {
            OnSpinPushed();
        }
        if (score.aScore >= 50) {
            state = 2;
            winPanel.SetActive(true);
        }
    }
    public void RetryButtonPushed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            //cuando paso del state 1 al 0, lanzo un evento, para decir que ya paro de girar
            OnStopSpining?.Invoke();
            state = 0; timer = 0;
            SpinTime = Random.Range(3.4f, 5);
        }
    }
}
