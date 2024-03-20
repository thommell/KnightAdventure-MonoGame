using System;
using System.Net;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;
public class Button : GameObject
{
    //Levelstate?
    #region Button

    public ButtonStateMachine buttonStateMachine;
    public IButtonState buttonState;
    public Color _color = Color.White;

    #endregion
    
    #region Mouse

    protected MouseState mouseState;
    protected ButtonState previousMouseClick = Mouse.GetState().LeftButton;
    protected Point mousePosition;

    #endregion
    
    public Button(Vector2 pPosition, Texture2D pTexture) : base(pPosition, pTexture)
    {
        
    }

    public override void LoadObject()
    {
        buttonStateMachine = new ButtonStateMachine(this);
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
    protected virtual void OnClick() {}
   
}