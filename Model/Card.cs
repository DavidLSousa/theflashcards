using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace theflashcards.Model
{
    public partial class Card : ObservableObject
    {
        public Guid Id { get; private set; }
        public string Quest { get; set; }
        public string Resp { get; set; }

        private string _category;
        public string Category
        {
            get { return _category; }
            set 
            {
                _category = value.ToLower();
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
        public Card(Guid id, string quest, string resp, string category, bool isAnswerVisible)
        {
            Id = id;
            Quest = quest;
            Resp = resp;
            Category = category;
            IsAnswerVisible = isAnswerVisible;
        }
    }
}
