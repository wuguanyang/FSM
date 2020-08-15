/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using UnityEngine;

public class PlayerIdle : FSMState<Player.PlayerST, Player.PlayerSN> {

    public PlayerIdle(Player.PlayerSN name) : base(name) {

    }
    public override void OnBeforeEntering () {
        Debug.Log ("Idle");
    }
}