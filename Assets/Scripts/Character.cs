using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Tactics.Ability;
using Tactics.Class;
using Tactics.Skills;

namespace Tactics.Character
{
    [CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Characters")]

    public class Character : ScriptableObject
    {
        [SerializeField] private string _characterFirstName;
        [SerializeField] private string _characterLastName;

        private List<ClassAsset> _characterAvailableClasses;
        private List<SkillAsset> _characterAvailableSkills;
        
        //Inventory
        //Equipped Items

        #region Character Stat Properties

        #region Health & Mana
        /// <summary>
        /// A character's current Health
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// The maximum Health a character can have
        /// </summary>
        public int MaxHealth { get; set; }
        /// <summary>
        /// A character's current Mana
        /// </summary>
        public int Mana { get; set; }
        /// <summary>
        /// The maximum Mana a character can have
        /// </summary>
        public int MaxMana { get; set; }
        #endregion

        #region Strength & Magic
        /// <summary>
        /// Strength determines how much physical damage the character does.
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// This is the Strength + any stat modifiers
        /// </summary>
        public int CurrStr { get; set; }
        /// <summary>
        /// Magic determines how much magical damage the character does
        /// </summary>
        public int Magic { get; set; }
        /// <summary>
        /// This is the Magic + any stat modifiers
        /// </summary>
        public int CurrMag { get; set; }
        #endregion

        #region Resistances
        /// <summary>
        /// Physical Resistance determines how much physical damage is mitigated
        /// </summary>
        public int PhysDef { get; set; }
        /// <summary>
        /// This is the Physical Resistance + any stat modifiers
        /// </summary>
        public int CurrPhysDef { get; set; }
        /// <summary>
        /// Magical Resistance determines how much magical damage is mitigated
        /// </summary>
        public int MagicRes { get; set; }
        /// <summary>
        /// This is the Magical Resistance + any stat modifiers
        /// </summary>
        public int CurrMagicRes { get; set; }
        #endregion

        #region Movements & Turns
        /// <summary>
        /// Movement determines how many places a character can move
        /// </summary>
        public int Movement { get; set; }
        /// <summary>
        /// This is the Movement + any stat modifiers
        /// </summary>
        public int CurrMovement { get; set; }
        /// <summary>
        /// Jump determines how high a character can jump to reach a new place. (Requires one Movement)
        /// </summary>
        public int Jump { get; set; }
        /// <summary>
        /// This is the Jump + any stat modifiers
        /// </summary>
        public int CurrJump { get; set; }
        /// <summary>
        /// Dex determines a character's speed, accuracy, and evasion
        /// </summary>
        public int Dexterity { get; set; }
        /// <summary>
        /// This is the Dexterity + any stat modifiers
        /// </summary>
        public int CurrDexterity { get; set; }
        #endregion

        #region Misc
        /// <summary>
        /// Critical Chance determines the chance of the player's physical or magical attack dealing double damage
        /// </summary>
        public int Crit { get; set; }
        /// <summary>
        /// This is the Critical Chance + any stat modifiers
        /// </summary>
        public int CurrCrit { get; set; }
        /// <summary>
        /// Accuracy determines the chance of landing a blow
        /// </summary>
        public int Accuracy { get; set; }
        /// <summary>
        /// This is the Accuracy + any stat modifiers
        /// </summary>
        public int CurrAccuracy { get; set; }
        /// <summary>
        /// Evasion determines the chance of dodging
        /// </summary>
        public int Evasion { get; set; }
        /// <summary>
        /// This is the Evasion + any stat modifiers
        /// </summary>
        public int CurrEvasion { get; set; }
        /// <summary>
        /// Spellcasting Speed determines how fast a spell is cast
        /// </summary>
        public int SpellcSpd { get; set; }
        /// <summary>
        /// This is the Spellcasting Speed + any stat modifiers
        /// </summary>
        public int CurrSpellcSpd { get; set; }
        #endregion

        /// <summary>
        /// This is how much a stat can be modified with abilities/skills during battle
        /// </summary>
        private const int _maxModifier = 6;
        #endregion

        /// <summary>
        /// The Character Stat being modified
        /// </summary>
        public enum StatType
        {
            hp,
            mp,
            str,
            mag,
            def,
            res,
            dex,
            cri,
            acc,
            mvt,
            jmp,
            eva,
            spc
        }
        #region Constructors
        public Character(int health, int maxHealth, int mana, int maxMana, int strength, int magic, int physDef, int magicRes, int dexterity, int crit, int accuracy, int evasion, int movement, int jump, int spellcastingSpeed)
        {
            #region Exceptions
            //Check for health range exceptions
            if (Health < 0) throw new ArgumentOutOfRangeException("Health");
            if (Health > MaxHealth) throw new ArgumentOutOfRangeException("Health");

            //Check for mana range exceptions
            if (Mana < 0) throw new ArgumentOutOfRangeException("Mana");
            if (Mana > MaxMana) throw new ArgumentOutOfRangeException("Mana");

            //Check for strength range exceptions
            if (Strength < 0) throw new ArgumentOutOfRangeException("Strength");

            //Check for magic range exceptions
            if (Magic < 0) throw new ArgumentOutOfRangeException("Magic");

            //Check for physical defense range exceptions
            if (PhysDef < 0) throw new ArgumentOutOfRangeException("PhysDef");

            //Check for magical resistance range rexceptions
            if (MagicRes < 0) throw new ArgumentOutOfRangeException("MagicRes");

            //Check for speed range exceptions
            if (Dexterity < 0) throw new ArgumentOutOfRangeException("Speed");

            //Check for crit range exceptions
            if (Crit < 0) throw new ArgumentOutOfRangeException("Crit");

            //Check for accuracy range exceptions
            if (Accuracy < 0) throw new ArgumentOutOfRangeException("Accuracy");

            //Check for movement range exceptions
            if (Movement < 0) throw new ArgumentOutOfRangeException("Movement");

            //Check for jump range exceptions
            if (Jump < 0) throw new ArgumentOutOfRangeException("Jump");

            //Check for spellcasting speed range exceptions
            if (SpellcSpd < 0) throw new ArgumentOutOfRangeException("SpellcSpd");
            #endregion

            #region Setters
            Health = health;
            MaxHealth = maxHealth;
            Mana = mana;
            MaxMana = maxMana;
            Strength = strength;
            Magic = magic;
            PhysDef = physDef;
            MagicRes = magicRes;
            Dexterity = dexterity;
            Crit = crit;
            Accuracy = accuracy;
            Evasion = evasion;
            Movement = movement;
            Jump = jump;
            SpellcSpd = spellcastingSpeed;
            #endregion
        }

        public Character()
        {

        }
        #endregion

        #region EventHandlers
        public event EventHandler<RestoredEventArgs> Restored;
        public event EventHandler<DamagedEventArgs> Damaged;
        public event EventHandler<RaisedEventArgs> Raised;
        public event EventHandler<LoweredEventArgs> Lowered;
        #endregion

        #region Character Stat Functions
        /// <summary>
        /// Use this function to restore the character's health points or mana points
        /// </summary>
        /// <param name="amount">The amount to heal</param>
        /// <param name="type">What is being healed</param>
        public void Restore(int amount, StatType type)
        {
            var newResource = 0;
            if (type == StatType.hp)
            {
                newResource = Mathf.Min(Health + amount, MaxHealth);
                if (Restored != null)
                    Restored(this, new RestoredEventArgs(newResource - Health));
                Health = newResource;
            }
            else if (type == StatType.mp)
            {
                newResource = Mathf.Min(Mana + amount, MaxMana);
                if (Restored != null)
                    Restored(this, new RestoredEventArgs(newResource - Mana));
                Mana = newResource;
            }
        }

        /// <summary>
        /// Use this function to damage/use the character's health points or mana points
        /// </summary>
        /// <param name="amount">The amount to damage/use</param>
        /// <param name="type">What is being damaged/used</param>
        public void Damage(int amount, StatType type)
        {
            var newResource = 0;
            if(type == StatType.hp)
            {
                newResource = Mathf.Max(Health - amount, 0);
                if (Damaged != null)
                    Damaged(this, new DamagedEventArgs(Health - newResource));
                Health = newResource;
            }
            else if(type == StatType.mp)
            {
                newResource = Mathf.Max(Mana - amount, 0);
                if (Damaged != null)
                    Damaged(this, new DamagedEventArgs(Mana - newResource));
                Mana = newResource;
            }
        }

        /// <summary>
        /// Use this function to raise a character's stat
        /// </summary>
        /// <param name="amount">How much the stat is being raised</param>
        /// <param name="type">What stat is being raised</param>
        public void Raise(int amount, StatType type)
        {
            var newResource = 0;
            if(type == StatType.str)
            {
                newResource = Mathf.Max(CurrStr + amount, Strength + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrStr));
                CurrStr = newResource;
            }
            else if(type == StatType.mag)
            {
                newResource = Mathf.Max(CurrMag + amount, Magic + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrMag));
                CurrMag = newResource;
            }
            else if(type == StatType.def)
            {
                newResource = Mathf.Max(CurrPhysDef + amount, PhysDef + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrPhysDef));
                CurrPhysDef = newResource;
            }
            else if(type == StatType.res)
            {
                newResource = Mathf.Max(CurrMagicRes + amount, MagicRes + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrMagicRes));
                CurrMagicRes = newResource;
            }
            else if (type == StatType.dex)
            {
                newResource = Mathf.Max(CurrDexterity + amount, Dexterity + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrDexterity));
                CurrDexterity = newResource;
            }
            else if (type == StatType.cri)
            {
                newResource = Mathf.Max(CurrCrit + amount, Crit + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrCrit));
                CurrCrit = newResource;
            }
            else if(type == StatType.acc)
            {
                newResource = Mathf.Max(CurrAccuracy + amount, Accuracy + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrAccuracy));
                CurrAccuracy = newResource;
            }
            else if (type == StatType.eva)
            {
                newResource = Mathf.Max(CurrEvasion + amount, Evasion + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrEvasion));
                CurrEvasion = newResource;
            }
            else if (type == StatType.mvt)
            {
                newResource = Mathf.Max(CurrMovement + amount, Movement + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrMovement));
                CurrMovement = newResource;
            }
            else if(type == StatType.jmp)
            {
                newResource = Mathf.Max(CurrJump + amount, Jump + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrJump));
                CurrJump = newResource;
            }         
            else if (type == StatType.spc)
            {
                newResource = Mathf.Max(CurrSpellcSpd + amount, SpellcSpd + _maxModifier);
                if (Raised != null)
                    Raised(this, new RaisedEventArgs(newResource + CurrSpellcSpd));
                CurrSpellcSpd = newResource;
            }
        }

        /// <summary>
        /// Use this function to lower a character's stat
        /// </summary>
        /// <param name="amount">How much the stat is being lowered</param>
        /// <param name="type">What stat is being lowered</param>
        public void Lower(int amount, StatType type)
        {
            var newResource = 0;
            if (type == StatType.str)
            {
                newResource = Mathf.Max(CurrStr - amount, Strength - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrStr - newResource));

                if(CurrStr < 0)
                    CurrStr = 0;
                CurrStr = newResource;
            }
            else if (type == StatType.mag)
            {
                newResource = Mathf.Max(CurrMag - amount, Magic - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrMag - newResource));

                if (CurrMag < 0)
                    CurrMag = 0;
                CurrMag = newResource;
            }
            else if (type == StatType.def)
            {
                newResource = Mathf.Max(CurrPhysDef - amount, PhysDef - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrPhysDef - newResource));

                if (CurrPhysDef < 0)
                    CurrPhysDef = 0;
                CurrPhysDef = newResource;
            }
            else if (type == StatType.res)
            {
                newResource = Mathf.Max(CurrMagicRes - amount, MagicRes - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrMagicRes - newResource));

                if (CurrMagicRes < 0)
                    CurrMagicRes = 0;
                CurrMagicRes = newResource;
            }
            else if (type == StatType.dex)
            {
                newResource = Mathf.Max(CurrDexterity - amount, Dexterity - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrDexterity - newResource));

                if (CurrDexterity < 0)
                    CurrDexterity = 0;
                CurrDexterity = newResource;
            }
            else if (type == StatType.cri)
            {
                newResource = Mathf.Max(CurrCrit - amount, Crit - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrCrit - newResource));

                if (CurrCrit < 0)
                    CurrCrit = 0;
                CurrCrit = newResource;
            }
            else if (type == StatType.acc)
            {
                newResource = Mathf.Max(CurrAccuracy - amount, Accuracy - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrAccuracy - newResource));

                if (CurrAccuracy < 0)
                    CurrAccuracy = 0;
                CurrAccuracy = newResource;
            }
            else if (type == StatType.eva)
            {
                newResource = Mathf.Max(CurrEvasion - amount, Evasion - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrEvasion - newResource));

                if (CurrEvasion < 0)
                    CurrEvasion = 0;
                CurrEvasion = newResource;
            }
            else if (type == StatType.mvt)
            {
                newResource = Mathf.Max(CurrMovement - amount, Movement - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrMovement - newResource));

                if (CurrMovement < 0)
                    CurrMovement = 0;
                CurrMovement = newResource;
            }
            else if (type == StatType.jmp)
            {
                newResource = Mathf.Max(CurrJump - amount, Jump - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrJump - newResource));

                if (CurrJump < 0)
                    CurrJump = 0;
                CurrJump = newResource;
            }

            else if (type == StatType.spc)
            {
                newResource = Mathf.Max(CurrSpellcSpd - amount, SpellcSpd - _maxModifier);
                if (Lowered != null)
                    Lowered(this, new LoweredEventArgs(CurrSpellcSpd - newResource));

                if (CurrSpellcSpd < 0)
                    CurrSpellcSpd = 0;
                CurrSpellcSpd = newResource;
            }
        }
        #endregion
    }
}

#region EventArgs
public class RestoredEventArgs : EventArgs
{
    public RestoredEventArgs(int amount)
    {
        Amount = amount;
    }
    public int Amount { get; private set; }
}

public class DamagedEventArgs : EventArgs
{
    public DamagedEventArgs(int amount)
    {
        Amount = amount;
    }
    public int Amount { get; private set; }
}

public class RaisedEventArgs : EventArgs
{
    public RaisedEventArgs(int amount)
    {
        Amount = amount;
    }
    public int Amount { get; private set; }
}

public class LoweredEventArgs : EventArgs
{
    public LoweredEventArgs(int amount)
    {
        Amount = amount;
    }
    public int Amount { get; private set; }
}
#endregion