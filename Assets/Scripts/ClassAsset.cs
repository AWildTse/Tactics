using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Ability;

namespace Tactics.Class
{
    [CreateAssetMenu(fileName = "New Class", menuName = "ScriptableObjects/Class")]
    public class ClassAsset : ScriptableObject
    {
        [SerializeField] public string ClassName;
        [SerializeField] public string AbilityText;
        [SerializeField] public AbilityAsset ability;
        [SerializeField] public int Health;
        [SerializeField] public int Mana;
        [SerializeField] public int Strength;
        [SerializeField] public int Magic;
        [SerializeField] public int PhysicalDefense;
        [SerializeField] public int MagicResistance;
        [SerializeField] public int Dexterity;
        [SerializeField] public int CriticalChance;
        [SerializeField] public int Accuracy;
        [SerializeField] public int Evasion;
        [SerializeField] public int Movement;
        [SerializeField] public int Jump;
        [SerializeField] public int SpellcastingSpeed;
    }
}
