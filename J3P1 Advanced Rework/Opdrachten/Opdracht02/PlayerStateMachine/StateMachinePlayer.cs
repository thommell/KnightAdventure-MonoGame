using J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
using J3P1_Advanced_Rework.Opdrachten.Opdracht02.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.PlayerStateMachine;
public class StateMachinePlayer
{
    private readonly Player _player;
    #region Variables

    #region PlayerStates

    private PlayerNormal _normalState;
    private PlayerShield _shieldState;
    private PlayerWeapon _weaponState;
    private PlayerWeaponShield _weaponShieldState;

    #endregion
    #region PlayerTextures

    //private Texture2D _playerNormalTex = SceneManager.Manager.Load<Texture2D>("Knight");
    private Texture2D _playerShieldTex = SceneManager.Manager.Load<Texture2D>("KnightShield");
    private Texture2D _playerWeaponTex = SceneManager.Manager.Load<Texture2D>("KnightWeapon");
    private Texture2D _playerWeaponShieldTex = SceneManager.Manager.Load<Texture2D>("KnightWeaponShield");

    #endregion

    #endregion
    #region Properties

    public PlayerNormal PlayerNormal => _normalState;
    public PlayerShield PlayerShield => _shieldState;
    public PlayerWeapon PlayerWeapon => _weaponState;
    public PlayerWeaponShield PlayerWeaponShield => _weaponShieldState;

    #endregion
    internal IPlayerState CurrentState;
    public StateMachinePlayer(Player pPlayer)
    {
        _player = pPlayer;
        Awake();
    }
    private void Awake()
    {
        _normalState = new PlayerNormal(_player, _player.Texture);
        _shieldState = new PlayerShield(_player, _playerShieldTex);
        _weaponState = new PlayerWeapon(_player, _playerWeaponTex);
        _weaponShieldState = new PlayerWeaponShield(_player, _playerWeaponShieldTex);
        ChangeState(_normalState);
    }
    public void ChangeState(IPlayerState state)
    {
        CurrentState = state; 
        state.OnStateEnter();
    }
  
}