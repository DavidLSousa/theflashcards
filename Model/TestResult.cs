namespace theflashcards.Model;

public class TestResult
{
    public Guid Id { get; set; }
    public required Dictionary<string, int > Answer { get; set; }
    public required Dictionary<string, int> Difficulty { get; set; }

}