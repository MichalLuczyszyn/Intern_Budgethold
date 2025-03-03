using Intern_Budgethold.Features.Services;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Features.WalletManagement.Exceptions;
using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly IWalletRepository _walletRepository;
  private readonly IUserContext _userContext;

  public CreateCategoryHandler(ICategoryRepository categoryRepository,
    IWalletRepository walletRepository, IUserContext userContext)
  {
    _categoryRepository = categoryRepository;
    _walletRepository = walletRepository;
    _userContext = userContext;
  }

  public async Task<Guid> Handle(CreateCategoryCommand request,
    CancellationToken ct)
  {
    var userId = _userContext.GetUserId();
    if (userId is null)
      throw new UnauthorizedAccessException("User not authenticated");

    var wallet = await _walletRepository.GetByIdAsync(request.WalletId);
    if (wallet is null)
      throw new WalletNotFoundException();

    if (!wallet.Users.Any(wu => wu.UserId == userId))
      throw new UnauthorizedAccessException("User does not belong to this wallet.");

    if (await _categoryRepository.ExistsAsync(request.WalletId, request.Name, request.Type))
      throw new CategoryAlreadyExistsException();

    var category = Category.Create(
      request.WalletId,
      request.Name,
      request.Description,
      request.Type,
      userId.Value,
      DateTime.UtcNow
    );

    await _categoryRepository.AddAsync(category);
    return category.Id;
  }
}
