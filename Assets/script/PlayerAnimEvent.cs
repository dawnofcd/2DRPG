using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    void Start()
    {
      player= GetComponentInParent<Player>();
    }

    void AnimationTrigger()
    {
     // player.AttackOver();
    }
}
