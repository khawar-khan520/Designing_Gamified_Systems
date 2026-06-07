using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    public event Action<int> OnDayAdvanced;
    public event Action<int> OnPointsChanged;
    public event Action<string> OnClueUnlocked;
    public event Action<string> OnChapterUnlocked;

    private PlayerData Data => SaveManager.Instance.CurrentData;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AdvanceDay()
    {
        Data.progress.currentDay++;
        SaveManager.Instance.Save();
        OnDayAdvanced?.Invoke(Data.progress.currentDay);
    }

    public void AddPoints(int amount)
    {
        Data.rewards.totalPoints += amount;
        SaveManager.Instance.Save();
        OnPointsChanged?.Invoke(Data.rewards.totalPoints);
    }

    public void UnlockClue(string clueId)
    {
        if (Data.story.unlockedClueIds.Contains(clueId)) return;
        Data.story.unlockedClueIds.Add(clueId);
        SaveManager.Instance.Save();
        OnClueUnlocked?.Invoke(clueId);
    }

    public void UnlockChapter(string chapterId)
    {
        if (Data.progress.completedChapterIds.Contains(chapterId)) return;
        Data.progress.completedChapterIds.Add(chapterId);
        Data.story.unlockedChapterIds.Add(chapterId);
        SaveManager.Instance.Save();
        OnChapterUnlocked?.Invoke(chapterId);
    }
}
