/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
using System;
using System.Collections.Generic;

public class Maze
{
    // Dictionary where each key is a position (x, y)
    // and the value is a bool array: [left, right, up, down]
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;

    // Current position in the maze
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[0]) // 0 = left
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1; // move left on the X axis
    }

    public void MoveRight()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[1]) // 1 = right
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1; // move right on the X axis
    }

    public void MoveUp()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[2]) // 2 = up
            throw new InvalidOperationException("Can't go that way!");
        _currY -= 1; // move up on the Y axis
    }

    public void MoveDown()
    {
        var directions = _mazeMap[(_currX, _currY)];
        if (!directions[3]) // 3 = down
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1; // move down on the Y axis
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
