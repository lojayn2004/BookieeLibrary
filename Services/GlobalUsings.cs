
global using Domain.Exceptions.Users;
global using Domain.Models.Users;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using ServicesAbstraction.UserServices;
global using Shared;
global using Shared.Dtos;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;


global using AutoMapper;
global using Domain.Contracts;

global using Domain.Exceptions.Book;
global using Domain.Models.Books;
global using Services.Specifications;
global using ServicesAbstraction.BookServices;
global using ServicesAbstraction.GeneralServices;

global using Shared.Dtos.Books;

global using Shared.Dtos.Category;
global using Domain.Exceptions.Category;
global using Domain.Exceptions.General;
global using Microsoft.AspNetCore.Http;

global using Services.BookServices;
global using Services.UserServices;
global using Microsoft.Extensions.Configuration;
global using System.Linq.Expressions;