using TMPro;
using UnityEngine;

public class DemoUI : MonoBehaviour
{
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text dayText;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text cluesText;
    [SerializeField] TMP_Text chaptersText;

    void Start()
    {
        ProgressManager.Instance.OnDayAdvanced    += day => dayText.text    = "Day: " + day;
        ProgressManager.Instance.OnPointsChanged  += pts => pointsText.text = "Points: " + pts;
        ProgressManager.Instance.OnClueUnlocked   += _   => RefreshClues();
        ProgressManager.Instance.OnChapterUnlocked += _  => RefreshChapters();

        RefreshAll();
    }

    void RefreshAll()
    {
        var data = SaveManager.Instance.CurrentData;
        playerNameText.text = "Player: " + data.profile.playerName;
        dayText.text        = "Day: "    + data.progress.currentDay;
        pointsText.text     = "Points: " + data.rewards.totalPoints;
        RefreshClues();
        RefreshChapters();
    }

    void RefreshClues()
    {
        int count = SaveManager.Instance.CurrentData.story.unlockedClueIds.Count;
        cluesText.text = "Clues Unlocked: " + count;
    }

    void RefreshChapters()
    {
        int count = SaveManager.Instance.CurrentData.progress.completedChapterIds.Count;
        chaptersText.text = "Chapters Done: " + count;
    }

    // Called by UI Buttons (wire these in the Inspector)
    public void OnAdvanceDayButton()   => ProgressManager.Instance.AdvanceDay();
    public void OnAddPointsButton()    => ProgressManager.Instance.AddPoints(10);
    public void OnUnlockClueButton()   => ProgressManager.Instance.UnlockClue("clue_" + System.DateTime.Now.Ticks);
    public void OnUnlockChapterButton()=> ProgressManager.Instance.UnlockChapter("chapter_" + SaveManager.Instance.CurrentData.progress.completedChapterIds.Count);
    public void OnResetButton()        { SaveManager.Instance.ResetSave(); RefreshAll(); }
}
