namespace Novit.Academia.Endpoints.DTO;

public class UsuarioDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UsuarioRegisterDto : UsuarioDto
{
    public string Role { get; set; } = string.Empty;
}

public class UsuarioReservaDto
{
    public string Username { get; set; } = string.Empty;
}

public class UsuarioReservaRequestDto
{
    public string Username { get; set; } = string.Empty;
}

public class UsuarioReservaResponseDto
{
    public string Username { get; set; } = string.Empty;
}