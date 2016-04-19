using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sentence
    {
        private Rule nextRule;
        private string id;

        public Sentence(Rule nextRule, string id)
        {
            this.nextRule = nextRule;
            this.id = id;
        }

        public bool Validate()
        {
            var ruleIdList = new List<string>();
            return nextRule.Validate(ruleIdList);
        }

        public bool Validate(IList<string> ruleIdList) {
            if(ruleIdList.Contains(nextRule.Id)) return false;
            if (nextRule.hasNoSentences()) return true;
            return nextRule.Validate(ruleIdList);
        }

    }
}
