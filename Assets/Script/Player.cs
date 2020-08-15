/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  测试状态机，一共有2个状态，IDle，Run，如果按下A就跳转到RUn，按下B就跳转B

*/

using UnityEngine;

public class Player : MonoBehaviour {
    public enum PlayerSN {
        Empty,//必须要实现空
        Idle,
        Run,
    }
    public enum PlayerST {
        InputA,
        InputB,
    }

    [SerializeField] FSMSystem<PlayerST, PlayerSN> fsm;
    private void Awake () {
        fsm = new FSMSystem<PlayerST, PlayerSN> ();

        var idle = new PlayerIdle(PlayerSN.Idle);
        idle.AddTransition (PlayerST.InputA, PlayerSN.Run);

        var run = new PlayerRun (PlayerSN.Run);
        run.AddTransition (PlayerST.InputB, PlayerSN.Idle);

        fsm.AddState (idle);
        fsm.AddState (run);

        fsm.SetCurrentState (PlayerSN.Idle);

        Debug.Log (fsm.states.Count);
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.A)) {
            fsm.PerformTransition (PlayerST.InputA);
        }
        if (Input.GetKeyDown (KeyCode.B)) {
            fsm.PerformTransition (PlayerST.InputB);
        }
    }
}