using UnityEngine;

[CreateAssetMenu(menuName = "GameDB/Clue")]
public class ClueSO : ScriptableObject
{
    public string clueId;
    [TextArea] public string description;
}
