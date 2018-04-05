using OneOhOne.Models;

namespace OneOhOne.Dtos
{
    public class RecordDto
    {
        public RecordDto()
        {
        }

        public RecordDto(Record record)
        {
            
        }

        public long Id { get; set; }

        public Record AsRecord()
        {
            return new Record();
        }
    }
}