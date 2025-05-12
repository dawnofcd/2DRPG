using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class PlayerState
{

   protected float xInput;
   protected PlayerStateMachine stateMachine;
   protected Player player;
   protected Rigidbody2D rb;

   protected string animBoolName;

   public PlayerState (Player _player , PlayerStateMachine _stateMachine, string _animBoolName )
   {
    this.player =_player;
    this.stateMachine=_stateMachine;
    this.animBoolName=_animBoolName;
   }




public virtual void  Enter()
{
   player.anim.SetBool(animBoolName, true);
   rb= player.rb;
}

public virtual void Update()
{

xInput= Input.GetAxisRaw("Horizontal");
   
}
public virtual void Exit ()
{
  player.anim.SetBool(animBoolName, false);
}
}
