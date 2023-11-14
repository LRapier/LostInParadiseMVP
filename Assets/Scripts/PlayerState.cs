public class PlayerState
{
    public virtual PlayerState HandleInput(Player player) { return null; }
    public virtual void Update(Player player) { }
    public virtual void Enter(Player player) { }
    public virtual void Exit(Player player) { }
};
