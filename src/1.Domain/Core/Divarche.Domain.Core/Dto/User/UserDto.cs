﻿using Divarcheh.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;

namespace Divarcheh.Domain.Core.Dto.User
{
    public class UserDto
    {
        #region Properties

        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? RePassword { get; set; }
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public RoleEnum Role { get; set; }
        public IFormFile? ProfileImgFile { get; set; }

        public string? ImagePath { get; set; }
        #endregion

    }
}
