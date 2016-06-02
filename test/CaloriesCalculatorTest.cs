namespace Kata
{

    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class CaloriesCalculatorTest
    {

        private Person tom;
        private Food apple;
        private List<Food> foods;

        [TestInitialize]
        public void setUp()
        {
            tom = new Person("tom", 72);
            apple = new Food("apple", 0.2);
            foods = new List<Food>();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void shouldThrowAnExceptionWhenAFoodDoesNotHaveAName()
        {
            Food foodWithoutName = new Food("", 0.0);
            foods.Add(foodWithoutName);
            new CaloriesCalculator(tom, foods).result();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void shouldThrowAnExceptionWhenWeightIsOverOneThousandKg()
        {
            Person notHuman = new Person("any", 1001);
            foods.Add(apple);
            new CaloriesCalculator(notHuman, foods).result();
        }

        [TestMethod]
        public void noFoodNoCalories()
        {
            Food air = new Food("air", 0.0);
            foods.Add(air);
            String actual = new CaloriesCalculator(tom, foods).result();
            Assert.IsTrue(actual.Contains("Diet Report for tom:\nair - 0\nTotal: 0 kcal"));
        }

        [TestMethod]
        public void shouldDecreaseCaloriesWhenEatingTheMagicPill()
        {
            Food magicPill = new Food("magicPill", 0.01);
            foods.Add(magicPill);
            String actual = new CaloriesCalculator(tom, foods).result();
            Assert.IsTrue(actual.Contains("Diet Report for tom:\nmagicPill - 0,01\nTotal: -10 kcal"));
        }

        [TestMethod]
        public void howMuchJoggingToBurnCalories()
        {
            foods.Add(apple);
            Assert.IsTrue(reportForNormalWeight().Contains("kilometers to be run: " + 90 * Person.MEDIUM_SIZE / 30));
            Assert.IsTrue(reportForFatPeople().Contains("kilometers to be run: " + 90 * Person.FAT / 30));
            Assert.IsTrue(reportForSlimPeople().Contains("kilometers to be run: " + 90 * Person.SLIM / 30));
        }

        private String reportForSlimPeople()
        {
            Person fab = new Person("fab", 45);
            return new CaloriesCalculator(fab, foods).result();
        }

        private String reportForFatPeople()
        {
            Person bob = new Person("bob", 150);
            return new CaloriesCalculator(bob, foods).result();
        }

        private String reportForNormalWeight()
        {
            return new CaloriesCalculator(tom, foods).result();
        }

        [TestMethod]
        public void appleCalories()
        {
            Food apple = new Food("apple", 0.2);
            foods.Add(apple);
            String actual = new CaloriesCalculator(tom, foods).result();
            Assert.IsTrue(actual.Contains("Diet Report for tom:\napple - 0,2\nTotal: 30 kcal"));
            foods.Add(apple);
            actual = new CaloriesCalculator(tom, foods).result();
            Assert.IsTrue(actual.Contains("Diet Report for tom:\napple - 0,2\napple - 0,2\nTotal: 60 kcal"));
        }

    }
}