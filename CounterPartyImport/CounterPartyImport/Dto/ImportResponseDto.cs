using System.Collections.Generic;

namespace CounterPartyImport.Dto
{
    public class ImportResponseDto
    {
        public ImportResponseDto()
        {
            Errors = new List<string>();
        }

        public int ImportCount { get; set; }
        public List<string> Errors { get; set; }
    }
}
