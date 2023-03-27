using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace KnowlageBase.Pages
{
    public partial class Index : ComponentBase
    {

        private readonly Dictionary<string, List<bool>> _rules = new()
        {
            {"Whitesnow", new List<bool> {true, true, false, false, false}},
            {"Shrek", new List<bool> {false, false, true, false, true}},
            {"Aladdin", new List<bool> {false, true, false, false, false}},
            {"Carlson", new List<bool> {false, true, false, true, true}},
            {"Spongebob", new List<bool> {false, false, false, false, true}},
            {"FairyDinDin", new List<bool> {true, true, false, true, true}}
        };

        private readonly List<string> _questions = new()
        {
            "Is the character a woman?",
            "Is the character a person?",
            "Is the character an animal?",
            "Is the character flying in the air?",
            "Is the character a fictional creature?"
        };

        private List<bool> _answers { get; set; } = new();
        private string _character;
        private void HandleAnswer(bool answer)
        {
            if(_answers.Count == _questions.Count)
                return;
            _answers.Add(answer);
            if (_answers.Count == _questions.Count)
                ProcessResult();
            
        }

        private void ProcessResult()
        {
            var result = new Dictionary<string, int>()
            {
                {"Whitesnow", 0},
                {"Shrek", 0},
                {"Aladdin", 0},
                {"Carlson", 0},
                {"Spongebob", 0},
                {"FairyDinDin", 0}
            };
            for (var i = 0; i < _answers.Count; i++)
            {
                foreach (var (key, value) in _rules)
                {
                    if (value[i] == _answers[i])
                        result[key]++;
                }
            }
            _character = result.OrderByDescending(i => i.Value).FirstOrDefault().Key;
        }

        private void Reset()
        {
            _answers = new();
            _character = string.Empty;
            
        }
    }
}