using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Common;

namespace DataAccess.Data.DataSeeding
{
    internal static class EntityDataSeedingModelBuilder
    {
        private static readonly Guid AdminId = Guid.Parse(
            input: "2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"
        );

        public static void Seed(ModelBuilder modelBuilder)
        {
            //Init list roles
            var roles = InitRoles();

            //Init admin
            var admin = InitAdmin();

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<RoleDetail>().HasData(InitRoleDetail());
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<UserDetail>().HasData(InitUserDetail());
        }

        private static List<Role> InitRoles()
        {
            Dictionary<Guid, string> newRoleNames = new Dictionary<Guid, string>();

            newRoleNames.Add(
                key: Guid.Parse("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                value: "user"
            );

            newRoleNames.Add(
                key: Guid.Parse("c8500b46-b134-4b60-85b7-8e6af1187e0c"),
                value: "admin"
            );

            List<Role> newRoles = [];

            foreach (var newRoleName in newRoleNames)
            {
                Role newRole = new() { Id = newRoleName.Key, Name = newRoleName.Value };

                newRoles.Add(newRole);
            }
            return newRoles;
        }

        private static List<RoleDetail> InitRoleDetail()
        {
            Dictionary<Guid, string> newRoleNames = new Dictionary<Guid, string>();

            newRoleNames.Add(
                key: Guid.Parse("c39aa1ac-8ded-46be-870c-115b200b09fc"),
                value: "user"
            );

            newRoleNames.Add(
                key: Guid.Parse("c8500b46-b134-4b60-85b7-8e6af1187e0c"),
                value: "admin"
            );

            List<RoleDetail> newRoleDetails = [];

            foreach (var newRoleName in newRoleNames)
            {
                RoleDetail newRole =
                    new()
                    {
                        RoleId = newRoleName.Key,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = AdminId,
                        UpdatedAt = DateTime.MinValue,
                        UpdatedBy = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID,
                        RemovedAt = DateTime.MinValue,
                        RemovedBy = CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                    };

                newRoleDetails.Add(newRole);
            }

            return newRoleDetails;
        }

        private static UserDetail InitUserDetail()
        {
            UserDetail userDetail = new UserDetail
            {
                UserId = AdminId,
                FirstName = "Nguyen",
                LastName = "Dat",
                AvatarUrl = "url.com/img",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = AdminId,
                UpdatedAt = DateTime.MinValue,
                UpdatedBy = Guid.Parse("c8500b46-b134-4b60-85b7-8e6af1187e1c"),
                RemovedAt = DateTime.MinValue,
                RemovedBy = Guid.Parse("c8500b46-b134-4b60-85b7-8e6af1187e1c")
                // Add other properties as needed
            };

            return userDetail;
        }

        private static User InitAdmin()
        {
            User admin = new User
            {
                Id = AdminId,
                UserName = "admin",
                Email = "nvdatdz8b@gmail.com"
            };

            return admin;
        }
    }
}
