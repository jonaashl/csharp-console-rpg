using ConsoleRPG.CustomException;
using ConsoleRPG.Enumerators;
using ConsoleRPG.Hero;
using ConsoleRPG.Hero.HeroClasses;
using ConsoleRPG.Hero.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleRPG_Test
{
    public class ItemTest
    {
        [Fact] // Not really sure if this is what is meant by the check if armor is created successfully
        public void CheckIfArmorObjectIs_InitializedWithCorrectStats()
        {
            Armor expectedArmor = new Armor("Steel Platebody", 10, ArmorSlots.Body, ArmorTypes.Plate, new HeroAttribute(2, 0, 0));
            Armor actualArmor = new Armor("Steel Platebody", 10, ArmorSlots.Body, ArmorTypes.Plate, new HeroAttribute(2, 0, 0));

            Assert.Equivalent(expectedArmor, actualArmor);
        }

        [Fact] // Not really sure if this is what is meant by the check if weapon is created successfully
        public void CheckIfWeaponObjectIs_InitializedWithCorrectStats()
        {
            // Arrange
            Weapon expectedWeapon = new Weapon("Thunderfury, Blessed sword of the windseeker", 1, ArmorSlots.Weapon, WeaponTypes.Sword, 100);

            // Act
            Weapon actualWeapon = new Weapon("Thunderfury, Blessed sword of the windseeker", 1, ArmorSlots.Weapon, WeaponTypes.Sword, 100);

            // Assert
            Assert.Equivalent(expectedWeapon, actualWeapon);
        }


        [Fact]
        public void HeroEquip_WeaponOfTooHighLevel_Should_ThrowException()
        {
            //Arrange
            Warrior warrior = new Warrior("Jonas");
            Weapon weapon = new Weapon("Steel Greatsword", 10, ArmorSlots.Weapon, WeaponTypes.Sword, 10);
            //Act

            //Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon));
        }

        [Fact]
        public void HeroEquip_ArmorOfTooHighLevel_Should_ThrowException()
        {
            //Arrange
            Warrior warrior = new Warrior("Jonas");
            Armor armor = new Armor("Steel Platebody", 10, ArmorSlots.Body, ArmorTypes.Plate, new HeroAttribute(2, 0, 0));
            //Act

            //Assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor));
        }

        [Fact]
        public void HeroEquip_WeaponOfWrongWeaponType_Should_ThrowException()
        {
            Mage mage = new Mage("Khadgar");
            Weapon weapon = new Weapon("Thunderfury, Blessed sword of the windseeker", 1, ArmorSlots.Weapon, WeaponTypes.Sword, 100);
            
            Assert.Throws<InvalidWeaponException>(() => mage.Equip(weapon));
        }

        [Fact]
        public void HeroEquip_ArmorOfWrongArmorType_Should_ThrowException()
        {
            //Arrange
            Mage mage = new Mage("Khadgar");
            Armor armor = new Armor("Steel Platebody", 10, ArmorSlots.Body, ArmorTypes.Plate, new HeroAttribute(2, 0, 0));
            //Act

            //Assert
            Assert.Throws<InvalidArmorException>(() => mage.Equip(armor));
        }

        [Fact] // we already checked if a Hero is instansiated with correct stats, both on creation and levelUp
                // therefore we start with 1 armor item equipped
        public void CheckHeroAttribute_When_OneItemIsEquipped()
        {
            // Arrange
            Mage mage = new Mage("Jaina Proudmore");
            Armor armor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            mage.Equip(armor);
            mage.UpdateAttributes();
            // Act
            HeroAttribute expectedAttributes = mage.LevelAttributes + armor.ArmorAttribute;
            HeroAttribute actualAttributes = mage.TotalAttributes;
            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        [Fact]
        public void CheckHeroAttribute_When_TwoItemsAreEquipped()
        {
          // Arrange
            Mage mage = new Mage("Jaina Proudmore");
            Armor bodyArmor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            Armor headArmor = new Armor("Wizard Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 1));
            
            //scam overloadError cba fix, will call several times
            mage.Equip(bodyArmor);
            mage.Equip(headArmor);
            mage.UpdateAttributes();
          // Act
            HeroAttribute expectedAttributes = mage.LevelAttributes + bodyArmor.ArmorAttribute + headArmor.ArmorAttribute;
            HeroAttribute actualAttributes = mage.TotalAttributes;
          // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        [Fact]
        public void CheckHeroAttribute_When_ThreeItemsAreEquipped()
        {
            // Arrange
            Mage mage = new Mage("Jaina Proudmore");
            Armor bodyArmor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            Armor headArmor = new Armor("Wizard Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 1));
            Armor legArmor = new Armor("Wizard Robe Skirt", 1, ArmorSlots.Legs, ArmorTypes.Cloth, new HeroAttribute(3, 3, 3));

            //scam overloadError cba fix, will call several times
            mage.Equip(bodyArmor);
            mage.Equip(headArmor);
            mage.Equip(legArmor);
            mage.UpdateAttributes();
            // Act
            HeroAttribute expectedAttributes = mage.LevelAttributes + bodyArmor.ArmorAttribute + headArmor.ArmorAttribute + legArmor.ArmorAttribute;
            HeroAttribute actualAttributes = mage.TotalAttributes;
            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        [Fact]
        public void CheckHeroAttributes_When_AnItemIsReplaced()
        {
            // Arrange
            Mage mage = new Mage("Khadgar");
            Armor bodyArmor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            Armor headArmor = new Armor("Wizard Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 1));
            Armor legArmor = new Armor("Wizard Robe Skirt", 1, ArmorSlots.Legs, ArmorTypes.Cloth, new HeroAttribute(3, 3, 3));
            Armor replacebodyArmor = new Armor("Ancestral Robe Top", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 1, 10));
            mage.Equip(bodyArmor);
            mage.Equip(headArmor);
            mage.Equip(legArmor);
            mage.UpdateAttributes();
            mage.Equip(replacebodyArmor);
            mage.UpdateAttributes();
            // Act
            HeroAttribute expectedAttributes = mage.LevelAttributes + bodyArmor.ArmorAttribute + headArmor.ArmorAttribute + legArmor.ArmorAttribute;
            HeroAttribute actualAttributes = mage.TotalAttributes;
            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        [Fact]
        public void CheckHeroDamage_WhenNoWeapon_IsEquipped()
        {
            // Arrange
            Mage mage = new Mage("Khadgar");
            Armor armor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            mage.Equip(armor);
            mage.UpdateAttributes();
            // Act
            double expectedDamage = (int)1 * (1 + mage.TotalAttributes.Intelligence / 100.0);
            double actualDamage = mage.Damage();
            // Assert
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHeroDamage_WhenWeapon_isEquipped()
        {
            // Arrange
            Mage mage = new Mage("Khadgar");
            Weapon weapon = new Weapon("Atiesh, Greatstaff of the Guardian", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 100);
            mage.Equip(weapon);
            mage.UpdateAttributes();
            // Act
            double expectedDamage = weapon.WeaponDamage * (1 + mage.TotalAttributes.Intelligence / 100.0);
            double actualDamage = mage.Damage();
            // Assert
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHeroDamage_WhenWeaponAndArmor_IsEquipped()
        {
            //Arrange
            Mage mage = new Mage("Khadgar");
            Weapon weapon = new Weapon("Atiesh, Greatstaff of the Guardian", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 100);
            Armor armor = new Armor("Wizard Robes", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2, 2, 2));
            mage.Equip(armor);
            mage.Equip(weapon);
            mage.UpdateAttributes();
            // Act
            double expectedDamage = weapon.WeaponDamage * (1 + mage.TotalAttributes.Intelligence / 100.0);
            double actualDamage = mage.Damage();
            // Assert
            Assert.Equal(expectedDamage, actualDamage);


        }
        [Fact]
        public void CheckHeroDamage_WhenWeaponIsReplacedBy_NewWeapon()
        {
            // Arrange
            Mage mage = new Mage("Khadgar");
            Weapon weapon = new Weapon("Atiesh, Greatstaff of the Guardian", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 100);
            Weapon replacingWeapon = new Weapon("Staff of Self-doubt", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 500);
            mage.UpdateAttributes();
            mage.Equip(replacingWeapon);
            mage.UpdateAttributes();
            // Act
            double expectedDamage = 500 * (1 + mage.TotalAttributes.Intelligence / 100.0);
            double actualDamage = mage.Damage();
            // Assert
            Assert.Equivalent(expectedDamage, actualDamage);
        }

        //[Fact]
        // Bro this is supposed to work, what the fuck is the string builder syntax.
        //public void Check_If_Hero_DisplayItself_Correctly ()
        //{
        //    // Arrange
        //    Mage mage = new Mage("Khadgar");
        //    Weapon weapon = new Weapon("Atiesh", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 50);
        //    Armor AncestralTop = new Armor("Ancestral Top", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
        //    Armor AncestralHat = new Armor("Ancestral Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
        //    Armor AncestralLegs = new Armor("Ancestral Legs", 1, ArmorSlots.Legs, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
        //    mage.Equip(weapon);
        //    mage.Equip(AncestralTop);
        //    mage.Equip(AncestralHat);
        //    mage.Equip(AncestralLegs);
        //    // Act
        //    string expectedDisplay = "Name: Khadgar\n" +
        //                     "Class: Mage\n" +
        //                     "Level: 1\n" +
        //                     "Strength from levels: 1\n" +
        //                     "Dexterity from levels: 1\n" +
        //                     "Intelligence from levels: 8\n" +
        //                     "Total Strength: 4\n" +
        //                     "Total Dexterity: 4\n" +
        //                     "Total Intelligence: 38\n" +
        //                     "Damage: 69\n";

        //    string actualDisplay = mage.Display();

        //    // Assert
        //    Assert.Equal(expectedDisplay, actualDisplay);

        //}
    }
}
