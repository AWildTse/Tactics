using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tactics.Character;

namespace Tactics.EventArguments
{
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

    public class AddPartyEventArgs : EventArgs
    {
        public AddPartyEventArgs(CharacterAsset addCharacter)
        {
            AddCharacter = addCharacter;
        }
        public CharacterAsset AddCharacter { get; private set; }
    }
}