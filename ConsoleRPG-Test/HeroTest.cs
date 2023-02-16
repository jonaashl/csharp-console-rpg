using ConsoleRPG.Hero.HeroClasses;
using ConsoleRPG;
using ConsoleRPG.Hero;

namespace ConsoleRPG_Test
{
    public class HeroTest
    {
        [Fact]
        public void Hero_Level_When_Created()
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
        public void Gain_1_Level_On_Levelup()
        {
            Warrior warrior = new Warrior("Jonas");
            warrior.LevelUp();

            int expected = 2;
            int actual = warrior.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HeroAttributes_When_Warrior_isCreated()
        {
            Warrior warrior = new Warrior("Jonas");

            HeroAttribute expected = new HeroAttribute(5, 2, 1);
            HeroAttribute actual = warrior.TotalAttributes;
            
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void HeroAttributes_When_Rogue_isCreated()
        {
            Rogue rogue = new Rogue("Jonas");

            HeroAttribute expected = new HeroAttribute(2, 6, 1);
            HeroAttribute actual = rogue.TotalAttributes;

            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void HeroAttributes_When_Ranger_isCreated()
        {
            Ranger ranger = new Ranger("Jonas");

            HeroAttribute expected = new HeroAttribute(1, 7, 1);
            HeroAttribute actual = ranger.TotalAttributes;

            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void HeroAttributes_When_Mage_isCreated()
        {
            Mage mage = new Mage("Jonas");

            HeroAttribute expected = new HeroAttribute(1, 1, 8);
            HeroAttribute actual = mage.TotalAttributes;

            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
        [Fact]
        public void LevelUp_Warrior_Correct_HeroAttributes()
        {
            Warrior warrior = new Warrior("Jonas");
            warrior.LevelUp();

            HeroAttribute expected = new HeroAttribute(8, 4, 2);
            HeroAttribute actual = warrior.TotalAttributes;

            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);

        }
    }
}