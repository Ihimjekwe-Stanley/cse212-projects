
using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represent locations in the maze.
/// Each boolean indicates whether movement in that direction is valid.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check whether you can move left. If you cannot move,
    /// throw an InvalidOperationException.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) || !directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Check whether you can move right. If you cannot move,
    /// throw an InvalidOperationException.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) || !directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Check whether you can move up. If you cannot move,
    /// throw an InvalidOperationException.
    /// </summary>
    public void MoveUp()
{
    if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) || !directions[2])
    {
        throw new InvalidOperationException("Can't go that way!");
    }

    _currY--;
}
    /// <summary>
    /// Check whether you can move down. If you cannot move,
    /// throw an InvalidOperationException.
    /// </summary>
    public void MoveDown()
{
    if (!_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) || !directions[3])
    {
        throw new InvalidOperationException("Can't go that way!");
    }

    _currY++;
}
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
