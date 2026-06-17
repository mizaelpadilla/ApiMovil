using ApiMovil.Data;
using ApiMovil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMovil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequest request
        )
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.UsuarioNombre == request.Usuario &&
                    u.Clave == request.Clave
                );

            if (usuario == null)
            {
                return Unauthorized(
                    new { mensaje = "Credenciales incorrectas" }
                );
            }

            return Ok(new
            {
                usuario.IdUsuario,
                usuario.UsuarioNombre,
                usuario.Rol
            });
        }
    }
}