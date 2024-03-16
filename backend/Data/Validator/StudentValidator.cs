using backend.Data.Models.Post;

namespace backend.Data.Validator
{
    public class StudentValidator
    {

        public void ValidateStudentPostModel(StudentPostModel model)
        {
            if (model.Name == null || model.NameOfFather == null || model.NameOfMother == null || model.Section == null)
              throw new Exception("Name, NameOfFather, NameOfMother, and Section are required fields");
            
            if (model.Grade < 1 || model.Grade > 12)
               throw new Exception("Grade must be between 1 and 12");
        }
    }
}
