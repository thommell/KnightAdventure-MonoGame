using System;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht03.StateMachines.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht03.GameObjects;

public class Player : Humanoid
{

    #region Keyboard

    private Keys _upKey = Keys.W;
    private Keys _leftKey = Keys.A;
    private Keys _rightKey = Keys.D;
    private Keys _downKey = Keys.S;

    #endregion
    #region Variables
    
    private float _speed;
    
    private StateMachinePlayer _playerStateManager;
    
    private bool _hasShield;
    private bool _hasWeapon;

    private readonly Vector2 _originalPosition;
    
    #endregion
    #region Properties
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }
    public bool HasWeapon
    {
        get => _hasWeapon;
        set
        {
            _hasWeapon = value;
            SwitchState(); 
        } 
    }
    public bool HasShield
    {
        get => _hasShield;
        set
        {
            _hasShield = value;
            SwitchState();
        }
    }

    #endregion

    public Player(Vector2 pPosition, Texture2D pTexture, float pSpeed, int pHealth, int pStrength) : base(pPosition, pTexture, pHealth, pStrength)
    {
        Speed = pSpeed;
        _originalPosition = pPosition;
    }
    public override void LoadObject()
    {
        base.LoadObject();
        _playerStateManager = new StateMachinePlayer(this);
    }
    private void SwitchState()
    {
        var sm = _playerStateManager;
        if (_hasShield)
            sm.ChangeState(sm.PlayerShield);
        if (_hasWeapon)
            sm.ChangeState(sm.PlayerWeapon);
        if (_hasShield && _hasWeapon)
            sm.ChangeState(sm.PlayerWeaponShield);
    }
    protected override void OnCollision(GameObject collision)
    {
        Console.WriteLine(collision + " has collided with the player!");
        if (collision is not Enemy && collision is not Interactable) return;
        switch (collision)
        {
            case Enemy enemy:
                EnemyCollision(enemy);
                break;
            case Interactable interactable:
                InteractableCollision(interactable);
                break;
        }
    }
    protected override void Movement(GameTime pGameTime)
    {
        KeyboardState state = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X += state.IsKeyDown(_rightKey) ? 1 : 0;
        direction.X -= state.IsKeyDown(_leftKey) ? 1 : 0;
        direction.Y += state.IsKeyDown(_downKey) ? 1 : 0;
        direction.Y -= state.IsKeyDown(_upKey) ? 1 : 0;
        if (direction == Vector2.Zero) return;
        direction.Normalize();
        Position += direction * Speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        Position = ClampPlayer();
    }
    public override void Die() => SceneManager.Instance.CurrentScene.RemoveObject(this);
    public override void TakeDamage(int pDamage)
    {
        base.TakeDamage(pDamage);
        Position = _originalPosition;
    }
    #region Collisions
    private void EnemyCollision(Enemy enemy)
    {
        var psm = _playerStateManager;
        switch (psm.CurrentState)
        {
            case PlayerWeaponShield:
                enemy.Die();
                break;
            case PlayerWeapon:
                enemy.Attack(this);
                enemy.TakeDamage(Strength);
                break;
            default:
                TakeDamage(5);
                break;
        }
    }
    private void InteractableCollision(Interactable interactable) => interactable.Interact(this);
    #endregion
    private Vector2 ClampPlayer()
    {
        return new Vector2(Math.Clamp(Position.X, Origin.X, SceneManager.Instance.Viewport.Width - Texture.Width),
            Math.Clamp(Position.Y, Origin.Y, SceneManager.Instance.Viewport.Height - Texture.Height));
    }
}