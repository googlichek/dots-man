using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject TitleUI;
        public GameObject GameUI;
        public GameObject WinUI;
        public GameObject LoseUI;

        [Space]

        public TextMeshProUGUI PelletsText;
        public TextMeshProUGUI ScoreText;

        public int Score;

        void Awake()
        {
            Instance = this;
        }

        void Reset()
        {
            SwitchUI(TitleUI);
            Score = 0;
        }

        public void InGame()
        {
            SwitchUI(GameUI);
        }
        
        public void Win()
        {
            SwitchUI(WinUI);
        }
        
        public void Lose()
        {
            SwitchUI(LoseUI);
        }

        public void SwitchUI(GameObject newUI)
        {
            TitleUI.SetActive(false);
            GameUI.SetActive(false);
            WinUI.SetActive(false);
            LoseUI.SetActive(false);

            newUI.SetActive(true);
        }

        public void AddPoints(int points)
        {
            Score += points;
            ScoreText.text = $"Score: {Score}";
        }

        public void UpdatePelletCount(int value)
        {
            PelletsText.text = $"Pellets: {value}";
        }
    }
}
