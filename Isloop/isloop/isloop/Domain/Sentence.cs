using System.Collections.Generic;

namespace Domain
{
    public class Sentence
    {
        private Rule nextRule;
        public string Id { get; set; }

        public Sentence(Rule nextRule, string id)
        {
            this.nextRule = nextRule;
            Id = id;
        }

        public Sentence(Rule nextRule) : this(nextRule, nextRule.Id) { }

        public bool Validate()
        {
            var ruleIdList = new List<string>();
            return nextRule.Validate(ruleIdList);
        }

        public bool Validate(IList<string> ruleIdList)
        {
            if (ruleIdList.Contains(nextRule.Id)) return false;
            if (nextRule.hasNoSentences()) return true;
            return nextRule.Validate(ruleIdList);
        }

    }
}
