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
        public class HealthProperty
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
            public void Over_Restoring_Is_Ignored()
            {
                character.Restore(2, Character.StatType.hp);

                Assert.AreEqual(1, character.Health);
            }
        }

        public class ManaProperty
        {
            private Character character;

            [SetUp]
            public void Before_Every_Test()
            {
                character = new Character();
                character.Mana = 0;
                character.MaxMana = 1;
            }

            [Test]
            public void _0_Does_Nothing()
            {
                character.Restore(0, Character.StatType.mp);

                Assert.AreEqual(0, character.Mana);
            }

            [Test]
            public void _1_Increments_Current_Health()
            {
                character.Restore(1, Character.StatType.mp);

                Assert.AreEqual(1, character.Mana);
            }

            [Test]
            public void Overheating_Is_Ignored()
            {
                character.Restore(2, Character.StatType.mp);

                Assert.AreEqual(1, character.Mana);
            }
        }

        public class TheHealedEvent
        {
            private Character character;
            [SetUp]
            public void Before_Every_Test()
            {
                character = new Character();
                character.Health = 1;
                character.MaxHealth = 1;
            }

            [Test]
            public void Raises_Event_On_Restore()
            {
                var amount = -1f;

                character.Restored += (sender, args) =>
                {
                    amount = args.Amount;
                };

                character.Restore(0, Character.StatType.hp);

                Assert.AreEqual(0, amount);
            }

            [Test]
            public void Over_Restoring_Is_Ignored()
            {
                var amount = -1f;

                character.Restored += (sender, args) =>
                {
                    amount = args.Amount;
                };

                character.Restore(1, Character.StatType.hp);

                Assert.AreEqual(0, amount);
            }
        }
        public class StrengthProperty
        {

        }
    }
}
