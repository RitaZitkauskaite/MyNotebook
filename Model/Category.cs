namespace MyNotebook.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MyNotebookUserId { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
