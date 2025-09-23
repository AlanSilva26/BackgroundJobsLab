using FluentResults;
using MediatR;

namespace BackgroundJobsLab.Api.CQRS.Abstractions;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }

public interface ICommand : IRequest<Result> { }
