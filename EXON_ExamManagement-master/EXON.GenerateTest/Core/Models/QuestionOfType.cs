namespace EXON.GenerateTest.Core.Models
{
    public class QuestionOfType
    {
        /// <summary>
        /// ID kiểu câu hỏi
        /// </summary>
        public int QuestionTypeID;

        /// <summary>
        /// Số câu hỏi hiện có của loại câu hỏi này
        /// (Lấy theo một chủ đề xác định)
        /// </summary>
        public int NumOfQuestion = 0;

        /// <summary>
        /// Số câu hỏi con của kiểu câu hỏi
        /// </summary>
        public int NumOfSubQestion = 0;

        /// <summary>
        /// Số câu  hỏi cần phải lấy
        /// </summary>
        public int NumOfQestionGet = 0;  
    }
}