using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1221.Models.VM
{
    public class MemberCreateVM
    {
        public int Id { get; set; }

        [Display(Name="中文姓名")]

        [Required(ErrorMessage="{0}必填")]
        [StringLength(30,ErrorMessage="{0}長度不能超過{1}個字")]
        public string Name { get; set; }

        [Display(Name = "帳號")]
        [Required]
        [StringLength(30)]
        public string Account { get; set; }
        [Display(Name = "密碼")]
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Display(Name = "確認密碼")]
        [Required]
        [StringLength(30)]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        [Display(Name = "手機")]
        [StringLength(10)]
        public string CellPhone { get; set; }
    }
}