using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoloclinicWebAPI.Dtos.Diagnoses
{
    public class DiagnosisReadDto
    {
        public int Id { get; set; }
        public string CodeMrb10 { get; set; }
        public string Diagnosis1 { get; set; }
    }
}
