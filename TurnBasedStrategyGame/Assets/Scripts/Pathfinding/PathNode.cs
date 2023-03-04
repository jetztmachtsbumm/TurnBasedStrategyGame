using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{

    private GridPosition gridPosition;
    private int gCost;
    private int hCost;
    private int fCost;
    private PathNode previousNode;

    public PathNode(GridPosition gridPosition)
    {
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        return gridPosition.ToString();
    }

    public void SetGCost(int gCost)
    {
        this.gCost = gCost;
    }

    public void SetHCost(int hCost)
    {
        this.hCost = hCost;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetPreviousNode(PathNode previousNode) 
    { 
        this.previousNode = previousNode; 
    }

    public void ResetPreviousNode()
    {
        previousNode = null;
    }

    public int GetFCost()
    {
        return fCost;
    }

    public int GetGCost()
    {
        return gCost;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public PathNode GetPreviousPathNode()
    {
        return previousNode;
    }

}
