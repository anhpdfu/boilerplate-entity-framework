﻿namespace Boilerplate.Shared.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
