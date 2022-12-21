using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1221.Models.EFModels;

namespace WebApplication1221.Models.DTOs
{
    public class MemberCreateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string CellPhone { get; set; }
    }
    public static class MemberExtensions
    {
        public static MemberCreateDTO ToDTO(this Member source)
        {
            return new MemberCreateDTO
            {
                Id = source.Id,
                Name = source.Name,
                Account = source.Account,
                Password = source.Password,
                CellPhone = source.CellPhone,
            };
        }
    }
}