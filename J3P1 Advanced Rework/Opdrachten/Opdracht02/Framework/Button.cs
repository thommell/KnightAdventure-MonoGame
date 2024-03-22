using System;
using System.Net;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;
public abstract class Button : GameObject
{
    //Levelstate?
    #region Button

    public ButtonStateMachine buttonStateMachine;
    public IButtonState buttonState;
    public Color _color = Color.White;
    private Vector2 _padding;

    protected Vector2 Padding
    {
        get => _padding;
        set => _padding = value;
    }
    //Text
    protected SpriteFont _font;
    protected string _buttonText;
    protected Vector2 _textDimensions;

    #endregion
    #region Mouse

    protected MouseState mouseState;
    protected ButtonState previousMouseClick = Mouse.GetState().LeftButton;
    protected Point mousePosition;

    #endregion
    protected Button(Vector2 pPosition, Texture2D pTexture, string pButtonText) : base(pPosition, pTexture)
    {
        _buttonText = pButtonText;
        _textDimensions.X = Texture.Width / 2f - SceneManager.Instance.Font.MeasureString(_buttonText).X / 2;
        _textDimensions.Y = Texture.Height / 2f - SceneManager.Instance.Font.MeasureString(_buttonText).Y / 2;
    }
    public override void LoadObject()
    {
        buttonStateMachine = new ButtonStateMachine(this);
        
        _padding.X = Texture.Width * 0.5f;
        _padding.Y = Texture.Height * 0.5f;
        
        buttonState = buttonStateMachine.NormalState;
        base.LoadObject();
    }

    public override void UpdateObject(GameTime pGameTime)
    {
        mouseState = Mouse.GetState();
        mousePosition = new Point(mouseState.X, mouseState.Y);
        
        CheckStates();
        buttonStateMachine.UpdateState();
        Console.WriteLine(mouseState);
        Console.WriteLine(buttonState);
        previousMouseClick = mouseState.LeftButton;
        base.UpdateObject(pGameTime);
    }

    public override void DrawObject(SpriteBatch pSpriteBatch)
    {
        base.DrawObject(pSpriteBatch);
        if (_buttonText != null)
            pSpriteBatch.DrawString(SceneManager.Instance.Font, _buttonText, new Vector2(Position.X + _textDimensions.X, Position.Y + _textDimensions.Y),
                Color.White, Rotation, Origin, Vector2.One,SpriteEffects.None, Layer
            );
    }
    private void CheckStates()
    {
        var bsm = buttonStateMachine;
        if(!Rectangle.Contains(mousePosition))
            bsm.ChangeState(bsm.NormalState);
        if (Rectangle.Contains(mousePosition))
            bsm._currentState = bsm.HoveredState;
        if (bsm._currentState == bsm.HoveredState)
            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseClick == ButtonState.Released)
                bsm.ChangeState(bsm.PressedState);
        if (bsm._currentState == bsm.PressedState)
            OnClick();
    }
    protected abstract void OnClick();
}