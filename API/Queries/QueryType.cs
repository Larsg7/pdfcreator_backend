﻿using System;
using System.Linq;
using API.Contexts;
using API.Models;
using API.Services;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Queries
{
    public class QueryType : ObjectGraphType
    {
        internal static IServiceProvider ServiceProvider { get; set; }

        public QueryType()
        {
            Name = "query";
            UserService userService = ServiceProvider.GetService<UserService>();
            TemplateService templateService = ServiceProvider.GetService<TemplateService>();

            Field<UserType>("user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: userService.GetUser);

            Field<UserType>("activeUser",
                resolve: userService.GetActiveUser);

            Field<TemplateType>("template",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: templateService.GetTemplate);
        }
    }
}