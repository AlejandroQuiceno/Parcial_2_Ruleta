using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpinController : MonoBehaviour
{// state 0 cuando la ruleta esta quieta, state 1 cuando esta girando, state 2 cuando se gana
    float timer = 0;
    public canvasController score;
    public GameObject winPanel;
    [SerializeField] public float spinTime;
    [SerializeField] public float spinTimeStart, spinTimeEnd;
    public event UnityAction OnStopSpining;
    private State _currentState;

    public State CurrentState { get => _currentState; set => _currentState = value; }

    private void Awake()
    {
        score = FindObjectOfType<canvasController>();
    }
    private void Start()
    {
        CurrentState = new StillState(gameObject.GetComponent<SpinController>());
    }
    void Update()
    {
        if (_currentState is SpinState)
        {
            _currentState.Execute();
        }
    }
    public void OnSpinPushed()
    {
        CurrentState = new SpinState(gameObject.GetComponent<SpinController>());
    }
    public void SetState(State newState)
    {
        CurrentState = newState;
    }
    public void InvokeOnStopMoving ()
    {
        OnStopSpining?.Invoke();
    } 
    public void RetryButtonPushed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
