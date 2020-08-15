using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态基类
/// </summary>
/// <typeparam name="T">枚举类型转换条件</typeparam>
/// <typeparam name="N">枚举类型状态名字</typeparam>
public abstract class FSMState<T, N> {

    protected Dictionary<T, N> map = new Dictionary<T, N> ();
    public N Name { get; protected set; }

    protected FSMState (N name) {
        Name = name;
    }
    public void AddTransition (T trans, N id) {

        if (map.ContainsKey (trans)) {
            return;
        }

        map.Add (trans, id);
    }
    public void DeleteTransition (T trans) {
        if (map.ContainsKey (trans)) {
            map.Remove (trans);
            return;
        }
    }
    public N GetOutputState (T trans) {
        if (map.ContainsKey (trans)) {
            return map[trans];
        }
        return default(N);
    }
    public virtual void OnBeforeEntering () { }
    public virtual void OnBeforeLeaving () { }

}