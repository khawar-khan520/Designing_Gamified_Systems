using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int saveVersion = 1;
    public PlayerProfile profile = new PlayerProfile();
    public ProgressData progress = new ProgressData();
    public RewardData rewards = new RewardData();
    public StoryData story = new StoryData();
}

[System.Serializable]
public class PlayerProfile
{
    public string profileId;
    public string playerName;
    public AvatarData avatar = new AvatarData();
}

[System.Serializable]
public class AvatarData
{
    public string avatarId = "default";
}

[System.Serializable]
public class ProgressData
{
    public int currentDay = 1;
    public int currentChapter = 1;
    public List<string> completedChapterIds = new List<string>();
}

[System.Serializable]
public class RewardData
{
    public int totalPoints = 0;
    public List<string> unlockedRewardIds = new List<string>();
}

[System.Serializable]
public class StoryData
{
    public List<string> unlockedClueIds = new List<string>();
    public List<string> unlockedChapterIds = new List<string>();
}
