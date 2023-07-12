using Application.Commands.Common;

namespace Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<string>;


