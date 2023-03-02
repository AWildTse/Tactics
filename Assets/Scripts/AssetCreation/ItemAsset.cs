using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Interfaces;

namespace Tactics.Item
{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Items")]
    public abstract class ItemAsset : ScriptableObject, IItem
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
    }
}