/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using UnityEngine;

public class PlayerRun : FSMState<Player.PlayerST, Player.PlayerSN> {

    public PlayerRun(Player.PlayerSN name) : base(name){

    }
    public override void OnBeforeEntering () {
        Debug.Log ("Run");
    }
}