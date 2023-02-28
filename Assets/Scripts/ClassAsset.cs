using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Ability;
using Tactics.Skills;

namespace Tactics.Class
{
    [CreateAssetMenu(fileName = "New Class", menuName = "ScriptableObjects/Class")]
    public class ClassAsset : ScriptableObject
    {
        #region Private Variables
        [Tooltip("This class' name.")]
        [SerializeField] private string _className;

        [Tooltip("This class' ability.")]
        [SerializeField] private AbilityAsset _ability;

        [Tooltip("This class' list of skills.")]
        [SerializeField] private List<SkillAsset> _listOfClassSkills;

        [Tooltip("This class' health modifier.")]
        [SerializeField] private int _healthModifier;

        [Tooltip("This class' mana modifier.")]
        [SerializeField] private int _manaModifier;

        [Tooltip("This class' strength modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _strengthModifier;

        [Tooltip("This class' magic modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _magicModifier;

        [Tooltip("This class' physical defense modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _physicalDefenseModifier;

        [Tooltip("This class' magic resistance modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _magicResistanceModifier;

        [Tooltip("This class' dexterity modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _dexterityModifier;

        [Tooltip("This class' critical chance modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _criticalChanceModifier;

        [Tooltip("This class' accuracy modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _accuracyModifier;

        [Tooltip("This class' evasion modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _evasionModifier;

        [Tooltip("This class' movement modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _movementModifier;

        [Tooltip("This class' jump modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _jumpModifier;

        [Tooltip("This class' magic modifier.")]
        [Range(-6, 6)]
        [SerializeField] private int _spellcastingSpeedModifier;
        #endregion

        #region Class Properties
        /// <summary>
        /// This class' name
        /// </summary>
        public string ClassName
        {
            get => _className;
        }
        /// <summary>
        /// This class' ability
        /// </summary>
        public AbilityAsset Ability
        {
            get => _ability;
        }
        /// <summary>
        /// This class' health modifier
        /// </summary>
        public int HealthModifier
        {
            get => _healthModifier;
        }
        /// <summary>
        /// This class' mana modifier
        /// </summary>
        public int ManaModifier
        {
            get => _manaModifier;
        }
        /// <summary>
        /// This class' strength modifier
        /// </summary>
        public int StrengthModifier
        {
            get => _strengthModifier;
        }
        /// <summary>
        /// This class' magic modifier
        /// </summary>
        public int MagicModifier
        {
            get => _magicModifier;
        }
        /// <summary>
        /// This class' physical defense modifier
        /// </summary>
        public int PhysicalDefenseModifier
        {
            get => _physicalDefenseModifier;
        }
        /// <summary>
        /// This class' magic resistance modifier
        /// </summary>
        public int MagicResistanceModifier
        {
            get => _magicResistanceModifier;
        }
        /// <summary>
        /// This class' dexterity modifier
        /// </summary>
        public int DexterityModifier
        {
            get => _dexterityModifier;
        }
        /// <summary>
        /// This class' critical chance modifier
        /// </summary>
        public int CriticalChanceModifier
        {
            get => _criticalChanceModifier;
        }
        /// <summary>
        /// This class' accuracy modifier
        /// </summary>
        public int AccuracyModifier
        {
            get => _accuracyModifier;
        }
        /// <summary>
        /// This class' evasion modifier
        /// </summary>
        public int EvasionModifier
        {
            get => _evasionModifier;
        }
        /// <summary>
        /// This class' movement modifier
        /// </summary>
        public int MovementModifier
        {
            get => _movementModifier;
        }
        /// <summary>
        /// This class' jump modifier
        /// </summary>
        public int JumpModifier
        {
            get => _jumpModifier;
        }
        /// <summary>
        /// This class' spellcasting speed modifier
        /// </summary>
        public int SpellcastingSpeedModifier
        {
            get => _spellcastingSpeedModifier;
        }
        #endregion
    }
}
