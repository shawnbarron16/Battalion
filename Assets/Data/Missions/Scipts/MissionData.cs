using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpecialMissionEffect
{
    None,
    BoostBaseSecurity
}
public enum MissionDifficulty
{
    Basic,
    Tactical,
    Extreme
}

[CreateAssetMenu(fileName = "New Mission Data", menuName = "Missions/Mission Data")]
public class MissionType : ScriptableObject
{
    [Header("Mission Info")]
    public string missionName;
    [TextArea] public string missionDescription;
    public MissionDifficulty difficulty;
    public SpecialMissionEffect specialEffect = SpecialMissionEffect.None;


    [Header("Mission Access")]
    [Tooltip("Minimum player rank required to unlock this mission")]
    public string requiredRank;


    [Header("Base Success Chance")]
    [Range(0f, 100f)]
    public float baseSuccessChance;


    [Header("Mission Rewards")]
    public List<MissionReward> rewards;
}
