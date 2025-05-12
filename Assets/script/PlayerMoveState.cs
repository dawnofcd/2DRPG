using UnityEngine;

public class PlayerMoveState: PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public override void  Enter()
{
   base.Enter();
}

public override void Update()
{
  base.Update();    
  if (xInput==0)
    stateMachine.ChangeState(player.idleState);
  
}
public override void Exit ()
{
   base.Exit();
  
}
}
