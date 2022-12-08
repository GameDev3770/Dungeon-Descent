using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public struct RotCost {
    public RotState state;
    public float cost;

    public RotCost(RotState _state, float _cost) {
        this.state = _state;
        this.cost = _cost;
    }
}

[Serializable]
public class Rot : MonoBehaviour
{
    // Start is called before the first frame update
    public float StartingRot;
    public float CurrentRot;
    public List<RotCost> Rules = new List<RotCost>();
    public int MaxStates = 32;

    void Start()
    {
        CurrentRot = StartingRot;
    }

    public void ModifyRot(int[] states) {
        float cost = 0;
        foreach(RotCost rule in Rules) {
            if (states.Contains((int) rule.state)) 
                cost += rule.cost;
        }
        ReduceRot(cost);  // This is its own function in case it ever needs to be called by itself or if something extra needs to be added.
    }

    public void ReduceRot(float amount) {
        this.CurrentRot -= amount;
    }

    public float rot {
        get {
            return CurrentRot;
        }
        set {
            CurrentRot = value;
        }
    }

    public bool IsAlive() {
        return this.rot > 0;
    }

    private void OnValidate() {
        foreach (int i in Enum.GetValues(typeof(RotState))) {
            bool IsAlreadyHere = false;
            foreach (RotCost rule in Rules) {
                if ((int)rule.state == i) {
                    IsAlreadyHere = true;
                    break;
                }
            }
            if (!IsAlreadyHere) {
                Rules.Add(new RotCost((RotState) i, 0));
            }
        }
    }
}
