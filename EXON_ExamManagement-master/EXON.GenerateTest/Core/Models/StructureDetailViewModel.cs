namespace EXON.GenerateTest.Core.Models
{
    public class StructureDetailViewModel
    {
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Level4 { get; set; }

        public int ParSubjectID { get; set; }
        public int PartOrderInTest { get; set; }

        public int OrderOfTopic { get; set; }
    }
}