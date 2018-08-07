using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Gamestrap
{
    public class MainMenuControl : MonoBehaviour
    {
        private static int visibleVariable = Animator.StringToHash("Visible");
        private static int notifyVariable = Animator.StringToHash("Notify");

        public GameObject settingsPanel, aboutPanel;

        public Toggle soundToggle, musicToggle;

        public Text notificationText;
        private Animator notificationAnimator;
        public void Start()
        {
            //Adds events to the Toggle buttons through code since
            //doing it through the inspector wouldn't will give the value of the button dynamically
            soundToggle.onValueChanged.AddListener(ToggleSound);
            musicToggle.onValueChanged.AddListener(ToggleMusic);

            notificationAnimator = notificationText.GetComponent<Animator>();

            this.PlaySceneField();
        }

        #region Event Methods Called from the UI

        public RawImage imgField;
        public RawImage imgSea;
        public RawImage imgNight;

        private ESceneNames name = ESceneNames.scene_field;

        public void PlayClick()
        {
            GSAppExampleControl.Instance.LoadScene(this.name);
        }

        public void PlaySceneSea()
        {
            this.name = ESceneNames.scene_sea;
            this.imgSea.color = new Color(this.imgSea.color.r, this.imgSea.color.g, this.imgSea.color.b, 255f);
            this.imgField.color = new Color(this.imgField.color.r, this.imgField.color.g, this.imgField.color.b, 0f);
            this.imgNight.color = new Color(this.imgNight.color.r, this.imgNight.color.g, this.imgNight.color.b, 0f);
        }

        public void PlaySceneField()
        {
            this.name = ESceneNames.scene_field;
            this.imgSea.color = new Color(this.imgSea.color.r, this.imgSea.color.g, this.imgSea.color.b, 0f);
            this.imgField.color = new Color(this.imgField.color.r, this.imgField.color.g, this.imgField.color.b, 255f);
            this.imgNight.color = new Color(this.imgNight.color.r, this.imgNight.color.g, this.imgNight.color.b, 0f);
        }

        public void PlaySceneNight()
        {
            this.name = ESceneNames.scene_night;
            this.imgSea.color = new Color(this.imgSea.color.r, this.imgSea.color.g, this.imgSea.color.b, 0f);
            this.imgField.color = new Color(this.imgField.color.r, this.imgField.color.g, this.imgField.color.b, 0f);
            this.imgNight.color = new Color(this.imgNight.color.r, this.imgNight.color.g, this.imgNight.color.b, 255f);
        }

        public void AchievementsClick()
        {
            notificationText.text = "Achievements Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        public void LeaderboardClick()
        {
            notificationText.text = "Leaderboard Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        public void RateClick()
        {
            notificationText.text = "Rate Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        #region Settings Events
        public void ToggleSettingsPanel()
        {
            TogglePanel(settingsPanel.GetComponent<Animator>());
        }

        public void ToggleSound(bool on)
        {
            // Change the sound
        }

        public void ToggleMusic(bool on)
        {
            // Change the music
        }

        #endregion

        #region About Events

        public void FacebookClick()
        {
            Application.OpenURL("https://www.facebook.com/gamestrapui/");
        }

        public void TwitterClick()
        {
            Application.OpenURL("https://twitter.com/EmeralDigEnt");

        }

        public void YoutubeClick()
        {
            Application.OpenURL("https://www.youtube.com/channel/UC8b_9eMveC6W0hl5RJkCvyQ");
        }

        public void WebsiteClick()
        {
            Application.OpenURL("http://www.gamestrap.info");
        }
        #endregion

        public void ToggleAboutPanel()
        {
            TogglePanel(aboutPanel.GetComponent<Animator>());
        }

        private void TogglePanel(Animator panelAnimator)
        {
            panelAnimator.SetBool(visibleVariable, !panelAnimator.GetBool(visibleVariable));
        }
        #endregion
    }
}