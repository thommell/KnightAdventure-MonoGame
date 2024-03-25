#region Library

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion
namespace J3P1_Advanced_Rework.Opdrachten.Opdracht02.Framework;
public class GameObject
{
    #region Variables
    
    private Vector2 _position;
    private Vector2 _origin;
    private Texture2D _texture;
    private Rectangle _rectangle;
    private Vector2 _scale;
    private Color _color;
    private float _rotation;
    private float _layer;
    
    #endregion
    #region Properties

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }
    public Vector2 Origin
    { 
        get => _origin;
        set => _origin = value;
    }
    public Texture2D Texture
    {
        get => _texture;
        set => _texture = value;
    }

    public Vector2 Scale
    {
        get => _scale;
        set => _scale = value;
    }
    public Rectangle Rectangle
    {
        get => _rectangle;
        set => _rectangle = value;
    }
    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }
    public float Layer
    {
        get
        {
            if (_layer == 0)
                _layer = 1f;
            return _layer;
        }
        set => _layer = value;
    }
    public Color Color
    {
        get => _color;
        set => _color = value;
    }
    #endregion
    protected GameObject(Vector2 pPosition, Texture2D pTexture)
    {
        Position = pPosition;
        Texture = pTexture;
        Color = Color.White;
        Scale = new Vector2(1f, 1f);
        Origin = GetOrigin();
    }
    public virtual void LoadObject() => Rectangle = GetRectangle();
    public virtual void UpdateObject(GameTime pGameTime) => Rectangle = GetRectangle();
    private Rectangle GetRectangle()
    {
        return new Rectangle((int)_position.X - (int)Origin.X,(int)_position.Y - (int)Origin.Y, Texture.Width, Texture.Height);
    }
    private Vector2 GetOrigin()
    {
        return new Vector2(Texture.Width * 0.5f, Texture.Height * 0.5f);
    }
    public virtual void DrawObject(SpriteBatch pSpriteBatch) => 
        pSpriteBatch.Draw(Texture, _position, null, Color, MathHelper.ToRadians(Rotation), Origin, Scale, SpriteEffects.None, Layer);
}