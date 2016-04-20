using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Validator
    {
        public IList<Rule> Rules { get; set; }

        public Validator()
        { }

        public string Validate()
        {
            string nl = Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            foreach(var rule in Rules)
            {
                sb.Append(rule.Id);
                sb.Append(nl);
                foreach(var sentence in rule.sentences)
                {
                    sb.Append("&nbsp;&nbsp;&nbsp;");
                    sb.Append(sentence.Id);
                    if (sentence.Validate()) sb.Append(" - OK");
                    else sb.Append(" - LOOP");
                    sb.Append(nl);
                }
                sb.Append(nl);
            }
            return sb.ToString();
        }
    }
}
