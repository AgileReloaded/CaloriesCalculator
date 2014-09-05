using System.Collections.Generic;
namespace Kata
{
    public class CaloriesCalculator {
	    private List<Food> foods;
	    private Person person;

	    public CaloriesCalculator(Person person, List<Food> foods) {
		    this.person = person;
		    this.foods = foods;
	    }

	    public string result() {
		    string str = "Diet Report for " + person.Name +":\n";
		    double cal = 0.0;
		    for (int i = 0; i < foods.Count; i++) {
			    Food food = foods[i];
			    str += food.name + " - " + food.kg + "\n";
			    if ("".Equals(food.name)) throw new FirstException();
                if ("apple".Equals(food.name)) cal += food.kg * 15 * 10;
                if ("magicPill".Equals(food.name)) cal -= 10;
                if ("candy".Equals(food.name)) cal += food.kg;  
		    }
		    str += "Total: " + (double)cal + " kcal\n";
		    str += "kilometers to be run: " + 90 /* calories in one kilometer */ * person.Size / cal;
		    foreach (Food type in foods) {			   
			    if ("".Equals(type.name)) throw new FirstException();
			    if (person.Kg > 1000) throw new SecondException();
		    }
            return str;
	    }

    }
}