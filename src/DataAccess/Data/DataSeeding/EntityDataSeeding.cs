using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.DataSeeding;

/// <summary>
///     Represent data seeding for database.
/// </summary>
public static class EntityDataSeeding
{
    private static readonly Guid AdminId = Guid.Parse(
        input: "2ed6fb47-86a6-46e3-a9dc-ff5b3d986c2f"
    );

    /// <summary>
    ///     Seed data.
    /// </summary>
    /// <param name="context">
    ///     Database context for interacting with other table.
    /// </param>
    /// <param name="userManager">
    ///     Specific manager for interacting with user table.
    /// </param>
    /// <param name="roleManager">
    ///     Specific manager for interacting with role table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     True if seeding is success. Otherwise, false.
    /// </returns>

    public static async Task<bool> SeedAsync(
        DatabaseContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        CancellationToken cancellationToken
    )
    {
        var userDetails = context.Set<UserDetail>();
        var roles = context.Set<Role>();

        // Is tables empty.
        var isTableEmpty = await IsTableEmptyAsync(
            userDetails: userDetails,
            roles: roles,
            cancellationToken: cancellationToken
        );

        if (!isTableEmpty)
        {
            return true;
        }

        // Init list of role.
        var newRoles = InitNewRoles();

        // Init admin.
        var admin = InitAdmin();

        #region Transaction
        var executedTransactionResult = false;

         await context
            .Database.CreateExecutionStrategy()
            .ExecuteAsync(operation: async () =>
            {
                await using var dbTransaction = await context.Database.BeginTransactionAsync(
                    cancellationToken: cancellationToken
                );

                try
                {
                    foreach (var newRole in newRoles)
                    {
                        await roleManager.CreateAsync(role: newRole);
                    }

                    await userManager.CreateAsync(user: admin, password: "password");

                    await userManager.AddToRoleAsync(user: admin, role: "admin");

                    var emailConfirmationToken =
                        await userManager.GenerateEmailConfirmationTokenAsync(user: admin);

                    await userManager.ConfirmEmailAsync(user: admin, token: emailConfirmationToken);

                    await context.SaveChangesAsync(cancellationToken: cancellationToken);

                    await dbTransaction.CommitAsync(cancellationToken: cancellationToken);

                    executedTransactionResult = true;
                }
                catch
                {
                    await dbTransaction.RollbackAsync(cancellationToken: cancellationToken);
                }
            });
        #endregion

        return executedTransactionResult;
    }

    private static async Task<bool> IsTableEmptyAsync(
        DbSet<UserDetail> userDetails,
        DbSet<Role> roles,
        CancellationToken cancellationToken
    )
    {
        // Is user details table empty.
        var isTableNotEmpty = await userDetails.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        // Is roles table empty.
        isTableNotEmpty = await roles.AnyAsync(cancellationToken: cancellationToken);

        if (isTableNotEmpty)
        {
            return false;
        }

        return true;
    }

    private static List<Role> InitNewRoles()
    {
        Dictionary<Guid, string> newRoleNames = [];

        newRoleNames.Add(
            key: Guid.Parse(input: "c39aa1ac-8ded-46be-870c-115b200b09fc"),
            value: "user"
        );

        newRoleNames.Add(
            key: Guid.Parse(input: "c8500b46-b134-4b60-85b7-8e6af1187e0c"),
            value: "admin"
        );

        List<Role> newRoles = [];

        foreach (var newRoleName in newRoleNames)
        {
            Role newRole =
                new()
                {
                    Id = newRoleName.Key,
                    Name = newRoleName.Value,
                    RoleDetail = new()
                    {
                        RoleId = newRoleName.Key,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = AdminId,
                        UpdatedAt = DateTime.MinValue,
                        UpdatedBy = Guid.Parse(input: "c8500b46-b134-4b60-85b7-8e6af1187e1c"),
                        RemovedAt = DateTime.MinValue,
                        RemovedBy = Guid.Parse(input: "c8500b46-b134-4b60-85b7-8e6af1187e1c")
                    }
                };

            newRoles.Add(item: newRole);
        }

        return newRoles;
    }

    private static User InitAdmin()
    {
        User admin =
            new()
            {
                Id = AdminId,
                UserName = "admin",
                Email = "nvdatdz8b@gmail.com",
                UserDetail = new()
                {
                    UserId = AdminId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = AdminId,
                    RemovedAt = DateTime.MinValue,
                    RemovedBy = Guid.Parse(input: "c8500b46-b134-4b60-85b7-8e6af1187e1c"),
                    UpdatedAt = DateTime.MinValue,
                    UpdatedBy = Guid.Parse(input: "c8500b46-b134-4b60-85b7-8e6af1187e1c"),
                    FirstName = "Nguyen",
                    LastName = "Dat",
                    AvatarUrl = "url.com/img",
                }
            };

        return admin;
    }
}
