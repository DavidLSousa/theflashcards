using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theflashcards.Model
{
    public class Cards
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

        public Cards()
        {
            Id = Guid.NewGuid();
        }
    }
}
