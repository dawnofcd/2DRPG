using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

public override void  Enter()
{
    base.Enter();
}

public override void Update()
{
  base.Update();
  if (xInput!=0)
  {
    stateMachine.ChangeState(player.moveState);
    player.SetVelocity(xInput* player.Speed, rb.linearVelocityY); // inherit rb 
  //player.rb.linearVelocity= new Vector2 (xInput, player.rb.linearVelocityY);
  }
  if (Input.GetKey (KeyCode.Space))

  {
     rb.linearVelocity = new Vector2 (rb.linearVelocityX, 12);
     stateMachine.ChangeState(player.jumpState);
  }
}
public override void Exit ()
{
   base.Exit();
}
}
