using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionScores : MonoBehaviour
{
    public event UnityAction<int> OnScoreChange;
    SpinController spinController;
    Collider2D collider;
    bool triggeractivated = false;
    private void Awake()
    {
        spinController = FindObjectOfType<SpinController>();
        collider = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        spinController.OnStopSpining += OnActivate;
    }
    private void OnDisable()
    {
        spinController.OnStopSpining -= OnActivate;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ITriangle triangle = collision.GetComponent<Triangle>();
        if (triangle != null && triggeractivated) {
            OnScoreChange?.Invoke(triangle.ModifyScore());
            Debug.Log("Detectecto la colision y paro");
            triggeractivated = false;
        }
    }
    public void OnActivate ()
    {
        triggeractivated = true;
    }

}
