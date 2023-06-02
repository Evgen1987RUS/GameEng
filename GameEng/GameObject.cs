using Engine;
using GameEng;
using GameEngNamespace;

public class GameObject : Entity
{

    Point _position;
    Vector _direction;

    public Point Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public Vector Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    
    public GameObject(CoordinateSystem coordinateSystem, Point point, Vector direction) : base(coordinateSystem) 
    {
        _position = point;
        _direction = direction;
        SetProperty("position", _position);
        SetProperty("direction", _direction);
    }

    public void Move(Vector direction)
    {
        Position = Position + direction;
    }

//TODO : PlanarRotation && 3D_Rotation
    
    public void SetPosition(Point position)
    {
        Position = position;
    }

    public void SetDirection(Vector direction)
    {
        Direction = direction;
    }

}