<svelte:head>
	<title>TMDB</title>
	<meta name="description" content="TMDB app from CS 460 Homework 4" />
</svelte:head>

<h1>TMDB Search</h1>

<form on:submit|preventDefault={search}>
    <input type="text" bind:value={query} placeholder="Search for a movie ..." />
    <button type="submit">Search</button>
</form>

<script lang="ts">
let query = '';

function search() {
    console.log(`Searching for ${query}`);
}

</script>

<style>
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