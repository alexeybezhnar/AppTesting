using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.Models
{
    public class TestModel : BaseModel
    {
        public string TestName { get; set; }

        public List<QuestionModel> QuestionList { get; set; }

    }
}
