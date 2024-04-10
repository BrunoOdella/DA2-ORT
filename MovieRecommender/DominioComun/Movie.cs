namespace DominioComun
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title {  get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
