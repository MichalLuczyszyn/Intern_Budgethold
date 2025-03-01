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
  private readonly ICategoryService _categoryService;

  public CreateCategoryHandler(ICategoryRepository categoryRepository,
    IWalletRepository walletRepository, IUserContext userContext, ICategoryService categoryService)
  {
    _categoryRepository = categoryRepository;
    _walletRepository = walletRepository;
    _userContext = userContext;
    _categoryService = categoryService;
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

    if (!await _categoryService.IsCategoryUnique(request.WalletId, request.Name, request.Type))
      throw new CategoryNameAlreadyExistsException();

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
