using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.Models
{
    public class QuestionModel : BaseModel
    {
        public string Question { get; set; }

        public List<AnswerModel> AnswerList { get; set; }
    }
}
