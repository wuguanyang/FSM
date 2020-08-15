
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
/// <summary>
/// 状态机
/// </summary>
/// <typeparam name="T">枚举类型转换条件</typeparam>
/// <typeparam name="N">枚举类型状态名字</typeparam>
[Serializable]
public class FSMSystem<T, N> {

    public Dictionary<N, FSMState<T, N>> states;
    public N CurrentStateName { get; private set; }
    public FSMState<T, N> CurrentState { get; private set; }

    public FSMSystem () {
        states = new Dictionary<N, FSMState<T, N>> ();
    }
    public void SetCurrentState (N stateName) {
        CurrentState = states[stateName];
        CurrentStateName = states[stateName].Name;
        CurrentState.OnBeforeEntering ();
    }
    public void AddState (FSMState<T, N> s) {
        if (!states.ContainsKey (s.Name)) {
            states.Add (s.Name, s);
        }
    }

    public void DeleteState (N stateName) {
        if (states.ContainsKey (stateName)) {
            states.Remove (stateName);
        }
    }
    public void PerformTransition (T trans) {
        
        CurrentState.OnBeforeLeaving();
        N nextStateName = CurrentState.GetOutputState(trans);
        Debug.Log($"当前状态{CurrentStateName}，要跳转的状态{nextStateName}");
        if (!nextStateName.Equals(default(N))) {
            CurrentStateName = nextStateName;
            CurrentState = states[CurrentStateName];
            CurrentState.OnBeforeEntering();
        }
    }

}