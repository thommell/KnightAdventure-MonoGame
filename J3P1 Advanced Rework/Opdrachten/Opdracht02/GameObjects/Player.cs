using System;
using System.Collections.Generic;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;

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
        set
        {
            _hasWeapon = value;
            SwitchState(); 
        } 
    }
    public bool HasShield
    {
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
    public override void UpdateObject(GameTime pGameTime)
    {
        ClampPlayer();
        base.UpdateObject(pGameTime);
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
    private void ClampPlayer() => 
        Position = new Vector2(Math.Clamp(Position.X, Origin.X, SceneManager.Instance.Viewport.Width - Texture.Width),
            Math.Clamp(Position.Y, Origin.Y, SceneManager.Instance.Viewport.Height - Texture.Height));
    protected override void Movement(GameTime pGameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        if (keyboard.IsKeyDown(_upKey))
            direction.Y--;
        if (keyboard.IsKeyDown(_downKey))
            direction.Y++;
        if (keyboard.IsKeyDown(_rightKey))
            direction.X++;
        if (keyboard.IsKeyDown(_leftKey))
            direction.X--;
        if (direction == Vector2.Zero) return;
        direction.Normalize();
        Position += direction * Speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
    }
    public override void Die() => SceneManager.Instance.CurrentScene.RemoveObject(this);
    private bool IsAttackState()
    {
        var psm = _playerStateManager;
        return psm.CurrentState == psm.PlayerWeaponShield;
    }
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
}