using System.Globalization;

namespace backend.Data.Models.Get
{
    public class GradeGetModel
    {
        public int Grade { get; set; }

        public string GradeName { get; set;}

        
        public GradeGetModel(int grade)
        {
            this.Grade = grade;
            this.GradeName = ToCardinal();
        }

        public string ToCardinal()
        {
            string[] ordinals = { "Zeroth", "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth",
                              "Eleventh", "Twelfth" };

            return ordinals[Grade];
        }
    }
}
