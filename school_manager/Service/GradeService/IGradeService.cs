using school_manager.Controllers;
using school_manager.DTOs.GradeDTO;

namespace school_manager.Service.GradeService
{
    public interface IGradeService
    {
        Task<ServiceResponse<List<GetGrade>>> GetGrades();
        Task<ServiceResponse<GetGrade>> GetGrade(int id);
        Task<ServiceResponse<List<GetGrade>>> GetGradeByStudent(int studentId);
        Task<ServiceResponse<List<GetGrade>>> GetGradeByTeacher(int teacherId);
        Task<ServiceResponse<List<GetGrade>>> GetGradeBySubject(int subjectId);
        Task<ServiceResponse<List<GetGrade>>> AddGrade(AddGrade addGrade);
        Task<ServiceResponse<List<GetGrade>>> UpdateGrade(UpdateGrade updateGrade);
        Task<ServiceResponse<List<GetGrade>>> DeleteGrade(int GradeId);
    }
}
