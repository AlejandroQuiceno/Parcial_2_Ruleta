using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour, ITriangle
{
    public int ModifyScore() {
        return modifier;
    }
    [SerializeField] int modifier; 

}
