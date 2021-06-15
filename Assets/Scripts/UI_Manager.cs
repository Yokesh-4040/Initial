using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using FourtyFourty.UI.Screen;

namespace FourtyFourty.Managers.UI
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager UI_Instance;
        #region Variables

        [Header("System Events")]
        public UnityEvent OnSwitchedScreen = new UnityEvent();

       
        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;

        public Component[] screens = new Component[0];

        public UI_Screen previousScreen;

        public UI_Screen currentScreen;

        public UI_Screen[] startScreen;

        #endregion

        #region Main Methods

        private void Awake()
        {
            UI_Instance = GetComponent<UI_Manager>();
            screens = GetComponentsInChildren<UI_Screen>(true);
            InitializeScreens();
        }

        private void Start()
        {
            if (m_Fader)
            {
                m_Fader.gameObject.SetActive(true);
            }

            FadeIn();
        }

        #endregion

        #region Helper Method
        public void SwitchScreen(UI_Screen n_screen)
        {
            if (!n_screen) return;
            if (currentScreen)
            {
                previousScreen = currentScreen;
                currentScreen.CloseScreen();
            }
            currentScreen = n_screen;
            currentScreen.gameObject.SetActive(true);
            currentScreen.OpenScreen();
        }

        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreen(previousScreen);
            }
        }


        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        public void FadeIn()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
            }
        }
        public void FadeOut()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(1f, m_FadeOutDuration, false);
            }
        }

        private void InitializeScreens()
        {
            foreach (var screen in screens)
            {
                screen.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}

