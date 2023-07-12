using System.Collections.Generic;
using Hypernex.Player;
using HypernexSharp.SocketObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Hypernex.UIActions
{
    public class TopBarManager : MonoBehaviour
    {
        public List<GameObject> LoggedInObjects;
        public TMP_Text WelcomeText;
        public Button PowerButton;
        public GameObject ExitPage;
        public TMP_Text ButtonText;

        public readonly List<string> greetings = new()
            {"Howdy", "Hello", "Greetings", "Welcome", "G'day", "Hey", "Howdy-do", "Shalom"};

        private bool isLoggingOut;

        public void Exit() => Application.Quit();

        public void SignOut()
        {
            if (isLoggingOut || APIPlayer.APIUser == null) return;
            isLoggingOut = true;
            APIPlayer.Logout(r => isLoggingOut = false);
        }

        public void Cancel() => ExitPage.SetActive(false);

        public void PointerEnterExit() => ButtonText.text = ":(";
        public void PointerExitExit() => ButtonText.text = "Exit";
    
        void Start()
        {
            APIPlayer.OnUser += user =>
            {
                int i = new System.Random().Next(greetings.Count);
                WelcomeText.text = greetings[i] + ", " + user.Username;
                LoggedInObjects.ForEach(x => x.SetActive(true));
            };
            APIPlayer.OnLogout += () => LoggedInObjects.ForEach(x => x.SetActive(false));
            PowerButton.onClick.AddListener(() => ExitPage.SetActive(true));
        }
    }
}
