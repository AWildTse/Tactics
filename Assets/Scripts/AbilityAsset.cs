using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Ability
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "ScriptableObjects/Ability")]
    public class AbilityAsset : ScriptableObject
    {
        [SerializeField] private string _abilityName;
        [SerializeField] private string _abilityDescription;
    }
}