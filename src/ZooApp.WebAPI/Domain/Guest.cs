namespace ZooApp.WebAPI.Domain
{
    public class Guest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Guest(int ID, string Name, int Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }
    }
}