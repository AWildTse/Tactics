//using Editor.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Tactics.Character;

namespace Editor
{
    public class CharacterTests
    {
        public class TheCurrentHealthProperty
        {
            private Character character;

            [SetUp]
            public void Before_Every_Test()
            {
                character = new Character();
                character.Health = 0;
                character.MaxHealth = 1;
            }

            [Test]
            public void _0_Does_Nothing()
            {
                character.Restore(0, Character.StatType.hp);

                Assert.AreEqual(0, character.Health);
            }

            [Test]
            public void _1_Increments_Current_Health()
            {
                character.Restore(1, Character.StatType.hp);

                Assert.AreEqual(1, character.Health);
            }

            [Test]
            public void Overhealing_Is_Ignored()
            {
                character.Restore(2, Character.StatType.hp);

                Assert.AreEqual(1, character.Health);
            }
        }
    }
}
