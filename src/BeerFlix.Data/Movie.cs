namespace BeerFlix.Data
{
    public class Movie
    {
        private readonly string _name;

        public Movie(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}