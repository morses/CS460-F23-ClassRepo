
// This is a single page app so putting things in site.js is perfect.  It's already loaded
// in the shared layout.

document.addEventListener('DOMContentLoaded', initializePage, false);

function initializePage() {
    console.log('Page loaded, initializing...');
    const searchButton = document.getElementById('search-button');
    searchButton.addEventListener('click', searchRepositories, false);
}

function searchRepositories(e) {
    e.preventDefault();
    const searchInput = document.getElementById('search-input');
    const searchResultsDiv = document.getElementById('search-results');
    const searchTerm = searchInput.value;

    if (!searchTerm) {
        searchResultsDiv.innerHTML = '<h3 class="text-danger text-center">Please enter a search term</h3>';
        return;
    }

    console.log(`Searching for ${searchTerm}`);
    searchResultsDiv.textContent = '';
}
