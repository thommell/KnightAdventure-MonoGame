using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.ButtonStateMachine;

public class ButtonStateMachine
{
    #region ButtonStates

    private Button _currentButton;
    private PressedState _pressedState;
    private HoveredState _hoveredState;
    private NormalState _normalState;
    public IButtonState _currentState;


    #endregion
    #region Properties

    public NormalState NormalState
    {
        get => _normalState;
        set => _normalState = value;
    }

    public HoveredState HoveredState
    {
        get => _hoveredState;
        set => _hoveredState = value;
    }
    
    public PressedState PressedState
    {
        get => _pressedState;
        set => _pressedState = value;
    }

    #endregion
    public ButtonStateMachine(Button pButton)
    {
        _currentButton = pButton;
        Awake();
    }
    private void Awake()
    {
        PressedState = new PressedState(_currentButton, Color.Blue);
        NormalState = new NormalState(_currentButton, Color.White);
        HoveredState = new HoveredState(_currentButton, Color.Red);
        ChangeState(NormalState);
    }
    public void ChangeState(IButtonState state)
    {
        _currentState = state;
    }
    public void UpdateState() => _currentState.UpdateState();
}