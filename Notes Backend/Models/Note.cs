namespace Notes.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateOnly CreatedAt { get; set; }

        public Note(string Title, string Content)
        {
            this.Title = Title;
            this.Content = Content;
            Id = Guid.NewGuid();
            CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        }

    }

    public record NoteRecord(string Title, string Content);
}
