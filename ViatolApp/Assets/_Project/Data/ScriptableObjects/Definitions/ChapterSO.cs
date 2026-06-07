using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameDB/Chapter")]
public class ChapterSO : ScriptableObject
{
    public string chapterId;
    public string title;
    public int unlockDay;
    public List<string> clueIds = new List<string>();
}
