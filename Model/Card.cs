using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace theflashcards.Model
{
    public partial class Card : ObservableObject
    {
        public Guid Id { get; private set; }
        public string Quest { get; set; }
        public string Resp { get; set; }

        private List<string> _category;
        public List<string> Category
        {
            get { return _category; }
            set 
            {
                _category = new List<string>();
                foreach (var currentValue in value)
                {
                    _category.Add(currentValue.ToLower()); 
                }
            }
        }

        [ObservableProperty]
        private bool _isAnswerVisible;

        public Card()
        {
            if (Id == Guid.Empty) Id = Guid.NewGuid();            
            IsAnswerVisible = false;
        }

        [JsonConstructor]
        public Card(Guid id, string quest, string resp, List<string> category, bool isAnswerVisible)
        {
            Id = id;
            Quest = quest;
            Resp = resp;
            Category = category;
            IsAnswerVisible = isAnswerVisible;
        }
    }
}
