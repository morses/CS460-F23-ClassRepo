<script lang="ts">
    import { enhance } from '$app/forms';
    import { fade } from 'svelte/transition';
    import Movie from './Movie.svelte';
    import Modal from './Modal.svelte';
    import type { MovieDetails, MovieOverview, MovieSearchResults } from './Dtos';

    type FormType = {
        query: string,
        success: boolean,
        missing: boolean,
        movies: MovieSearchResults
    };

    export let form : FormType | undefined;
    console.log(form);

    let showModal = false;
    let movieId = 0;
    let movieDetails : MovieDetails;// = {id: 0, success: false, data: {title: '', release_date: '', runtime: 0, budget: 0, backdrop_path: '', genres: [{name: ''}]}};

    type MovieDetailsEndpointType = {
        id: number,
        success: boolean,
        data: MovieDetails
    };

    async function showMovieDetails(event : any) {
        let id = event.detail.id;
        movieId = id;
        const response = await fetch('/api/tmdb/movie/details', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ id })
        });
        const data : MovieDetailsEndpointType = await response.json();
        if(!data.success) {
            console.error('Failed to get movie details');
            // Show an error message to the user
            return;
        }
        movieDetails = data.data;
        //console.log(movieDetails);
        showModal = true;
    }
</script>

<svelte:head>
	<title>TMDB</title>
	<meta name="description" content="TMDB app from CS 460 Homework 4" />
</svelte:head>

<h1>TMDB Search</h1>

<form action="?/search" method="POST" use:enhance>
    <input type="text" name="query" placeholder="Search for a movie ..." value={form?.query || ''} required/>
    <button type="submit">Search</button>
</form>
{#if form?.missing}
    <p>Please enter a search query</p>
{/if}

{#if showModal}
<Modal bind:showModal>
    <h1 slot="header">{movieDetails.title}</h1>
    <p>Ran out of time in this example so just outputing unstyled data</p>
    <ul>
        <li>{movieId}</li>
        <li>{movieDetails.release_date}</li>
        <li>{movieDetails.runtime} minutes</li>
        <li>
            {#if movieDetails.genres}
                {#each movieDetails.genres as genre}
                    {genre.name},
                {/each}
            {/if}
        </li>
        <li>${movieDetails.budget}</li>
    </ul>
    <img src={`https://image.tmdb.org/t/p/w780${movieDetails.backdrop_path}`} width="600" alt="Background poster for the movie" />
</Modal>
{/if}
{#if form?.success}
    <div in:fade={{duration:800, delay:400}} out:fade={{duration:300}}>
        {#each form?.movies.results as movie}
            <div class="movies-container" id={`${movie.id}`}>
                <Movie movie={movie} on:message={showMovieDetails} />
            </div>
        {/each}
    </div>
{/if}


<style>
    .movies-container {
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: stretch;
    }

    form {
        display: flex;
        gap: 1rem;
        margin-bottom: 1rem;
        text-align: center;
        justify-content: center;
    }

    input {
        padding: 0.5rem;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 10px;
        width: 60%;
    }

    button {
        background: steelblue;
        color: white;
        padding: 0.5rem 1rem;
        border: none;
        border-radius: 10px;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        font-size: inherit;
        font-family: inherit;
    } 
</style>