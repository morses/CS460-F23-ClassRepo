// The code in this file runs on the server only.
import type { Actions } from './$types';
import { fail } from '@sveltejs/kit';
import type { MovieSearchResults } from './Dtos';
import { parseMovieSearchResults } from './Dtos';
import { ZodError } from 'zod';

// Store the API key in an .env file that is excluded from the repo by .gitignore
import { TmdbBearerToken } from '$env/static/private';  // when using a .env file that contains the secret or
// or use the following when secrets are stored in the hosting service, i.e. Vercel in this case
//import { env } from '$env/dynamic/private';


// Helper function to fetch movies from the TMDB API
async function fetchMovies(query: string) : Promise<MovieSearchResults> {
    const q = encodeURIComponent(query);
    const uri = `https://api.themoviedb.org/3/search/movie?query=${q}&include_adult=false&language=en-US&page=1`;
    // fetch this uri and set headers
    const response = await fetch(uri, {
        headers: {
            Authorization: `Bearer ${TmdbBearerToken}`,
            Accept: 'application/json'
        }
    });
    const data = await response.json();
    //console.log(JSON.stringify(data, null, 2));
    try {
        return parseMovieSearchResults(data);
    }
    catch (e : any) {
        return e;
    }
}

/* This function is called on the server when the route is loaded.  Use it to
  * fetch any data needed to render the route.  The returned object will be
  * merged into the route's props, such as `data` in this case.
  * 
  * This is most similar to the Index action method in a controller in MVC for a given route.
  * The data returned is like the model or viewmodel.
  */
// export const load: PageServerLoad = async ({ params }) => {
//     const q = exampleMovieTitles[Math.floor(Math.random() * exampleMovieTitles.length)];
//     return {
//         query: q,
//         movies: await fetchMovies(q),
//         success: true
//     };
// };

// These are the actions that can be called for this route, think of them as APIController endpoints
// but for form submission.
// SvelteKit automatically connects these to form submissions via the specified action parameter
export const actions = {
    search: async ({ cookies, request }) => {
        const data = await request.formData();
        const query = data.get('query') as string;
        if (!query || query.trim().length === 0)
            return { query: query, missing: true, success: false, movies: null };
        let movies: MovieSearchResults;
        try {
            movies = await fetchMovies(query);
            return {
                query: query,
                missing: false,
                movies: movies,
                success: true
            };
        }
        catch (e: any) {
            return {
                query: query,
                missing: false,
                movies: e,
                success: false
            };
        }
        
    },
    sample: async ({ cookies, request }) => {
        return {
            hello: 'World!'
        };
    }
} satisfies Actions;