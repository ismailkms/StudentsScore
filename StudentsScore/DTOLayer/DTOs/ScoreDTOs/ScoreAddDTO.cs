﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ScoreDTOs
{
    public class ScoreAddDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int UserScore { get; set; }
    }
}
