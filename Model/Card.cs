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
    private Dictionary<Guid, (int correct, int wrong)> _answer;

    [ObservableProperty]
    private Dictionary<Guid, (int facil, int medio, int dificil)> _difficulty;

    public Card()
    {
        if (Id == Guid.Empty) Id = Guid.NewGuid();
        IsAnswerVisible = false;

        // Answer = new Dictionary<Guid, (int correct, int wrong)>();
        Answer = [];
        // Difficulty = new Dictionary<Guid, (int facil, int medio, int dificil)>();
        Difficulty = [];
    }

    [JsonConstructor]
    public Card(Guid id, string quest, string resp, string category, bool isAnswerVisible)
    {
        Id = id;
        Quest = quest;
        Resp = resp;
        Category = category;
        IsAnswerVisible = isAnswerVisible;

        Answer = [];
        Difficulty = [];
    }
}
