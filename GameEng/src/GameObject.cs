using GameEng.lib.Engine.BasicClasses;
using GameEng.lib.BasicMath;

public abstract class GameObject : Entity
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
        Position += direction;
    }

    public abstract void PlanarRotation(int axis1, int axis2, float angle);
     
    public abstract void Rotation_3D(float angleX, float angleY, float angleZ);

    public void SetPosition(Point position)
    {
        Position = position;
    }

    public void SetDirection(Vector direction)
    {
        Direction = direction;
    }

}