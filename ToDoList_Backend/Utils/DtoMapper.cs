using to_do_list.Models;

namespace to_do_list.Utils
{
    public static class DtoMapper
    {
        public static TaskModel ToModel(this TaskDto dto)
        {
            return new TaskModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted
            };
        }

        public static TaskDto ToDto(this TaskModel model)
        {
            return new TaskDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                DueDate = model.DueDate,
                IsCompleted = model.IsCompleted
            };
        }
    }
}
