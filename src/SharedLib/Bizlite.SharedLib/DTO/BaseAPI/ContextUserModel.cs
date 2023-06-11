﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.SharedLib.DTO.BaseAPI
{  
    public class ContextUserModel
    {
        public Guid Id { get; private set; }
        public string AccessToken { get; private set; } = string.Empty;
        public int[] Roles { get; private set; } = new int[0];
        public int UserType { get; private set; }
        public Guid BusinessId { get; private set; }

        public ContextUserModel(Guid id, string accessToken)
        {
            Id = id;
            AccessToken = accessToken;
        }

        public ContextUserModel(Guid id, string accessToken, int[] roles, int type, Guid businessId)
        {
            Id = id;
            AccessToken = accessToken;
            Roles = roles;
            UserType = type;
            BusinessId = businessId;
        }
    }
}
