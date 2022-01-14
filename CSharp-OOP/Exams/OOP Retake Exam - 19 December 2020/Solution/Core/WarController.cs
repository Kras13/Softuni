using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> charactersParty;
        private Stack<Item> itemsPool;
        public WarController()
        {
            charactersParty = new List<Character>();
            itemsPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string characterName = args[1];
            if (characterType == "Warrior")
            {
                Warrior warrior = new Warrior(characterName);
                this.charactersParty.Add(warrior);
            }
            else if (characterType == "Priest")
            {
                Priest priest = new Priest(characterName);
                this.charactersParty.Add(priest);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            return string.Format(SuccessMessages.JoinParty, characterName);
        }

        public string AddItemToPool(string[] args)
        {
            string type = args[0];

            if (type == "FirePotion")
            {
                Item item = new FirePotion();
                this.itemsPool.Push(item);
            }
            else if (type == "HealthPotion")
            {
                Item item = new HealthPotion();
                this.itemsPool.Push(item);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, type));
            }
            return string.Format(SuccessMessages.AddItemToPool, type);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];
            Character selectedCharacter = this.charactersParty
                .FirstOrDefault(c => c.Name == name);
            if (selectedCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }
            if (itemsPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item pickedItem = this.itemsPool.Pop();
            selectedCharacter.Bag.AddItem(pickedItem);
            return string.Format(SuccessMessages.PickUpItem, selectedCharacter.Name,
                pickedItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = charactersParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName);

            if (character.Bag.Items.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyBag));
            }
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
            }

            character.UseItem(item);
            //return $"{character.Name} used {itemName}.";
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var sortedChars = this.charactersParty.OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);
            StringBuilder sb = new StringBuilder();

            foreach (var character in sortedChars)
            {
                string charStatus = "Dead";
                if (character.IsAlive)
                {
                    charStatus = "Alive";
                }
                //sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, " +
                //    $"AP: {character.Armor}/{character.BaseArmor}, Status: {charStatus}");
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name
                    , character.Health, character.BaseHealth, character.Armor, character.BaseArmor, charStatus));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string recieverName = args[1];
            Warrior attacker = (Warrior)this.charactersParty.FirstOrDefault(c => c.Name == attackerName);
            Character defender = this.charactersParty.FirstOrDefault(c => c.Name == recieverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (defender == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }

            if (!attacker.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            if (!defender.IsAlive)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.AffectedCharacterDead));
            }

            attacker.Attack(defender);

            bool result = false;
            if (!defender.IsAlive)
            {
                result = true;
            }

            if (result)
            {
                return $"{attackerName} attacks {recieverName} for " +
                       $"{attacker.AbilityPoints} hit points! {recieverName} " +
                       $"has {defender.Health}/{defender.BaseHealth} " +
                       $"HP and {defender.Armor}/{defender.BaseArmor} AP left!" + Environment.NewLine
                       + $"{recieverName} is dead!";

                //return string.Format(SuccessMessages.AttackKillsCharacter
                //    , attackerName, recieverName, attacker.AbilityPoints,
                //    recieverName, defender.Health, defender.BaseHealth, defender.Armor, defender.BaseArmor, recieverName);
            }
            else
            {
                return string.Format(SuccessMessages.AttackCharacter
                    , attackerName, recieverName, attacker.AbilityPoints,
                    recieverName, defender.Health, defender.BaseHealth, defender.Armor, defender.BaseArmor);
            }
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];
            Priest healer = (Priest)this.charactersParty.FirstOrDefault(c => c.Name == healerName);
            Character reciever = this.charactersParty.FirstOrDefault(c => c.Name == receiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!healer.IsAlive || !reciever.IsAlive)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal));
            }

            healer.Heal(reciever);
            //return $"{healer.Name} heals {reciever.Name} for {healer.AbilityPoints}! {reciever.Name} " +
            //    $"has {reciever.Health} health now!";
            return string.Format(SuccessMessages.HealCharacter, healer.Name, reciever.Name,
                healer.AbilityPoints, reciever.Name, reciever.Health);
        }
    }
}
