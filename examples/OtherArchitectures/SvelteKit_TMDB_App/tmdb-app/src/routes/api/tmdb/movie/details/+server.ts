import type { RequestHandler } from './$types';
import { json } from '@sveltejs/kit';
import { TmdbBearerToken } from '$env/static/private';
import type { MovieDetails } from '../../../../tmdb/Dtos.ts';
import { parseMovieDetails } from '../../../../tmdb/Dtos.js';
import type { ZodError } from 'zod';

// Exported GET, POST, PUT, DELETE, etc. functions create API endpoints for this route
// This is like an APIController in MVC

// Helper function is mostly duplicated, could move to a lib folder
async function fetchMovieDetails(id: number) : Promise<MovieDetails | ZodError> {
    //console.log('token:', TmdbBearerToken);
    const uri = `https://api.themoviedb.org/3/movie/${id}?language=en-US`;
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
        return parseMovieDetails(data);
    }
    catch (e : any) {
        return e;
    }
}

export const POST: RequestHandler = async ({ request }) => {
    const { id } = await request.json();
    if (!id)
        return json({ id: id, success: false, data: null });
    const data = await fetchMovieDetails(id);
    return json({ id: id, success: true, data: data});  // data here is either a MovieDetails object or a ZodError
}