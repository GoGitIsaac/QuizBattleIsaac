# QuizBattle – Namespace, typer och metodsignaturer

Fokus på **Application- och API-lager**.

---

## QuizBattle.Domain

**Typer/Filer:**
- `Question.cs` → `Question`
  - `string Code { get; }`
  - `string Text { get; }`
  - `List<Choice> Choices { get; }`
  - `string CorrectAnswerCode { get; }`
  - `bool IsCorrect(string selectedChoiceCode)`

- `Choice.cs` → `Choice`
  - `Guid Id { get; }`
  - `string Code { get; }`
  - `string Text { get; }`

- `DomainException.cs` → `DomainException`

---

## QuizBattle.Application.Interfaces

**Typer/Filer:**
- `IQuestionRepository.cs` → `IQuestionRepository`
  - `Task<IReadOnlyList<Question>> GetRandomAsync(string? category, int? difficulty, int count, CancellationToken ct)`
  - `Task<Question?> GetByCodeAsync(string code, CancellationToken ct)`

- `ISessionRepository.cs` → `ISessionRepository`
  - `Task<QuizSession> AddAsync(QuizSession session, CancellationToken ct)`
  - `Task<QuizSession?> GetAsync(Guid sessionId, CancellationToken ct)`
  - `Task UpdateAsync(QuizSession session, CancellationToken ct)`

- `QuizSession.cs` → `QuizSession`
  - `Guid Id { get; }`
  - `DateTimeOffset StartedAtUtc { get; }`
  - `DateTimeOffset? FinishedAtUtc { get; }`
  - `int QuestionCount { get; }`
  - `IReadOnlyList<Answer> Answers { get; }`
  - `int Score { get; }`
  - `static QuizSession Start(DateTimeOffset nowUtc, int count)`
  - `void SubmitAnswer(Guid questionId, string selectedChoiceCode, bool isCorrect, DateTimeOffset whenUtc)`
  - `void Finish(DateTimeOffset whenUtc)`

---

## QuizBattle.Application.Models

**Typer/Filer:**
- `Answer.cs` → `Answer`
  - `Guid QuestionId { get; }`
  - `string SelectedChoiceCode { get; }`
  - `bool IsCorrect { get; }`
  - `DateTimeOffset AnsweredAtUtc { get; }`

---

## QuizBattle.Application.Sessions

**Typer/Filer:**
- `SessionHandler.cs` / `StartSessionHandler.cs`
  - `Task<StartSessionResult> HandleAsync(StartSessionCommand cmd, CancellationToken ct)`

- `AnswerQuestionHandler.cs`
  - `Task<AnswerQuestionResult> HandleAsync(AnswerQuestionCommand cmd, CancellationToken ct)`

- `FinishSessionHandler.cs`
  - `Task<FinishSessionResult> HandleAsync(FinishSessionCommand cmd, CancellationToken ct)`

- Commands/Results:
  - `StartSessionCommand` / `StartSessionResult`
  - `AnswerQuestionCommand` / `AnswerQuestionResult`
  - `FinishSessionCommand` / `FinishSessionResult`

---

## QuizBattle.Api.DTO

**Typer/Filer:**
- `AnswerBody.cs` → `AnswerBody`
  - `string QuestionCode { get; }`
  - `string SelectedChoiceCode { get; }`

---

## QuizBattle.Api.Repository

**Typer/Filer:**
- `InMemoryQuestionRepository.cs` → `InMemoryQuestionRepository : IQuestionRepository`
- `InMemorySessionRepository.cs` → `InMemorySessionRepository : ISessionRepository`

---

## QuizBattle.Api.DependencyInjection

**Typer/Filer:**
- `ServiceCollectionExtensions.cs`
  - `static IServiceCollection AddQuizBattleApiServices(this IServiceCollection services)`

- `WebApplicationExtensions.cs`
  - `static void ConfigureRoutes(this WebApplication app)`
