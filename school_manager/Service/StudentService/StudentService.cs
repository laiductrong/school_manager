using AutoMapper;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using school_manager.Controllers;
using school_manager.Data;
using school_manager.DTOs.StudentDTO;
using school_manager.Models;

namespace school_manager.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public StudentService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetStudent>>> AddStudent(AddStudent student)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            //var studentAdd = new Student
            //{
            //    Name = student.Name,
            //    Address = student.Address,
            //    BirthDate = student.BirthDate,
            //    PhoneNumber = student.PhoneNumber,
            //    Email = student.Email,
            //    ClassId = student.ClassId
            //};

            try
            {
                var addStudent = _mapper.Map<Student>(student);
                await _dataContext.Student.AddAsync(addStudent);
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s=>s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Get Success";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Add Success but Error Get Students";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> DeleteStudent(int id)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var studentDelete = await _dataContext.Student.Include(s => s.Class).FirstOrDefaultAsync(s => s.StudentId == id);
                if (studentDelete is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                _dataContext.Student.Remove(studentDelete);
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Delete Success";
                    return response;
                }
                catch (Exception ex)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> GetAll()
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                if (dataStudent is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Get Students Fail";
                    return response;
                }
                response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Success = true;
                response.Message = "Get Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
        public async Task<ServiceResponse<PaginatedList<GetStudent>>> GetAllByPage(int pageIndex, int pageSize)
        {
            var response = new ServiceResponse<PaginatedList<GetStudent>>();
            try
            {
                // Lấy dữ liệu sinh viên với phân trang
                var dataStudent = await _dataContext.Student
                    .Include(s => s.Class)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Lấy tổng số sinh viên để tính toán phân trang
                var totalCount = await _dataContext.Student.CountAsync();

                if (dataStudent is null || !dataStudent.Any())
                {
                    response.Data = new PaginatedList<GetStudent>(new List<GetStudent>(), totalCount, pageIndex, pageSize);
                    response.Success = true;
                    response.Message = "No students found.";
                    return response;
                }

                // Chuyển đổi dữ liệu sang DTO
                var mappedStudents = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Data = new PaginatedList<GetStudent>(mappedStudents, totalCount, pageIndex, pageSize);
                response.Success = true;
                response.Message = "Get Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }


        public async Task<ServiceResponse<GetStudent>> GetById(int id)
        {
            var response = new ServiceResponse<GetStudent>();
            try
            {
                var dataStudent = await _dataContext.Student
                    .Include(s => s.Class)
                    .FirstOrDefaultAsync(s => s.StudentId == id);
                if (dataStudent is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                response.Data = _mapper.Map<GetStudent>(dataStudent);
                response.Success = true;
                response.Message = "Find Student Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
        public async Task<ServiceResponse<List<GetStudent>>> GetByName(string name)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudents = await _dataContext.Student
                    .Include(s => s.Class)
                    .Where(s => s.Name.ToLower().Contains(name.ToLower()))                    // Tìm kiếm theo tên
                    .ToListAsync();

                if (dataStudents == null || !dataStudents.Any())
                {
                    response.Data = new List<GetStudent>(); // Trả về danh sách rỗng
                    response.Success = true;
                    response.Message = "No students found with the given name.";
                    return response;
                }

                response.Data = dataStudents.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Success = true;
                response.Message = "Find Students Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
        public async Task<ServiceResponse<List<GetStudent>>> GetAllSorted(bool sortAscending = true)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudents = await _dataContext.Student
                    .Include(s => s.Class)
                    .ToListAsync();

                if (dataStudents == null || !dataStudents.Any())
                {
                    response.Data = new List<GetStudent>();
                    response.Success = true;
                    response.Message = "No students found.";
                    return response;
                }

                // Sắp xếp danh sách sinh viên theo tên
                response.Data = sortAscending
                    ? dataStudents.OrderBy(s => s.Name).Select(s => _mapper.Map<GetStudent>(s)).ToList()
                    : dataStudents.OrderByDescending(s => s.Name).Select(s => _mapper.Map<GetStudent>(s)).ToList();

                response.Success = true;
                response.Message = "Students retrieved and sorted successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }



        public async Task<ServiceResponse<List<GetStudent>>> GetStudentByClass(int classId)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataStudent = await _dataContext.Student
                    .Include(s => s.Class)
                    .Where(s => s.ClassId == classId).ToListAsync();
                if (dataStudent is null || !dataStudent.Any())
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Don't have Students";
                    return response;
                }
                response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                response.Success = true;
                response.Message = "Find Success";
                return response;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error finding Students";
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudent>>> UpdateStudent(UpdateStudent student)
        {
            var response = new ServiceResponse<List<GetStudent>>();
            try
            {
                var dataUpdate = await _dataContext.Student
                    .Include(s => s.Class)
                    .FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
                if (dataUpdate is null)
                {
                    response.Data = null;
                    response.Success = true;
                    response.Message = "Can't find id";
                    return response;
                }
                dataUpdate.Name = student.Name;
                dataUpdate.Address = student.Address;
                dataUpdate.BirthDate = student.BirthDate;
                dataUpdate.PhoneNumber = student.PhoneNumber;
                dataUpdate.Email = student.Email;
                dataUpdate.ClassId = student.ClassId;
                await _dataContext.SaveChangesAsync();

                try
                {
                    var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();
                    if (dataStudent is null)
                    {
                        response.Data = null;
                        response.Success = true;
                        response.Message = "Get Students Fail";
                        return response;
                    }
                    response.Data = dataStudent.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    response.Success = true;
                    response.Message = "Get Success";
                    return response;
                }
                catch (Exception)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Update Success but Error Get";
                    return response;
                }
            }
            catch (Exception)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Error Update Student";
                return response;
            }
        }
        public async Task<ServiceResponse<string>> ExportStudentsToExcel()
        {
            var response = new ServiceResponse<string>();
            try
            {
                var dataStudent = await _dataContext.Student.Include(s => s.Class).ToListAsync();

                if (dataStudent is null || !dataStudent.Any())
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "No students found";
                    return response;
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExportedStudents.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Students");
                    worksheet.Cell(1, 1).Value = "StudentId";
                    worksheet.Cell(1, 2).Value = "Name";
                    worksheet.Cell(1, 3).Value = "BirthDay";
                    worksheet.Cell(1, 4).Value = "Address";
                    worksheet.Cell(1, 5).Value = "Phone";
                    worksheet.Cell(1, 6).Value = "Email";
                    worksheet.Cell(1, 7).Value = "Class";

                    for (int i = 0; i < dataStudent.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = dataStudent[i].StudentId;
                        worksheet.Cell(i + 2, 2).Value = dataStudent[i].Name;
                        worksheet.Cell(i + 2, 3).Value = dataStudent[i].BirthDate;
                        worksheet.Cell(i + 2, 4).Value = dataStudent[i].Address;
                        worksheet.Cell(i + 2, 5).Value = dataStudent[i].PhoneNumber;
                        worksheet.Cell(i + 2, 6).Value = dataStudent[i].Email;
                        worksheet.Cell(i + 2, 7).Value = dataStudent[i].Class.ClassName;
                    }

                    workbook.SaveAs(filePath);
                }

                response.Data = filePath;
                response.Success = true;
                response.Message = "Students exported to Excel successfully";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<GetStudent>>> GetStudentByAge(int startAge, int endAge)
        {
            var reponse = new ServiceResponse<List<GetStudent>>();
            try {
                var students = await _dataContext.Student
                    .Where(s => EF.Functions.DateDiffYear(s.BirthDate, DateTime.Today) >= startAge &&
                                EF.Functions.DateDiffYear(s.BirthDate, DateTime.Today) <= endAge)
                    .Include(s => s.Class)
                    .ToListAsync();
                if (students.Count > 0) { 
                    reponse.Data = students.Select(s => _mapper.Map<GetStudent>(s)).ToList();
                    reponse.Success = true;
                    reponse.Message = "Find success";
                }
                else
                {
                    reponse.Data = null;
                    reponse.Success = true;
                    reponse.Message = "Don't have student";
                }
            } catch (Exception) {
                reponse.Data = null;
                reponse.Success = true;
                reponse.Message = "Error";
            }
            return reponse;
        }
        public async Task<ServiceResponse<string>> ImportStudentsFromExcelMethod(IFormFile file)
        {
            var response = new ServiceResponse<string>();
            var filePath = "";
            try
            {
                if (file == null || file.Length == 0)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "No file uploaded";
                    return response;
                }

                filePath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);

                // Lưu file tạm thời vào thư mục hiện tại
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Lấy worksheet đầu tiên
                    var rows = worksheet.RowsUsed();

                    List<Student> students = new List<Student>();

                    foreach (var row in rows.Skip(1)) // Bỏ qua hàng đầu tiên (header)
                    {
                        var student = new Student
                        {
                            //StudentId = row.Cell(1).GetValue<int>(),
                            Name = row.Cell(2).GetValue<string>() ?? string.Empty,
                            BirthDate = row.Cell(3).GetValue<DateTime?>(),
                            Address = row.Cell(4).GetValue<string>() ?? string.Empty,
                            PhoneNumber = row.Cell(5).GetValue<string>() ?? string.Empty,
                            Email = row.Cell(6).GetValue<string>() ?? string.Empty,
                            ClassId = row.Cell(7).GetValue<int?>()
                        };

                        students.Add(student);
                    }

                    // Thêm sinh viên vào database
                    await _dataContext.Student.AddRangeAsync(students);
                    await _dataContext.SaveChangesAsync();
                }

                response.Data = "Import successful";
                response.Success = true;
                response.Message = "Students imported successfully from Excel";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            finally
            {
                // Xóa file tạm sau khi xử lý xong
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            return response;
        }



    }

}
