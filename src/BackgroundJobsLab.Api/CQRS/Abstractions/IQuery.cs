using FluentResults;
using MediatR;

namespace BackgroundJobsLab.Api.CQRS.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
