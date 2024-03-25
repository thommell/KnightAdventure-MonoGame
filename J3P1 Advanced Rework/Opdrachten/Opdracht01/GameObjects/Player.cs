using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.PlayerStateMachine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using J3P1_Advanced_Rework.Opdrachten.Opdracht01.PlayerStateMachine;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht01.GameObjects;

public class Player : GameObject
{

    #region Keyboard

    private Keys _upKey = Keys.W;
    private Keys _leftKey = Keys.A;
    private Keys _rightKey = Keys.D;
    private Keys _downKey = Keys.S;

    #endregion
    #region Variables
    
    private float _speed;
    private PlayerStateMachine.StateMachinePlayer _playerStateManager;
    private bool _hasShield;
    private bool _hasWeapon;
    
    
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

    public Player(Vector2 pPosition, Texture2D pTexture, float pSpeed) : base(pPosition, pTexture) => Speed = pSpeed;
    public override void LoadObject()
    {
        base.LoadObject();
        _playerStateManager = new StateMachinePlayer(this);
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        ClampPlayer();
        Movement(pGameTime);
        CheckCollision();
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
    private void CheckCollision()
    {
        List<GameObject> objects = SceneManager.CurrentScene.GameObjects;
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            // continue back through the loop to check if its not colliding with itself
            if (objects[i] == this) continue;
            // continue back through the loop if there is no collision
            if (!objects[i].Rectangle.Intersects(Rectangle)) continue;
            // continue back through the loop if object isn't an interactable
            if (objects[i] is not Interactable) continue;
            Console.WriteLine("Interactable Collision");
            Interactable obj = (Interactable)objects[i];
            obj.Interact(this);
        }   
    }
    private void ClampPlayer() => Position = new Vector2(Math.Clamp(Position.X, 0, SceneManager.Viewport.Width - Texture.Width), Math.Clamp(Position.Y, 0, SceneManager.Viewport.Height - Texture.Height));
    private void Movement(GameTime pGameTime)
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
}