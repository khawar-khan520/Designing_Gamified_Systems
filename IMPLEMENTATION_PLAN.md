# Viatolea — Phase 2 Implementation Plan

## Current State (Completed in Phase 1)

- Unity 6 LTS 2D project set up on GitHub (`frontend` branch)
- Data layer: SaveManager, ProgressManager, all data models (PlayerData, PlayerProfile, ProgressData, RewardData, StoryData, AvatarData)
- Navigation system: 7 screens wired, Start Screen working, Main Menu working
- ScriptableObject schemas ready: Chapter, Clue, Reward, DailyMessage
- Stefan's graphics integrated in `Assets/_Project/Art/`
- GitHub branches: `main`, `backend`, `frontend`

---

## Branch Strategy

```
main        ← stable releases only
develop     ← integration branch (merge here when a feature is complete)
backend     ← Team A's branch (data, save system, managers)
frontend    ← Team B's branch (UI, screens, navigation)
```

**Rules:**
- Work on your own branch
- Merge into `develop` when a feature is complete and tested
- Never push broken code to `develop`
- `main` is only updated for stable, presentable versions

---

## Team Member A — Backend & Data (Priority Order)

| Priority | Task | Description | Deliverable |
|---|---|---|---|
| High | Connect data to screens | Wire ProgressManager events to display points, day, clues on each screen | Live data visible in UI |
| High | DailyMessage loader | Script that reads DailyMessageSO for current day and returns correct message/question | `DailyMessageService.cs` |
| High | Reward trigger | Auto-show reward popup when points reach a threshold via `NavigationManager.ShowRewardPopup()` | Auto reward popup |
| Medium | Chapter unlock logic | When day advances, check if a new chapter unlocks and fire `OnChapterUnlocked` event | Auto chapter progression |
| Medium | Progress bar data | Expose `float GetProgressPercent()` in ProgressManager (0.0 to 1.0) for UI to consume | Progress data for UI |
| Medium | Avatar save | Save selected avatar (male/female) to PlayerData.profile.avatar and reload on start | Persistent avatar choice |
| Low | Settings reset | Wire Reset button in SettingsScreen to `SaveManager.ResetSave()` | Working settings screen |

---

## Team Member B — UI & Frontend (Priority Order)

| Priority | Task | Description | Deliverable |
|---|---|---|---|
| High | Back buttons | Add Back button to every screen wired to `NavigationManager.ShowMainMenu()` | Full navigation |
| High | BodyMap screen | Add clickable body regions as buttons over `pin_backdrop.png` | Working body map |
| High | Investigation screen | Add story text area (TMP), clue image slot, clue description text | Investigation UI |
| High | Case File screen | Add scrollable list showing unlocked clues from StoryData | Case file display |
| High | Reward Popup | Design popup: reward icon, points earned text, close button | Reward popup UI |
| Medium | Avatar screen | Add female/male player sprites (`f-player.png`, `m-player.png`) as selectable buttons | Avatar selection UI |
| Medium | Progress bar | Add Unity Slider component driven by `ProgressManager.GetProgressPercent()` | Visual progress bar |
| Medium | Settings screen | Add reset button and basic layout | Settings screen |
| Low | UI polish | Consistent colors, fonts, button styles across all screens | Visual consistency |

---

## Shared Tasks (Both Members)

| Priority | Task | Description |
|---|---|---|
| High | Daily message display | Team B adds text area to Investigation screen, Team A feeds it from DailyMessageSO |
| High | Data entry | Team B fills in DailyMessageSO assets with the daily messages/questions table (no coding — done in Unity Inspector via Create > GameDB > DailyMessage) |
| Medium | Body map wiring | Team B's body region buttons call `ProgressManager.UnlockClue(clueId)` |
| Medium | Avatar wiring | Team B's avatar selection buttons call Team A's avatar save method |

---

## How to Add Daily Messages (Team B — No Coding Required)

1. Open Unity Editor
2. In Project panel, navigate to `Assets/_Project/Data/ScriptableObjects/`
3. Right-click → **Create** → **GameDB** → **DailyMessage**
4. Fill in the Inspector fields:
   - `Day` — which day this message appears
   - `Message` — the daily text
   - `Question` — the question for the user
   - `Answer Options` — the answer choices
   - `Correct Answer Index` — index of the correct answer (0 = first option)
5. Repeat for each day

---

## How to Use Graphics (Team B)

All graphics are in `Assets/_Project/Art/`:
- `start-screen.png` — Start Screen background (already in use)
- `pin_backdrop.png` — use as background Image on BodyMapScreen
- `f-player.png` — female avatar option on AvatarScreen
- `m-player.png` — male avatar option on AvatarScreen

To use: select the UI Image component → Source Image → pick the file.

---

## Next Session Priority Order

1. Add Back buttons to all screens (Team B — 20 min)
2. Add content to Investigation screen — text area + clue display (both)
3. Wire daily messages to Investigation screen (Team A)
4. Reward popup design + auto-trigger (both)
5. Body map with `pin_backdrop.png` (Team B)
6. Avatar selection wired to save system (both)

---

## Expo Deadline — June 26, 4:00 PM (Final Checklist)

- [ ] All 7 screens have real content
- [ ] Daily messages display correctly per day
- [ ] Points and progress bar visible on relevant screens
- [ ] Reward popup triggers automatically on milestone
- [ ] Avatar selection saves and loads correctly
- [ ] Body map is clickable and triggers clue unlocks
- [ ] Case file shows collected clues
- [ ] User evaluation / feedback collection prepared
- [ ] Poster ready (done)
