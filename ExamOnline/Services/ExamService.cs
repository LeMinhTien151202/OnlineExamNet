using ExamOnline.Dtos;
using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExamOnline.Interfaces.ILevel;
using ExceptionHandleDemo.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Services
{
    public class ExamService : IExamService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ExamService(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        } 
        public async Task<Exam?> CreateExamAsync(ExamDTO examDTO)
        {
            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(examDTO.CategoryId);
            if (existingCategory == null)
            {
                throw new BadRequestException($"Category with ID {examDTO.CategoryId} does not exist.");
            }
            var existingLevel = await _unitOfWork.Levels.GetByIdAsync(examDTO.LevelId);
            if (existingLevel == null)
            {
                throw new BadRequestException($"Level with ID {examDTO.LevelId} does not exist.");
            }

            var exam = await UploadPictures(examDTO);
            if (exam == null)
            {
                throw new BadRequestException("Failed to upload picture.");
            }
            var createdExam = await _unitOfWork.Exams.CreateAsync(exam);
            return createdExam;
        }

        public async Task<Exam?> UploadPictures(ExamDTO examDTO)
        {
            if (examDTO.Pictures == null || examDTO.Pictures.Length == 0)
            {
                throw new BadRequestException("Vui lòng tải lên một tệp ảnh.");
            }
            // Tạo thư mục nếu nó chưa tồn tại
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tạo tên tệp tin duy nhất
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + examDTO.Pictures.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Lưu tệp tin vào thư mục
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await examDTO.Pictures.CopyToAsync(fileStream);
            }

            // Tạo đối tượng Exam và lưu vào DB
            var exam = new Exam
            {
                CategoryId = examDTO.CategoryId,
                LevelId = examDTO.LevelId,
                ExamName = examDTO.ExamName,
                Pictures = $"/images/{uniqueFileName}"
            };
            return exam;
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            return await _unitOfWork.Exams.DeleteAsync(id);
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            var exams = await _unitOfWork.Exams.GetAllAsync();
            return exams;
        }

        public async Task<Exam?> GetExamByIdAsync(int id)
        {
           var exam = await _unitOfWork.Exams.GetByIdAsync(id);
            if (exam == null)
            {
                return null; // Exam not found
            }
            return exam;
        }
        public async Task<Exam?> UpdateExamAsync(int id, ExamDTO examDTO)
        {
            var existingCategory = await _unitOfWork.Categories.GetByIdAsync(examDTO.CategoryId);
            if (existingCategory == null)
            {
                throw new BadRequestException($"Category with ID {examDTO.CategoryId} does not exist.");
            }
            var existingLevel = await _unitOfWork.Levels.GetByIdAsync(examDTO.LevelId);
            if (existingLevel == null)
            {
                throw new BadRequestException($"Level with ID {examDTO.LevelId} does not exist.");
            }
            var existingExam = await _unitOfWork.Exams.GetByIdAsync(id);
            if (existingExam == null)
            {
                return null;
            }
            _mapper.Map(examDTO, existingExam);
            var updatedExam = await _unitOfWork.Exams.UpdateAsync(existingExam);
            return updatedExam;
        }
    }
}
