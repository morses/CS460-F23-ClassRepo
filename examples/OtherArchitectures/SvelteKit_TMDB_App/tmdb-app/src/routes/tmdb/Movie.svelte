<!--Example data:
{
    "adult": false,
    "backdrop_path": "/5YLNDnkO0cZZwog2StyR3YmmBPh.jpg",
    "genre_ids": [
        18,
        10749
    ],
    "id": 597,
    "original_language": "en",
    "original_title": "Titanic",
    "overview": "101-year-old Rose DeWitt Bukater tells the story of her life aboard the Titanic, 84 years later. A young Rose boards the ship with her mother and fiancé. Meanwhile, Jack Dawson and Fabrizio De Rossi win third-class tickets aboard the ship. Rose tells the whole story from Titanic's departure through to its death—on its first and last voyage—on April 15, 1912.",
    "popularity": 138.349,
    "poster_path": "/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg",
    "release_date": "1997-11-18",
    "title": "Titanic",
    "video": false,
    "vote_average": 7.905,
    "vote_count": 24647
}
-->

<script lang="ts">
    import { createEventDispatcher } from 'svelte';
    export let movie;
    const dispatch = createEventDispatcher();

    let imageUrl : string;
    if(movie.poster_path)
    {
        imageUrl = `https://image.tmdb.org/t/p/w500${movie.poster_path}`;
    }
    else
    {
        imageUrl = `https://via.placeholder.com/500x750.png?text=No+Image+Available`;
    }
    const imageAlt = `Poster image for the movie ${movie.title}`;
    // Convert the release date to a more readable format in the form of January 4, 2000
    const releaseDate = new Date(movie.release_date).toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'long',
        day: 'numeric'
    });

    function handleClick() {
        dispatch('message', { id: movie.id } );
    }

</script>

<div class="container">
    <img src={imageUrl} alt={imageAlt} width="90px" />
    <div class="body">
        <h1>{movie.title}</h1>
        <h2>{releaseDate}</h2>
        <p>{movie.overview}  &nbsp;&nbsp;<button on:click={handleClick}>&#9432;</button></p>
        
    </div>
</div>

<style>
    .container {
        display: flex;
        flex-direction: row;
        justify-content: flex-start;
        align-items: stretch;
        margin: 0.5rem 0;
        background-color: white;
        border-radius: 10px;
    }
    .body {
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        margin-left: 0.5rem;
        margin-right: 0.5rem;
    }
    img {
        border-top-left-radius: 10px;
        border-bottom-left-radius: 10px;
    }
    h1 {
        text-align: left;
        font-size: 1.5rem;
        margin-top: 0.1rem;
        margin-bottom: 0.3rem;
    }
    h2 {
        margin-top: 0;
        margin-bottom: 0.4rem;
        font-size: smaller;
        color: #808080;
    }
    p {
        margin-top: 0;
        margin-bottom: 0.1rem;
        font-size: smaller;
    }
    button {
        border: 1px solid rgb(226, 164, 152);
        color: rgb(150, 149, 149);
        padding: 0.1rem 0.3rem;
        border-radius: 5px;
        cursor: pointer;
        width: 30px;
        font-size: x-small;
    }
</style>