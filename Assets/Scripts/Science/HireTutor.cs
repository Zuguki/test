﻿using UnityEngine;

namespace DefaultNamespace.Science
{
    public class HireTutor : IStatButton
    {
        public StatType StateType => StatType.Science;

        public string Text => "Заниматься с репетитором";

        private int _money;
        private int _science;

        private const int TutorPrice = 1000;
        
        public void Buffs()
        {
            _money = PlayerPrefs.GetInt("money");
            _science = PlayerPrefs.GetInt("science");

            if (TryGetGoodBuff(out var buffValue))
            {
                _money -= TutorPrice;
                _science += buffValue;
                Debug.Log("Ну, нормально позанимались");
            }
            else
            {
                Debug.Log("Бомжара, иди работай");
            }
            
            UpdatePrefabValue();
        }
        
        private bool TryGetGoodBuff(out int buffValue)
        {
            var isGoodBuff = _money > TutorPrice;
            
            buffValue = isGoodBuff ? Random.Range(200, 250) : 0;
            return isGoodBuff;
        }
        
        private void UpdatePrefabValue()
        {
            PlayerPrefs.SetInt("money", _money);
            PlayerPrefs.SetInt("science", _science);
            PlayerStats.NeedsUpdate = true;
        }
    }
}