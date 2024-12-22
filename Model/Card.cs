using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace theflashcards.Model;

public partial class Card : ObservableObject
{
    public Guid Id { get; private set; }
    public string Quest { get; set; }
    public string Resp { get; set; }
    public string Category { get; set; }

    [ObservableProperty]
    private bool _isAnswerVisible;

    [ObservableProperty]
    private TestResult _testResult;

    public Card()
    {
        if (Id == Guid.Empty) Id = Guid.NewGuid();
        IsAnswerVisible = false;

        TestResult = new TestResult
        {
            Id = Id,
            Answer = new Dictionary<string, int>
            {
                { "correct", 0 },
                { "wrong", 0 }
            },
            Difficulty = new Dictionary<string, int>
            {
                { "easy", 0 },
                { "medium", 0 },
                { "difficult", 0 }
            }
        };
    }

    [JsonConstructor]
    public Card(Guid id, string quest, string resp, string category, bool isAnswerVisible)
    {
        Id = id;
        Quest = quest;
        Resp = resp;
        Category = category;
        IsAnswerVisible = isAnswerVisible;

        TestResult = new TestResult
        {
            Id = Id,
            Answer = new Dictionary<string, int>
            {
                { "correct", 0 },
                { "wrong", 0 }
            },
            Difficulty = new Dictionary<string, int>
            {
                { "easy", 0 },
                { "medium", 0 },
                { "difficult", 0 }
            }
        };
    }
}
