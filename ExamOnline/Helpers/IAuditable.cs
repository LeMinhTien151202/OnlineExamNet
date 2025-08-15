namespace ExamOnline.Helpers
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedUp { get; set; }
    }
}
