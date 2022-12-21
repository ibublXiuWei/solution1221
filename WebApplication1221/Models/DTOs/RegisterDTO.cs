using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1221.Models.EFModels;

namespace WebApplication1221.Models.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedTime { get; set; }
    }
    public static class RegisterExtensions
    {
        public static RegisterDTO EntityToDTO(this Register source)
        {
            return new RegisterDTO
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                CreatedTime = DateTime.Now,
            };
        }
    }
}