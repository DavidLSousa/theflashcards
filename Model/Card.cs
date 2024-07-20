using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace theflashcards.Model
{
    public class Card
    {
        public Guid Id { get; private set; }
        public string Quest { get; set; }
        public string Resp { get; set; }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value.ToLower(); }
        }

        private bool _isAnswerVisible;
        public bool IsAnswerVisible
        {
            get { return _isAnswerVisible; }
            set
            {
                _isAnswerVisible = value;
                OnPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
