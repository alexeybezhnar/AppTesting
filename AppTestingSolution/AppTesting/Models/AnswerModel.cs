using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.Models
{
    public class AnswerModel : BaseModel
    {
        public string Answer { get; set; }

        public bool Right { get; set; }
    }
}
