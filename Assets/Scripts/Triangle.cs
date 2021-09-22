using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour, ITriangle
{
    [SerializeField] int modifier;
    public int ModifyScore() {
        return modifier;
    }
}
