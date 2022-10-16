using UnityEngine;

[CreateAssetMenu(fileName = "1")]
public class WindowData : ScriptableObject
{
    public Line[] lines;

    public Polygon polygon;
}
[System.Serializable]
public class Line
{
    public Color color;
    public Vector2 start;
    public Vector2 end;
}
[System.Serializable]
public class Polygon
{
    public Vector2[] points = new Vector2[0];
    public Color color;
}