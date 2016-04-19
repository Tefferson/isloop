using System.Collections.Generic;

namespace Domain
{
    public class Rule
    {
        public IList<Sentence> sentences { get; set; }
        public string Id { get; set; }

        public Rule(string id)
        {
            Id = id;
            sentences = new List<Sentence>();
        }

        public void Add(Sentence sentence) {
            sentences.Add(sentence);
        }

        public bool Validate(IList<string> ruleIdList)
        {
            ruleIdList.Add(Id);
            foreach(var sentence in sentences)
            {
                if (!sentence.Validate(ruleIdList)) return false;
            }

            return true;
        }

        public bool hasNoSentences()
        {
            return sentences.Count==0;
        }

    }
}
