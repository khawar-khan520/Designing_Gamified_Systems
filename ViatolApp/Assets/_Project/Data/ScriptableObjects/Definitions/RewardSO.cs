using UnityEngine;

[CreateAssetMenu(menuName = "GameDB/Reward")]
public class RewardSO : ScriptableObject
{
    public string rewardId;
    public string displayName;
    public int pointCost;
}
