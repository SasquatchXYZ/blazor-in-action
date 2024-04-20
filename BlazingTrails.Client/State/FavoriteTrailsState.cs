using BlazingTrails.Client.Features.Home.Shared;
using Blazored.LocalStorage;

namespace BlazingTrails.Client.State;

public class FavoriteTrailsState
{
    private const string FavouriteTrailsKey = "favoriteTrails";
    private bool _isInitialized;
    private List<Trail> _favoriteTrails = [];
    private readonly ILocalStorageService _localStorageService;
    public IReadOnlyList<Trail> FavoriteTrails => _favoriteTrails.AsReadOnly();
    public event Action? OnChange;

    public FavoriteTrailsState(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task Initialize()
    {
        if (!_isInitialized)
        {
            _favoriteTrails = await _localStorageService.GetItemAsync<List<Trail>>(FavouriteTrailsKey) ?? [];
            _isInitialized = true;
            NotifyStateHasChanged();
        }
    }

    public async Task AddFavoriteTrail(Trail trail)
    {
        if (_favoriteTrails.Any(favoriteTrail => favoriteTrail.Id == trail.Id)) return;

        _favoriteTrails.Add(trail);
        await _localStorageService.SetItemAsync(FavouriteTrailsKey, _favoriteTrails);
        NotifyStateHasChanged();
    }

    public async Task RemoveFavoriteTrail(Trail trail)
    {
        var existingTrail = _favoriteTrails.SingleOrDefault(favoriteTrail => favoriteTrail.Id == trail.Id);
        if (existingTrail is null) return;

        _favoriteTrails.Remove(existingTrail);
        await _localStorageService.SetItemAsync(FavouriteTrailsKey, _favoriteTrails);
        NotifyStateHasChanged();
    }

    public bool IsFavoriteTrail(Trail trail) => _favoriteTrails.Any(favoriteTrail => favoriteTrail.Id == trail.Id);
    private void NotifyStateHasChanged() => OnChange?.Invoke();
}
