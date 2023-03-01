using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tactics.Character
{

    public class PartyMember : CharacterAsset
    {
        public event EventHandler<AddedPartyEventArgs> AddedPartyMember;
        public event EventHandler<RemovedPartyEventArgs> RemovedPartyMember;

        public List<CharacterAsset> _listOfPartyMembers;

        public void Start()
        {
            
        }

        public void AddPartyMember(CharacterAsset addCharacter)
        {
            if (AddedPartyMember != null)
                AddedPartyMember(this, new AddedPartyEventArgs(addCharacter));
            _listOfPartyMembers.Add(addCharacter);
        }
        public void RemovePartyMember(CharacterAsset removeCharacter)
        {
            if(RemovedPartyMember != null)
                RemovedPartyMember(this, new RemovedPartyEventArgs(removeCharacter));
            _listOfPartyMembers.Add(removeCharacter);
        }
    }
    public class AddedPartyEventArgs : EventArgs
    {
        public AddedPartyEventArgs(CharacterAsset addCharacter)
        {
            AddCharacter = addCharacter;
        }
        public CharacterAsset AddCharacter { get; private set; }
    }

    public class RemovedPartyEventArgs : EventArgs
    {
        public RemovedPartyEventArgs(CharacterAsset removeCharacter)
        {
            RemoveCharacter = removeCharacter;
        }
        public CharacterAsset RemoveCharacter { get; private set; }
    }
}
