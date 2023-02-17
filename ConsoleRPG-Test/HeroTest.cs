using ConsoleRPG.Hero.HeroClasses;
using ConsoleRPG;
using ConsoleRPG.Hero;

namespace ConsoleRPG_Test
{
    public class HeroTest
    {
        [Fact]
        public void Warrior_Level_When_Created()
        {
            // Arrange
            Warrior warrior = new Warrior("Jonas");
            // Act
            int expected = 1;
            int actual = warrior.Level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Ranger_Level_When_Created()
        {
            // Arrange
            Ranger ranger = new Ranger("Jonas");
            // Act
            int expected = 1;
            int actual = ranger.Level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Mage_Level_When_Created()
        {
            // Arrange
            Mage mage = new Mage("Jonas");
            // Act
            int expected = 1;
            int actual = mage.Level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Rogue_Level_When_Created()
        {
            // Arrange
            Rogue rogue = new Rogue("Jonas");
            // Act
            int expected = 1;
            int actual = rogue.Level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Warrior_Gain_1_Level_On_Levelup()
        {
            Warrior warrior = new Warrior("Jonas");
            warrior.LevelUp();

            int expected = 2;
            int actual = warrior.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Mage_Gain_1_Level_On_Levelup()
        {
            Mage mage = new Mage("Jonas");
            mage.LevelUp();

            int expected = 2;
            int actual = mage.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Ranger_Gain_1_Level_On_Levelup()
        {
            Ranger ranger = new Ranger("Jonas");
            ranger.LevelUp();

            int expected = 2;
            int actual = ranger.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Rogue_Gain_1_Level_On_Levelup()
        {
            Rogue rogue = new Rogue("Jonas");
            rogue.LevelUp();

            int expected = 2;
            int actual = rogue.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HeroAttributes_When_HeroOfType_Warrior_isCreated()
        {
            Warrior warrior = new Warrior("Jonas");

            HeroAttribute expected = new HeroAttribute(5, 2, 1);
            HeroAttribute actual = warrior.TotalAttributes;
            
            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void HeroAttributes_When_HeroOfType_Rogue_isCreated()
        {
            Rogue rogue = new Rogue("Jonas");

            HeroAttribute expected = new HeroAttribute(2, 6, 1);
            HeroAttribute actual = rogue.TotalAttributes;

            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void HeroAttributes_When_HeroOfType_Ranger_isCreated()
        {
            Ranger ranger = new Ranger("Jonas");

            HeroAttribute expected = new HeroAttribute(1, 7, 1);
            HeroAttribute actual = ranger.TotalAttributes;

            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void HeroAttributes_When_HeroOfType_Mage_isCreated()
        {
            Mage mage = new Mage("Jonas");

            HeroAttribute expected = new HeroAttribute(1, 1, 8);
            HeroAttribute actual = mage.TotalAttributes;

            Assert.Equivalent(expected, actual);
        }
        [Fact]
        public void WarriorLevelUp_Increase_HeroAttributes_ByIncrement_LevelAttributes()
        {
            Warrior warrior = new Warrior("Jonas");
            warrior.LevelUp();

            HeroAttribute expected = new HeroAttribute(8, 4, 2);
            HeroAttribute actual = warrior.LevelAttributes;

            Assert.Equivalent(expected, actual);

        }
        [Fact]
        public void MageLevelUp_Increase_HeroAttributes_ByIncrement_LevelAttributes()
        {
            Mage mage = new Mage("Jonas");
            mage.LevelUp();

            HeroAttribute expected = new HeroAttribute(2, 2, 13);
            HeroAttribute actual = mage.LevelAttributes;

            Assert.Equivalent(expected, actual);

        }
        [Fact]
        public void RogueLevelUp_Increase_HeroAttributes_ByIncrement_LevelAttributes()
        {
            Rogue rogue = new Rogue("Jonas");
            rogue.LevelUp();

            HeroAttribute expected = new HeroAttribute(3, 10, 2);
            HeroAttribute actual = rogue.LevelAttributes;
            
            Assert.Equivalent(expected, actual);

        }

        [Fact]
        public void RangerLevelUp_Increase_HeroAttributes_ByIncrement_LevelAttributes()
        {
            Ranger ranger = new Ranger("Jonas");
            ranger.LevelUp();

            HeroAttribute expected = new HeroAttribute(2, 12, 2);
            HeroAttribute actual = ranger.LevelAttributes;

            Assert.Equivalent(expected, actual);

        }
    }
}