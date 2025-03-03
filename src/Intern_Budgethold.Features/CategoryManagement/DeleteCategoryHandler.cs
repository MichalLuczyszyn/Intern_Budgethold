using Intern_Budgethold.Features.CategoryManagement.Exceptions;
using Intern_Budgethold.Features.Services;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Features.WalletManagement.Exceptions;
using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly IWalletRepository _walletRepository;
  private readonly IUserContext _userContext;

  public DeleteCategoryHandler(
    ICategoryRepository categoryRepository,
    IWalletRepository walletRepository,
    IUserContext userContext
  )
  {
    _categoryRepository = categoryRepository;
    _walletRepository = walletRepository;
    _userContext = userContext;
  }

  public async Task Handle(DeleteCategoryCommand request, CancellationToken ct)
  {
    var userId = _userContext.GetUserId();
    if (userId is null)
      throw new UnauthorizedAccessException("User is not authenticated");

    var wallet = await _walletRepository.GetByIdAsync(request.WalletId);
    if (wallet is null)
      throw new WalletNotFoundException();

    if (!wallet.Users.Any(wu => wu.UserId == userId))
      throw new UnauthorizedAccessException("User does not belong to this wallet.");

    var category = await _categoryRepository.GetByIdAsync(request.CategoryId, wallet.Id);
    if (category is null)
      throw new CategoryNotFoundException();

    category.SoftDelete();

    await _categoryRepository.DeleteAsync(category);
  }
}
