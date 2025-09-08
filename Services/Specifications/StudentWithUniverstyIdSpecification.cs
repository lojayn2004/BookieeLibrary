

namespace Services.Specifications
{
    public class StudentWithUniverstyIdSpecification : Specification<Student>
    {
        public StudentWithUniverstyIdSpecification(string studentId): base(s => s.UniverstyId == studentId)
        {
            
        }

        public StudentWithUniverstyIdSpecification(Expression<Func<Student, bool>>? Criteria) : base(Criteria)
        {
        }
    }
}
