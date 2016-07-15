using System.Collections.Generic;

namespace Academic_Bot.EntityModel
{

    public class Output
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Rule
    {
        public string name { get; set; }
        public Output output { get; set; }
    }

    public class Interpretation
    {
        public double logprob { get; set; }
        public string parse { get; set; }
        public List<Rule> rules { get; set; }
    }

    public class AcademicResult
    {
        public string query { get; set; }
        public List<Interpretation> interpretations { get; set; }
    }

    public class Result
    {
        public double logprob { get; set; }
        public long Id { get; set; }
        public string E { get; set; }
    }

    public class EvaluateResult
    {
        public string expr { get; set; }
        public List<Result> entities { get; set; }
    }

    public class S
    {
        public int Ty { get; set; }
        public string U { get; set; }
    }

    public class EX
    {
        public string DN { get; set; }
        public List<S> S { get; set; }
    }

    public class Item
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}