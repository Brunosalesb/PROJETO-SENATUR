﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using Senai.Senatur.WebApi.ViewsModels;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult BuscarPorEmailESenha(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = UsuarioRepository.BuscarPorEmailESenha(login.Email, login.Senha);
                if (usuario == null)
                {
                    return NotFound();
                }

                var claims = new[]
                {
                    // são as propriedades (atributos) referentes aos usuários - admin@admin.com -- 1
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "senatur",
                        audience: "senatur",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(59),
                        signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}