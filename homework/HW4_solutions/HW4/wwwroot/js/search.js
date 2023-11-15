
document.addEventListener('DOMContentLoaded', initializePage, false);

function initializePage() {
    const searchButton = document.getElementById('search-button');
    searchButton.addEventListener('click', searchMovie, false);
}

const simpleInputValidationRegEx = /^[\s\p{P}\$\^=+\\|<>]+$/u;

async function searchMovie(e) {
    e.preventDefault();
    const searchInput = document.getElementById('search-input');
    const searchResultsDiv = document.getElementById('search-results');

    if (!searchInput.value || simpleInputValidationRegEx.test(searchInput.value)) {
        searchResultsDiv.innerHTML = '<h3 class="text-center text-danger">Please enter a movie title</h3>';
        return;
    }

    console.log(`GET: /api/movie/search?title=${searchInput.value}`);

    const response = await fetch(`/api/movie/search?title=${searchInput.value}`);
    let movies;
    if (response.ok) {
        movies = await response.json();
        console.log(movies);
    }
    else {
        searchResultsDiv.innerHTML = '<h3 class="text-center text-danger">Sorry, an error has occurred.  Please try again later.</h3>';
        return;
    }
    

    if (movies.length == 0) {
        searchResultsDiv.innerHTML = '<h3 class="text-center">Sorry, your search returned no results</h3>';
        return;
    }

    searchResultsDiv.innerHTML = '';

    const movieCardTemplate = document.getElementById('movie-card');

    movies.forEach(movie => {
        const clone = movieCardTemplate.content.cloneNode(true);
        clone.getElementById('movie-title').innerText = movie.title;
        clone.getElementById('movie-date').innerText = movie.release_date;
        clone.getElementById('movie-description').innerText = movie.overview.length < 140 ? movie.overview : movie.overview.slice(0,140) + "...";
        clone.getElementById('movie-image').src = movie.poster_path;
        const container = clone.querySelector('.row');
        container.dataset.movieid = movie.id;
        container.onclick = showMovieDetails;
        searchResultsDiv.appendChild(clone);
    });
}

async function showMovieDetails(e) {
    const movieId = e.currentTarget.dataset.movieid;
    console.log(`showMovieDetails for ${movieId}`);
    let modal = new bootstrap.Modal(document.getElementById('movie-detail-modal'));

    let response = await fetch(`/api/movie/${movieId}`);
    let movie;
    if (response.ok) {
        movie = await response.json();
        console.log(movie);
    }
    else {
        let title = document.getElementById('movie-detail-title');
        let year = document.getElementById('movie-detail-year');
        title.innerText = 'Sorry, an error has occurred.  Please try again later.';
        year.innerText = '';
        modal.show();
        return;
    }
    
    const title = document.getElementById('movie-detail-title');
    const date = document.getElementById('movie-detail-date');
    const description = document.getElementById('movie-detail-description');
    const image = document.getElementById('movie-detail-image');
    const year = document.getElementById('movie-detail-year');
    const genres = document.getElementById('movie-detail-genres');
    const runtime = document.getElementById('movie-detail-runtime');
    const popularity = document.getElementById('movie-detail-popularity');
    const revenue = document.getElementById('movie-detail-revenue');

    title.innerText = movie.title;
    date.innerText = movie.release_date;
    description.innerText = movie.overview;
    image.src = movie.backdrop_path;
    year.innerText = `(${movie.release_date.slice(-4)})`;
    genres.innerHTML = movie.genres.map(genre => `<span class="badge rounded-pill bg-info text-dark">${genre.name}</span>`).join(' ');
    runtime.innerText = formatRuntime(movie.runtime);
    popularity.innerText = `${movie.popularity}`;
    revenue.innerText = formatRevenue(movie.revenue);

    response = await fetch(`/api/movie/${movieId}/credits`);
    if (response.ok) {
        const credits = await response.json();
        console.log(credits);
        const cast = document.getElementById('movie-detail-cast');
        // build a string with each cast member's name -- WARNING/TODO: this is not safe for production code unless name and character are sanitized
        cast.innerHTML = credits.slice(0, 10).map(c => `${c.name} ${c.character ? '"' + c.character + '"' : ""}`).join('<br>');
    }
    else {
        // Just leave credits blank
    }
    
    modal.show();
}

// TODO: Incorrectly says 1 minutes instead of 1 minute
// We'll show how to test this in class
function formatRuntime(runtime) {
    if (runtime === 0) return ('not available');
    const hours = Math.floor(runtime / 60);
    const minutes = runtime % 60;
    let outputString;
    if (hours > 1) {
        outputString = `${hours} hours ${minutes} minutes`;
    } else if (hours == 1) {
        outputString = `${hours} hour ${minutes} minutes`;
    } else {
        outputString = `${runtime} minutes`;
    }
    return outputString;
}

// This is another piece of functionality we should test.  We want to do the same thing here as in C#: put code to test in
// a testable place.  The best place is in a function all by itself that does not have any side effects.  We'll show how to test this in class.
function formatRevenue(revenue) {
    if(!revenue) return ('not available');
    let outputString;
    if (revenue > 0) {
        outputString = `\$${new Intl.NumberFormat('en-US').format(revenue)}`;
    }
    else {
        outputString = 'not available';
    }
    return outputString;
}