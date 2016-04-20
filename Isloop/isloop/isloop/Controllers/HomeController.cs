using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isloop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult VerifyLoop(string txt)
        {
            var validator = GetPopulatedValidator(txt);
            txt = validator.Validate();
            return Json(new { txt = txt });
        }

        private Rule GetRuleFromCode(string code)
        {
            string[] parts = code.Split(':');
            var rule = new Rule(parts[0]);
            return rule;
        }

        private void CreateSentences(string code, IList<Rule> rules)
        {
            string[] parts = code.Split(':');
            var rule = rules.First(r => r.Id.Equals(parts[0]));
            if (parts.Length >= 2)
            {
                string[] sentences = parts[1].Split(',');
                foreach (var sentence in sentences)
                {
                    string[] aux = sentence.Split('-');
                    var nextRule = rules.First(r => r.Id.Equals(aux[1]));
                    rule.Add(new Sentence(nextRule, aux[0]));
                }
            }
        }

        private Validator GetPopulatedValidator(string encodedRules)
        {
            IList<Rule> rules = new List<Rule>();
            string[] codedRules = encodedRules.Split('&');
            foreach (var codedRule in codedRules)
            {
                rules.Add(GetRuleFromCode(codedRule));
            }

            foreach (var codedRule in codedRules)
            {
                CreateSentences(codedRule, rules);
            }

            foreach (var codedRule in codedRules)
            {
                InitializeDefaultRules(codedRule, rules);
            }

            var validator = new Validator() { Rules = rules };

            return validator;
        }

        private void InitializeDefaultRules(string code, IList<Rule> rules)
        {
            string[] parts = code.Split(':');
            var rule = rules.First(r => r.Id.Equals(parts[0]));
            if (parts.Length >= 3)
            {
                var defaultRule = rules.First(r => r.Id.Equals(parts[2]));
                rule.sentences.Add(new Sentence(defaultRule));
            }
        }
    }
}