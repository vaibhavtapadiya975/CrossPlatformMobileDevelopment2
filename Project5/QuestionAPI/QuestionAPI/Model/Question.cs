﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuestionAPI.Model
{
    public class Question
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string question { get; set; }

        [Required]
        public string option1 { get; set; }

        [Required]
        public string option2 { get; set; }

        [Required]
        public string option3 { get; set; }

        [Required]
        public string answer { get; set; }
    }
}
