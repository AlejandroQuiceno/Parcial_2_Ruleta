using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collisionScores : MonoBehaviour
{
    public event UnityAction<int> OnScoreChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITriangle triangle = collision.GetComponent<Triangle>();
        if (triangle != null) {
            OnScoreChange?.Invoke(triangle.ModifyScore());
        }          
    }
}
