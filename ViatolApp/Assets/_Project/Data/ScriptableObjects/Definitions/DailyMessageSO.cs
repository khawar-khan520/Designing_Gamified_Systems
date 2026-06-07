using UnityEngine;

[CreateAssetMenu(menuName = "GameDB/DailyMessage")]
public class DailyMessageSO : ScriptableObject
{
    public int day;
    [TextArea] public string message;
    [TextArea] public string question;
    public string[] answerOptions;
    public int correctAnswerIndex;
}
