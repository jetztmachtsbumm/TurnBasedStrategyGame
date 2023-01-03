using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{

    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive) return;


        float spinAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAmount, 0);

        totalSpinAmount += spinAmount;
        if(totalSpinAmount >= 360f)
        {
            isActive = false;
            totalSpinAmount = 0f;
            onActionComplete();
        }
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        return new List<GridPosition>
        {
            unit.GetGridPosition()
        };
    }

    public override int GetActionPointsCost()
    {
        return 2;
    }

}
