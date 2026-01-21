using Microsoft.Extensions.DependencyInjection;
using QuizBattle.Application.Interfaces;
using QuizBattle.Application.Services;

namespace QuizBattle.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddSingleton<ISessionService, SessionService>();

            return services;
        }
    }
}
