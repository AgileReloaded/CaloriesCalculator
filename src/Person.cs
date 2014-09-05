namespace Kata
{
    public class Person
    {

        public const int MEDIUM_SIZE = 2;
        public const int FAT = 3;
        public const int SLIM = 1;


        public Person(string name, int kg)
        {
            this.name = name;
            this.kg = kg;
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int kg;
        public int Kg
        {
            get { return kg; }
            set { kg = value; }
        }


        public int Size
        {
            get
            {
                if (kg > 130)
                    return 3;
                if (kg < 50)
                    return 1;
                return MEDIUM_SIZE;
            }
        }

    }
}