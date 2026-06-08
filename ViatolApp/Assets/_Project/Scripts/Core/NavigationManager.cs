using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager Instance { get; private set; }

    [Header("Screens")]
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject bodyMapScreen;
    [SerializeField] GameObject investigationScreen;
    [SerializeField] GameObject caseFileScreen;
    [SerializeField] GameObject avatarScreen;
    [SerializeField] GameObject settingsScreen;

    [Header("Popups")]
    [SerializeField] GameObject rewardPopup;

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        if (startScreen != null)
            ShowScreen(startScreen);
    }

    public void ShowStartScreen()      => ShowScreen(startScreen);
    public void ShowMainMenu()         { Debug.Log("[NAV] ShowMainMenu called"); ShowScreen(mainMenuScreen); }
    public void ShowBodyMap()          => ShowScreen(bodyMapScreen);
    public void ShowInvestigation()    => ShowScreen(investigationScreen);
    public void ShowCaseFile()         => ShowScreen(caseFileScreen);
    public void ShowAvatar()           => ShowScreen(avatarScreen);
    public void ShowSettings()         => ShowScreen(settingsScreen);

    public void ShowRewardPopup()      => rewardPopup.SetActive(true);
    public void HideRewardPopup()      => rewardPopup.SetActive(false);

    void ShowScreen(GameObject screen)
    {
        if (startScreen)         startScreen.SetActive(false);
        if (mainMenuScreen)      mainMenuScreen.SetActive(false);
        if (bodyMapScreen)       bodyMapScreen.SetActive(false);
        if (investigationScreen) investigationScreen.SetActive(false);
        if (caseFileScreen)      caseFileScreen.SetActive(false);
        if (avatarScreen)        avatarScreen.SetActive(false);
        if (settingsScreen)      settingsScreen.SetActive(false);
        if (rewardPopup)         rewardPopup.SetActive(false);

        screen.SetActive(true);
    }
}
