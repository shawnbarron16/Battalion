using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RewardAmountType
{
    Fixed,
    Range
}

[System.Serializable]
public class MissionReward
{
    public ResourceType resourceType;
    public RewardAmountType amountType;

    //Used if amountType == Fixed
    public int amount;

    //Used if amountType == Range
    public int minAmount;
    public int maxAmount;

    //Get the actual reward amount based on type
    public int GetRewardAmount()
    {
        return amountType switch
        {
            RewardAmountType.Fixed => amount,
            RewardAmountType.Range => Random.Range(minAmount, maxAmount + 1),
            _=> 0
        };
    }
}
