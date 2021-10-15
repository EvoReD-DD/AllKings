using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public delegate void EventExperience();
public class LvlSystem : MonoBehaviour
{
    Dictionary<int, int> lvlExp = new Dictionary<int, int>(42);
    private int dictSize = 42;
    private int[] expToLevel = new int[42];
    private float expFirstLvl = 1200f;
    private float coefficient = 0.8f;
    private int resultCalcNextLvl;
    private static int expRequired;
    private static int lvlStep = 1;
    private void Awake()
    {
        resultCalcNextLvl = 0;
        DictionaryAdd();
    }
    #region DictionaryFilling
    private void DictionaryAdd()
    {
        for (int i = 0; i < dictSize; i++)
        {
            lvlExp.Add(i, CalcNextLvlForDict(i));
        }
    }
    private int CalcNextLvlForDict(int i)
    {
        expToLevel[i] = resultCalcNextLvl + Convert.ToInt32((expFirstLvl * coefficient));
        resultCalcNextLvl = expToLevel[i];
        Debug.Log(resultCalcNextLvl);
        return resultCalcNextLvl;
    }
    #endregion
    public static void LvlIncrease(int value)
    {
        SaveData.exp += value;
        if (SaveData.exp < 0)
        {
            SaveData.exp = 0;
        }
        if (SaveData.exp >= expRequired)
        {
            int j = SaveData.exp - expRequired;
            SaveData.exp = (j > 0) ? j : 0;
            SaveData.lvl += lvlStep;
            Debug.Log("exp" + SaveData.exp);
            SaveAndLoadData.Save();
        }
    }
}
