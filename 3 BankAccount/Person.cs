namespace _3_BankAccount
{
    internal class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public void IntroduceYurself()
        {
            Console.WriteLine($"Hello, my name is {this.Name} and I am {this.Age} years old.");
        }
    }
}